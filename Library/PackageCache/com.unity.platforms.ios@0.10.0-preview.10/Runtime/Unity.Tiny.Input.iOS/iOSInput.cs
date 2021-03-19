using Unity.Entities;
using Unity.Mathematics;
using Unity.Core;
using Unity.Tiny.Input;

namespace Unity.Tiny.iOS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(iOSWindowSystem))]
    public class iOSInputSystem : InputSystem
    {
        protected override void OnStartRunning()
        {
            base.OnStartRunning();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            iOSNativeCalls.inputStreamsLock(true);
            base.OnUpdate(); // advances input state one frame
            unsafe
            {
                // touch & simulate mouse
                m_inputState.hasMouse = false;
                int touchInfoStreamLen = 0;
                int* touchInfoStream = iOSNativeCalls.getTouchInfoStream(ref touchInfoStreamLen);
                for (int i = 0; i < touchInfoStreamLen; i += 4)
                {
                    var id = touchInfoStream[i];
                    var x = touchInfoStream[i + 2];
                    var y = touchInfoStream[i + 3];
                    TouchState phase;
                    switch (touchInfoStream[i + 1])
                    {
                        case 0 : phase = TouchState.Began; break; //UITouchPhaseBegan
                        case 1 : phase = TouchState.Ended; break; //UITouchPhaseEnded
                        case 2 : phase = TouchState.Moved; break; //UITouchPhaseMoved
                        case 3 : phase = TouchState.Canceled; break; //UITouchPhaseCancelled
                        default : continue;
                    }
                    ProcessTouch(id, phase, x, y);
                }
            }
            iOSNativeCalls.resetStreams();
            iOSNativeCalls.inputStreamsLock(false);
        }

        protected override bool IsAvailable(ComponentType type)
        {
            if (type == typeof(AccelerometerSensor))
            {
                return iOSNativeCalls.availableSensor((int)iOSSensorType.Accelerometer);
            }
            else if (type == typeof(GyroscopeSensor))
            {
                return iOSNativeCalls.availableSensor((int)iOSSensorType.Gyro);
            }
            else if (type == typeof(GravitySensor))
            {
                return iOSNativeCalls.availableSensor((int)iOSSensorType.Gravity);
            }
            else if (type == typeof(AttitudeSensor))
            {
                return iOSNativeCalls.availableSensor((int)iOSSensorType.Attitude);
            }
            else if (type == typeof(LinearAccelerationSensor))
            {
                return iOSNativeCalls.availableSensor((int)iOSSensorType.LinearAcceleration);
            }
            return false;
        }

        protected override Sensor CreateSensor(ComponentType type)
        {
            if (type == typeof(AccelerometerSensor))
            {
                return new Sensor(type, new iOSAccelerometerSensor(this));
            }
            else if (type == typeof(GyroscopeSensor))
            {
                return new Sensor(type, new iOSGyroscopeSensor(this));;
            }
            else if (type == typeof(GravitySensor))
            {
                return new Sensor(type, new iOSGravitySensor(this));
            }
            else if (type == typeof(AttitudeSensor))
            {
                return new Sensor(type, new iOSAttitudeSensor(this));;
            }
            else if (type == typeof(LinearAccelerationSensor))
            {
                return new Sensor(type, new iOSLinearAccelerationSensor(this));
            }
            return null;
        }
    }

    // copy from iOSSensors.h
    enum iOSSensorType
    {
        Accelerometer = 0,
        Gyro,
        Gravity,
        LinearAcceleration,
        Attitude,
        MaxSensors
    }

    internal class iOSSensor<TValue> where TValue : struct
    {
        private bool m_Enabled;
        private iOSSensorType m_SensorType;
        private InputProcessor<TValue> m_InputProcessor;
        private RawSensorDataConverter<TValue> m_RawSensorDataConverter;
        private InputSystem m_InputSystem;
        private double m_LastTime;
        private Entity m_SensorSingleton;

        public iOSSensor(InputSystem inputSystem, iOSSensorType type, InputProcessor<TValue> inputProcessor, RawSensorDataConverter<TValue> rawSensorDataConverter)
        {
            m_Enabled = false;
            m_SensorType = type;
            m_InputProcessor = inputProcessor;
            m_RawSensorDataConverter = rawSensorDataConverter;
            m_InputSystem = inputSystem;
            m_LastTime = 0.0;
        }

        public void Dispose()
        {
            iOSNativeCalls.enableSensor((int)m_SensorType, false);
        }

        public bool Enabled
        {
            get
            {
                return m_Enabled;
            }
            set
            {
                m_Enabled = iOSNativeCalls.enableSensor((int)m_SensorType, value);
            }
        }

        public int SamplingFrequency
        {
            get
            {
                return iOSNativeCalls.getSensorFrequency((int)m_SensorType);
            }
            set
            {
                // TODO check for valid values
                iOSNativeCalls.setSensorFrequency((int)m_SensorType, value);
            }
        }

        private unsafe double* GetSensorData(ref int len)
        {
            return iOSNativeCalls.getSensorStream((int)m_SensorType, ref len);
        }

        protected unsafe bool UpdateInputData(ref TimeData lastUpdateTime, ref TValue inputData)
        {
            int len = 0;
            var data = GetSensorData(ref len);
            if (len > 0)
            {
                var time = m_LastTime;
                for (int i = 0; i < len; )
                {
                    time = data[i++];
                    inputData = m_RawSensorDataConverter.ConvertRawSensorData(data, ref i);
                    m_InputProcessor.Process(m_InputSystem, ref inputData);
                }
                lastUpdateTime = new TimeData(time, (float)(time - m_LastTime));
                m_LastTime = time;
                return true;
            }
            return false;
        }

        protected void SetSensorData<T>(T data) where T : struct, IComponentData
        {
            if (m_SensorSingleton == Entity.Null)
            {
                m_SensorSingleton = m_InputSystem.EntityManager.CreateEntity(typeof(T));
            }
            m_InputSystem.EntityManager.SetComponentData(m_SensorSingleton, data);
        }
    }

    internal class iOSAccelerometerSensor : iOSSensor<float3>, IPlatformSensor
    {
        public iOSAccelerometerSensor(InputSystem inputSystem) :
            base(inputSystem, iOSSensorType.Accelerometer, new CompensateDirectionProcessor(), new Float3RawSensorDataConeverter()) {} 

        public void ProcessSensorData()
        {
            var data = new AccelerometerSensor();
            if (UpdateInputData(ref data.LastUpdateTime, ref data.Acceleration))
            {
                SetSensorData<AccelerometerSensor>(data);
            }
        }
    }

    internal class iOSGyroscopeSensor : iOSSensor<float3>, IPlatformSensor
    {
        public iOSGyroscopeSensor(InputSystem inputSystem) :
            base(inputSystem, iOSSensorType.Gyro, new CompensateDirectionProcessor(), new Float3RawSensorDataConeverter()) {} 

        public void ProcessSensorData()
        {
            var data = new GyroscopeSensor();
            if (UpdateInputData(ref data.LastUpdateTime, ref data.AngularVelocity))
            {
                SetSensorData<GyroscopeSensor>(data);
            }
        }
    }

    internal class iOSGravitySensor : iOSSensor<float3>, IPlatformSensor
    {
        public iOSGravitySensor(InputSystem inputSystem) :
            base(inputSystem, iOSSensorType.Gravity, new CompensateDirectionProcessor(), new Float3RawSensorDataConeverter()) {} 

        public void ProcessSensorData()
        {
            var data = new GravitySensor();
            if (UpdateInputData(ref data.LastUpdateTime, ref data.Gravity))
            {
                SetSensorData<GravitySensor>(data);
            }
        }
    }

    internal class iOSAttitudeSensor : iOSSensor<quaternion>, IPlatformSensor
    {
        public iOSAttitudeSensor(InputSystem inputSystem) :
            base(inputSystem, iOSSensorType.Attitude, new CompensateRotationProcessor(), new QuaternionRawSensorDataConeverter()) {} 

        public void ProcessSensorData()
        {
            var data = new AttitudeSensor();
            if (UpdateInputData(ref data.LastUpdateTime, ref data.Attitude))
            {
                SetSensorData<AttitudeSensor>(data);
            }
        }
    }

    internal class iOSLinearAccelerationSensor : iOSSensor<float3>, IPlatformSensor
    {
        public iOSLinearAccelerationSensor(InputSystem inputSystem) :
            base(inputSystem, iOSSensorType.LinearAcceleration, new CompensateDirectionProcessor(), new Float3RawSensorDataConeverter()) {} 

        public void ProcessSensorData()
        {
            var data = new LinearAccelerationSensor();
            if (UpdateInputData(ref data.LastUpdateTime, ref data.Acceleration))
            {
                SetSensorData<LinearAccelerationSensor>(data);
            }
        }
    }

    internal abstract class RawSensorDataConverter<TValue> where TValue : struct
    {
        public unsafe abstract TValue ConvertRawSensorData(double *data, ref int idx);
    }

    internal class Float3RawSensorDataConeverter : RawSensorDataConverter<float3>
    {
        public unsafe override float3 ConvertRawSensorData(double *data, ref int idx)
        {
            var ret = new float3((float)data[idx], (float)data[idx + 1], (float)data[idx + 2]);
            idx += 3;
            return ret;
        }
    }

    internal class QuaternionRawSensorDataConeverter : RawSensorDataConverter<quaternion>
    {
        public unsafe override quaternion ConvertRawSensorData(double *data, ref int idx)
        {
            var ret = new quaternion((float)data[idx], (float)data[idx + 1], (float)data[idx + 2], (float)data[idx + 3]);
            idx += 4;
            return ret;
        }
    }
}
