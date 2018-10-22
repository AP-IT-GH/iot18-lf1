import { LabFarm } from "./LabFarm";
import { SensorType } from "./SensorType";

export class SensorData {
    public SensorId: number;
    public LabFarm: LabFarm;
    public SensorType: SensorType;
    public SensorValue: number;
    public Timestamp: string;
}