export interface SensorValue {
    id: number;
    sensorValue: number;
    timeStamp: Date;
    sensorId: number;
}

export interface LastSensorValues {
    name: string;
    data: SensorValue[];
}