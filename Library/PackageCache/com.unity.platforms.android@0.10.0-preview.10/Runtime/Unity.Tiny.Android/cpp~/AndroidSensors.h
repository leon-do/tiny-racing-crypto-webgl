#include <Unity/Runtime.h>

#include <android/log.h>
#include <android/sensor.h>
#include <vector>
#include <mutex>
#include <unordered_map>

class SensorData
{
public:
    SensorData(ASensorRef sensor) : m_Sensor(sensor) {}
    ASensorRef m_Sensor;
    std::vector<double> m_Data;
};

class AndroidSensors
{
private:
    std::mutex m_SensorsDataLock;
    std::unordered_map<int, SensorData*> m_Sensors;
    ASensorEventQueue* m_SensorEventQueue;

    static int SensorCallbackFunc(int fd, int events, void* data);

    static int HzToMicroSeconds(int hz)
    {
        return (int)(1.0f / hz * 1000000.0f);
    }

public:
    void InitializeSensors();

    void ShutdownSensors();

    void ResetSensorsData();

    bool AvailableSensor(int type);

    bool EnableSensor(int type, bool enable, int rate);

    const double* GetSensorData(int type, int *len);

    void LockSensorsData(bool lock);
};

extern AndroidSensors m_AndroidSensors;

DOTS_EXPORT(double) time_android();
