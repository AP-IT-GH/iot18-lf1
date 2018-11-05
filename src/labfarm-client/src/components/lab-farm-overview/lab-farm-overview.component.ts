import { Component, OnInit, Input } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { SensorData } from 'src/models/SensorData';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { MatTooltipModule } from '@angular/material/tooltip';


@Component({
    selector: 'app-lab-farm-overview',
    templateUrl: './lab-farm-overview.component.html',
    styleUrls: ['./lab-farm-overview.component.scss']
})
export class LabFarmOverviewComponent implements OnInit {


    @Input() labFarm: LabFarm;

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

    ngOnInit() {

    }

}
