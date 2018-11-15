import { SensorType } from "./SensorType";

export interface SensorValue {
    id: number;
    sensorValue: number;
    timeStamp: Date;
    sensorId: number;
}

export interface LastSensorValues {
    id: number;
    name: string;
    labFarmId: number;
    sensorType: SensorType;
    sensorValues: SensorValue[];
}