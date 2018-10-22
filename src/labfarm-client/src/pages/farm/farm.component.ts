import { Component, OnInit } from '@angular/core';
import {MatSliderModule} from '@angular/material/slider';
import * as hammerjs from 'hammerjs/hammer';
import { LabFarm } from 'src/models/LabFarm';
import { SensorData } from 'src/models/SensorData';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';

@Component({
    selector: 'app-farm',
    templateUrl: './farm.component.html',
    styleUrls: ['./farm.component.scss']
})
export class FarmComponent implements OnInit {

    public autoMode = true;

    public lightLevel = 160;
    public lightDisabled = true;
    public conductivityLevel = 60;
    public conductivityDisabled = true;

    public labFarm: LabFarm;
    public humiditySensor: SensorData;
    public dustSensor: SensorData;
    public lightSensor: SensorData;
    public conductivitySensor: SensorData;
    public waterSensor: SensorData;

    constructor(private labfarmService: LabfarmService) {
        let latestSensorData = labfarmService.getLatestSensorData();
        this.humiditySensor = latestSensorData[0];
        this.dustSensor = latestSensorData[1];
        this.lightSensor = latestSensorData[2];
        this.conductivitySensor = latestSensorData[3];
        this.waterSensor = latestSensorData[4];

        this.labFarm = this.humiditySensor.LabFarm;
     }

    ngOnInit() { }

    autoModeChanged() {
        this.lightDisabled = !this.autoMode;
        this.conductivityDisabled = !this.autoMode;
    }

}
