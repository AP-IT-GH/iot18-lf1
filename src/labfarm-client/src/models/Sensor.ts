import { SensorType } from "./SensorType";
import { SensorValue } from "./SensorValue";

export interface Sensor {
    id: number;
    name: string;
    labFarmId: number;
    sensorTypeId: number;
    sensorType: SensorType;
    sensorValues: SensorValue[];
}