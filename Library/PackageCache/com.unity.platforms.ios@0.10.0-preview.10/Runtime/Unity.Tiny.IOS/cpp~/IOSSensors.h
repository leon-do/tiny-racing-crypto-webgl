#pragma once

#import <Foundation/Foundation.h>
#import <GameController/GameController.h>
#import <UIKit/UIKit.h>
#import <CoreMotion/CoreMotion.h>
#include <vector>

enum iOSSensorType
{
    Accelerometer = 0,
    Gyro,
    Gravity,
    LinearAcceleration,
    Attitude,
    MaxSensors
};

class iOSSensors
{
    CMMotionManager* m_MotionManager;
    NSOperationQueue* m_SensorsQueue;
    NSCondition* m_Condition;
    bool m_SensorOn[MaxSensors];
    bool m_SensorsQueueBlocked;

    std::vector<double> m_Data[MaxSensors];

public:
    void InitializeSensors();

    void ShutdownSensors();

    bool AvailableSensor(iOSSensorType type);

    void SetSamplingFrequency(iOSSensorType type, int rate);

    int GetSamplingFrequency(iOSSensorType type);

    bool EnableSensor(iOSSensorType type, bool enable);

    const double* GetSensorData(iOSSensorType type, int* len);

    void ResetSensorsData();
};

extern iOSSensors m_iOSSensors;

