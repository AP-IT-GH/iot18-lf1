import { LabFarm } from "./LabFarm";
import { SensorType } from "./SensorType";

export interface SensorData {
    SensorId: number;
    LabFarm: LabFarm;
    SensorType: SensorType;
    SensorValue: number;
    Timestamp: string;
}