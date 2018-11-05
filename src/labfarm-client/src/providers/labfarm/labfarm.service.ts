import { Injectable } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { SensorType } from 'src/models/SensorType';
import { SensorData } from 'src/models/SensorData';

@Injectable({
    providedIn: 'root'
})
export class LabfarmService {

    private labFarms: LabFarm[];
    private sensorTypes: SensorType[];
    private sensorDatas: SensorData[];

    constructor() {
        this.sensorTypes = [
            {
                TypeId: 1,
                TypeName: "Humidity"
            },
            {
                TypeId: 2,
                TypeName: "Dust"
            },
            {
                TypeId: 3,
                TypeName: "Light"
            },
            {
                TypeId: 4,
                TypeName: "Conductivity"
            },
            {
                TypeId: 5,
                TypeName: "Water level"
            }
        ];
        this.labFarms = [
            {
                LabFarmId: 123,
                AuthId: "abc123",
                PlantSpecies: "Cucumber",
                DustLevelHigh: 20,
                DustLevelLow: 14,
                LightLevelHigh: 240,
                LightLevelLow: 160,
                HumidityLevelHigh: 4.2,
                HumidityLevelLow: 2.4,
                ConductivityLevelHigh: 7.2,
                ConductivityLevelLow: 5.6,
                MinimumReservoirLevel: 5,
                MaximumReservoirLevel: 60
            },
            {
                LabFarmId: 124,
                AuthId: "abc124",
                PlantSpecies: "Tomato",
                DustLevelHigh: 22,
                DustLevelLow: 12,
                LightLevelHigh: 240,
                LightLevelLow: 160,
                HumidityLevelHigh: 7.8,
                HumidityLevelLow: 4.3,
                ConductivityLevelHigh: 5.5,
                ConductivityLevelLow: 4.3,
                MinimumReservoirLevel: 5,
                MaximumReservoirLevel: 80
            }
        ];
        this.sensorDatas = [
            {
                SensorId: 1,
                LabFarm: this.labFarms[0],
                SensorType: this.sensorTypes[0],
                SensorValue: 8.2,
                Timestamp: "01/08/18 14:16:59"
            },
            {
                SensorId: 2,
                LabFarm: this.labFarms[0],
                SensorType: this.sensorTypes[1],
                SensorValue: 4.2,
                Timestamp: "01/08/18 14:16:59"
            },
            {
                SensorId: 3,
                LabFarm: this.labFarms[0],
                SensorType: this.sensorTypes[2],
                SensorValue: 5.7,
                Timestamp: "01/08/18 14:16:59"
            },
            {
                SensorId: 4,
                LabFarm: this.labFarms[0],
                SensorType: this.sensorTypes[3],
                SensorValue: 2.1,
                Timestamp: "01/08/18 14:16:59"
            },
            {
                SensorId: 5,
                LabFarm: this.labFarms[0],
                SensorType: this.sensorTypes[4],
                SensorValue: 50,
                Timestamp: "01/08/18 14:16:59"
            }
        ]
    }

    public getLatestSensorData(): SensorData[] {
        return this.sensorDatas;
    }

    public getLabFarms(userid: number): LabFarm[] {
        return this.labFarms;
    }
}
