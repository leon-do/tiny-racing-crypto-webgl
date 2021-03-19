#include "AndroidSensors.h"

AndroidSensors m_AndroidSensors;

int AndroidSensors::SensorCallbackFunc(int fd, int events, void* data)
{
    AndroidSensors* sensors = (AndroidSensors*)data;
    ASensorEventQueue* queue = sensors->m_SensorEventQueue;
    if (!queue)
        return 0;   // "0 to have this file descriptor and callback unregistered from the looper"

    std::lock_guard<std::mutex> lock(sensors->m_SensorsDataLock);
    while (ASensorEventQueue_hasEvents(queue) > 0)
    {
        const int kEventBufferSize = 8;
        ASensorEvent eventBuffer[kEventBufferSize];
        ssize_t numEvents = ASensorEventQueue_getEvents(queue, eventBuffer, kEventBufferSize);
        for (ssize_t i = 0; i < numEvents; ++i)
        {
            ASensorEvent& event = eventBuffer[i];
            auto item = sensors->m_Sensors.find(event.type);
            if (item == sensors->m_Sensors.end())
            {
                __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Ignoring sensor event type %d", event.type);
            }
            else
            {
                // Note: After just disabling sensor, some events will still go through for few miliseconds, not sure how internally they're queued
                //       But most likely, the queue isn't flushed during during ASensorEventQueue_disableSensor
                //       Accept those events and send them to input system.

                // Note: There is no way to convert event.timestamp value to UnityTime at the moment.
                //       Timestamp generation methods are undocumented therefore value is Unity methods
                double time = time_android();
                // Spams a lot, uncomment only if needed
                /*__android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Received sensor event from type %d (Time = %f) (%.2f, %.2f, %.2f, %.2f x %.2f, %.2f, %.2f, %.2f x %.2f, %.2f, %.2f, %.2f x %.2f, %.2f, %.2f, %.2f)",
                    event.type,
                    time,
                    event.data[0], event.data[1], event.data[2], event.data[3],
                    event.data[4], event.data[5], event.data[6], event.data[7],
                    event.data[8], event.data[9], event.data[10], event.data[11],
                    event.data[12], event.data[13], event.data[14], event.data[15]);*/

                item->second->m_Data.push_back(time);
                // TODO check if we might need more than 3 elements for some sensors
                for (int i = 0; i < 3; ++i)
                {
                    item->second->m_Data.push_back(event.data[i]);
                }
            }
        }
    }

    // Continue receiving callbacks
    return 1;
}

void AndroidSensors::InitializeSensors()
{
    ASensorManager* manager = ASensorManager_getInstance();
    if (!manager)
    {
        __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Can't get ASensorManager instanse");
        return;
    }

    ALooper* looper = ALooper_forThread();
    if (looper == NULL)
    {
        __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Can't get looper for current thread");
        looper = ALooper_prepare(ALOOPER_PREPARE_ALLOW_NON_CALLBACKS);
    }

    // according to documenatation some arbitrary non-negative value is required
    const int kLoopIdSensor = 2;
    m_SensorEventQueue = ASensorManager_createEventQueue(manager, looper, kLoopIdSensor, SensorCallbackFunc, this);

    ASensorList list;
    const int numSensors = ASensorManager_getSensorList(manager, &list);
    __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Found %i native sensors:", numSensors);

    for (int i = 0; i < numSensors; ++i)
    {
        ASensorRef sensor = list[i];
        int type = ASensor_getType(sensor);

        auto item = m_Sensors.find(type);
        if (item == m_Sensors.end())
        {
            __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Sensor[%d] Type = '%s'(%d)", i, ASensor_getName(sensor), type);
            m_Sensors[type] = new SensorData(sensor); // TODO check if we have to use custom allocator here
        }
        else
        {
            // Android bug: (Happened on LGE LG-H870, Android 8.0. And some other phones) for some reason, ASensorManager_getSensorList returns duplicate sensors,
            // for ex., type Accelerometer is reported twice,even though only one accelerometer exists.
            // Note: When receiving sensor event, we only get sensor type (and not sensorRef), thus it's very important not to have sensors with same type)
            __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Sensor[%d] Type = '%s'(%d) was already registered, ignoring.", i, ASensor_getName(sensor), type);
        }
    }
}

void AndroidSensors::ShutdownSensors()
{
    if (!m_SensorEventQueue)
        return;

    ASensorManager* manager = ASensorManager_getInstance();
    ASensorManager_destroyEventQueue(manager, m_SensorEventQueue);
    m_SensorEventQueue = NULL;

    for (auto item = m_Sensors.begin(); item != m_Sensors.end(); ++item)
    {
        delete item->second; // TODO check if we have to use custom allocator here
    }
}

bool AndroidSensors::AvailableSensor(int type)
{
    return m_Sensors.find(type) != m_Sensors.end();
}

bool AndroidSensors::EnableSensor(int type, bool enable, int rate)
{
    auto item = m_Sensors.find(type);
    if (item != m_Sensors.end())
    {
        auto sensor = item->second->m_Sensor;
        if (enable)
        {
            if (ASensorEventQueue_enableSensor(m_SensorEventQueue, sensor) == 0)
            {
                ASensorEventQueue_setEventRate(m_SensorEventQueue, sensor, HzToMicroSeconds(rate));
                return true;
            }
        }
        else
        {
            ASensorEventQueue_disableSensor(m_SensorEventQueue, sensor);
        }
    }
    else
    {
        __android_log_print(ANDROID_LOG_INFO, "AndroidWrapper", "Sensor with Type %d not found, ignoring.", type);
    }
    return false;
}

const double* AndroidSensors::GetSensorData(int type, int *len)
{
    auto item = m_Sensors.find(type);
    if (item != m_Sensors.end())
    {
        *len = (int)item->second->m_Data.size();
        return item->second->m_Data.data();
    }
    else
    {
        *len = 0;
        return NULL;
    }
}

void AndroidSensors::ResetSensorsData()
{
    for (auto item = m_Sensors.begin(); item != m_Sensors.end(); ++item)
    {
        item->second->m_Data.clear();
    }
}

void AndroidSensors::LockSensorsData(bool lock)
{
    if (lock)
    {
        m_SensorsDataLock.lock();
    }
    else
    {
        m_SensorsDataLock.unlock();
    }
}
