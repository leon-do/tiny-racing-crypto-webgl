#include "IOSSensors.h"

iOSSensors m_iOSSensors;

extern "C" double time_ios();

void iOSSensors::InitializeSensors()
{
    m_MotionManager = [[CMMotionManager alloc] init];
    m_SensorsQueue = [[NSOperationQueue alloc] init];
    m_Condition = [[NSCondition alloc] init];
    for (int i = 0; i < MaxSensors; ++i)
    {
        m_SensorOn[i] = false;
    }
}

void iOSSensors::ShutdownSensors()
{
    for (int i = 0; i < MaxSensors; ++i)
    {
        EnableSensor((iOSSensorType)i, false);
    }
    m_MotionManager = nil;
    m_SensorsQueue = nil;
    m_Condition = nil;
}

bool iOSSensors::AvailableSensor(iOSSensorType type)
{
    switch (type)
    {
        case Accelerometer: return m_MotionManager.accelerometerAvailable;
        case Gyro: return m_MotionManager.gyroAvailable;
        case Gravity:
        case LinearAcceleration:
        case Attitude: return m_MotionManager.deviceMotionAvailable;
        default: return false;
    }
    return false;
}

void iOSSensors::SetSamplingFrequency(iOSSensorType type, int rate)
{
    if (!AvailableSensor(type))
    {
        return;
    }
    float updateInterval = 1.0f / rate;
    switch (type)
    {
        case Accelerometer:
            m_MotionManager.accelerometerUpdateInterval = updateInterval;
            return;

        case Gyro:
            m_MotionManager.gyroUpdateInterval = updateInterval;
            return;

        case Gravity:
        case LinearAcceleration:
        case Attitude:
            m_MotionManager.deviceMotionUpdateInterval = updateInterval;
            return;
        default:
            return;
    }
}

int iOSSensors::GetSamplingFrequency(iOSSensorType type)
{
    if (!AvailableSensor(type))
    {
        return 0;
    }
    float updateInterval = -1.0f;
    switch (type)
    {
        case Accelerometer:
            updateInterval = m_MotionManager.accelerometerUpdateInterval;
            break;

        case Gyro:
            updateInterval = m_MotionManager.gyroUpdateInterval;
            break;

        case Gravity:
        case LinearAcceleration:
        case Attitude:
            updateInterval = m_MotionManager.deviceMotionUpdateInterval;
            break;
        default:
            break;
    }
    if (updateInterval > 0.0f)
    {
        return (int)((1.0f / updateInterval) + 0.5f);
    }
    return 0;
}

bool iOSSensors::EnableSensor(iOSSensorType type, bool enable)
{
    if (!AvailableSensor(type))
    {
        return false;
    }
    if (enable && !m_SensorOn[type])
    {
        switch (type)
        {
            case Accelerometer:
                [m_MotionManager startAccelerometerUpdatesToQueue: m_SensorsQueue
                    withHandler:^(CMAccelerometerData *accelerometerData, NSError *error)
                    {
                        double time = time_ios();
                        m_Data[Accelerometer].push_back(time);
                        m_Data[Accelerometer].push_back(accelerometerData.acceleration.x);
                        m_Data[Accelerometer].push_back(accelerometerData.acceleration.y);
                        m_Data[Accelerometer].push_back(accelerometerData.acceleration.z);
                    }];
                m_SensorOn[Accelerometer] = true;
                return true;

            case Gyro:
                // rotationRate is also available through motionData, need to check if there is any difference 
                [m_MotionManager startGyroUpdatesToQueue: m_SensorsQueue
                    withHandler:^(CMGyroData *gyroData, NSError *error)
                    {
                        double time = time_ios();
                        m_Data[Gyro].push_back(time);
                        m_Data[Gyro].push_back(gyroData.rotationRate.x);
                        m_Data[Gyro].push_back(gyroData.rotationRate.y);
                        m_Data[Gyro].push_back(gyroData.rotationRate.z);
                    }];
                m_SensorOn[Gyro] = true;
                return true;

            case Gravity:
            case LinearAcceleration:
            case Attitude:
                if (!m_SensorOn[Gravity] && !m_SensorOn[LinearAcceleration] && !m_SensorOn[Attitude])
                {
                    [m_MotionManager startDeviceMotionUpdatesToQueue: m_SensorsQueue
                        withHandler:^(CMDeviceMotion *motionData, NSError *error)
                        {
                            double time = time_ios();
                            if (m_SensorOn[Attitude])
                            {
                                m_Data[Attitude].push_back(time);
                                m_Data[Attitude].push_back(motionData.attitude.quaternion.x);
                                m_Data[Attitude].push_back(motionData.attitude.quaternion.y);
                                m_Data[Attitude].push_back(motionData.attitude.quaternion.z);
                                m_Data[Attitude].push_back(motionData.attitude.quaternion.w);
                            }
                            if (m_SensorOn[Gravity])
                            {                            
                                m_Data[Gravity].push_back(time);
                                m_Data[Gravity].push_back(motionData.gravity.x);
                                m_Data[Gravity].push_back(motionData.gravity.y);
                                m_Data[Gravity].push_back(motionData.gravity.z);
                            }
                            if (m_SensorOn[LinearAcceleration])
                            {
                                m_Data[LinearAcceleration].push_back(time);
                                m_Data[LinearAcceleration].push_back(motionData.userAcceleration.x);
                                m_Data[LinearAcceleration].push_back(motionData.userAcceleration.y);
                                m_Data[LinearAcceleration].push_back(motionData.userAcceleration.z);
                            }
                         }];
                }
                m_SensorOn[type] = true;
                return true;
            default:
                return false;
        }
    }
    else if (!enable && m_SensorOn[type])
    {
        switch (type)
        {
            case Accelerometer:
                m_SensorOn[Accelerometer] = false;
                [m_MotionManager stopAccelerometerUpdates];
                return false;

            case Gyro:
                m_SensorOn[Gyro] = false;
                [m_MotionManager stopGyroUpdates];
                return false;

            case Gravity:
            case LinearAcceleration:
            case Attitude:
                m_SensorOn[type] = false;
                if (!m_SensorOn[Gravity] && !m_SensorOn[LinearAcceleration] && !m_SensorOn[Attitude])
                {
                    [m_MotionManager stopDeviceMotionUpdates];
                }
                return false;
            default:
                return false;
        }
    }
    return false;
}

const double* iOSSensors::GetSensorData(iOSSensorType type, int* len)
{
    [m_SensorsQueue waitUntilAllOperationsAreFinished];
    m_SensorsQueueBlocked = true;
    // blocking sensors queue until sensors data are reset
    [m_SensorsQueue addOperationWithBlock: ^{
        [m_Condition lock];
        while (m_SensorsQueueBlocked)
        {
            [m_Condition wait];
        }
        [m_Condition unlock];
    }];
    *len = (int)m_Data[type].size();
    return m_Data[type].data();
}

void iOSSensors::ResetSensorsData()
{
    for (int i = 0; i < MaxSensors; ++i)
    {
        m_Data[i].clear();
    }
    // unblocking sensors queue
    [m_Condition lock];
    m_SensorsQueueBlocked = false;
    [m_Condition signal];
    [m_Condition unlock];
}

