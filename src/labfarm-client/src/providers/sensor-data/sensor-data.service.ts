import { Injectable } from '@angular/core';
import { SensorData } from 'src/models/SensorData';
import { LabFarm } from 'src/models/LabFarm';
import { SensorType } from 'src/models/SensorType';

@Injectable({
    providedIn: 'root'
})
export class SensorDataService {

    private labFarm: LabFarm;
    private sensorType: SensorType;
    private sensorDatas: SensorData[];

    constructor() {
    }
    //     this.sensorType = {
    //         id: 1,
    //         name: "Sensor #"
    //     }
    //     this.labFarm = {
    //         LabFarmId: 123,
    //         AuthId: "abc123",
    //         PlantSpecies: "Cucumber",
    //         DustLevelHigh: 20,
    //         DustLevelLow: 14,
    //         LightLevelHigh: 240,
    //         LightLevelLow: 160,
    //         HumidityLevelHigh: 4.2,
    //         HumidityLevelLow: 2.4,
    //         ConductivityLevelHigh: 7.2,
    //         ConductivityLevelLow: 5.6,
    //         MinimumReservoirLevel: 5,
    //         MaximumReservoirLevel: 60
    //     };
    //     this.sensorDatas = [
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.2,
    //             Timestamp: "12:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.3,
    //             Timestamp: "13:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.4,
    //             Timestamp: "14:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.6,
    //             Timestamp: "15:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.8,
    //             Timestamp: "16:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.5,
    //             Timestamp: "17:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.2,
    //             Timestamp: "18:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.0,
    //             Timestamp: "19:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.9,
    //             Timestamp: "20:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.8,
    //             Timestamp: "21:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.5,
    //             Timestamp: "22:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.4,
    //             Timestamp: "23:00"
    //         },
    //         {
    //             SensorId: 2,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.3,
    //             Timestamp: "00:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.0,
    //             Timestamp: "01:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 6.2,
    //             Timestamp: "02:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 5.6,
    //             Timestamp: "03:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 5.4,
    //             Timestamp: "4:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 5.5,
    //             Timestamp: "05:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 6.3,
    //             Timestamp: "06:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.4,
    //             Timestamp: "07:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 7.9,
    //             Timestamp: "08:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.0,
    //             Timestamp: "09:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.3,
    //             Timestamp: "10:00"
    //         },
    //         {
    //             SensorId: 1,
    //             LabFarm: this.labFarm,
    //             SensorType: this.sensorType,
    //             SensorValue: 8.7,
    //             Timestamp: "11:00"
    //         }
    //     ]
    //  }

     public getSensorDatas(): SensorData[] {
         return this.sensorDatas;
     }
}
