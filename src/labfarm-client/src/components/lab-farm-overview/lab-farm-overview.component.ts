import { Component, OnInit, Input } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { SensorData } from 'src/models/SensorData';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { MatTooltipModule } from '@angular/material/tooltip';
import { LabFarmDto } from 'src/models/LabFarmDto';
import { SensorValue } from 'src/models/SensorValue';


@Component({
    selector: 'app-lab-farm-overview',
    templateUrl: './lab-farm-overview.component.html',
    styleUrls: ['./lab-farm-overview.component.scss']
})
export class LabFarmOverviewComponent implements OnInit {


    @Input() labFarm: LabFarmDto;

    public temperatureSensor: SensorValue;
    public dustSensor: SensorValue;
    public lightSensor: SensorValue;
    public conductivitySensor: SensorValue;
    public waterSensor: SensorValue;

    constructor(private labfarmService: LabfarmService) {

    }

    ngOnInit() {
        console.log(this.labFarm);
        let sensors = this.labFarm.sensors;
        console.log(sensors);
        sensors.forEach(element => {
            if (element.sensorType.id === 1) this.temperatureSensor = element.sensorValues[0];
            if (element.sensorType.id === 2) this.dustSensor = element.sensorValues[0];
            if (element.sensorType.id === 3) this.lightSensor = element.sensorValues[0];
            if (element.sensorType.id === 4) this.conductivitySensor = element.sensorValues[0];
            if (element.sensorType.id === 5) this.waterSensor = element.sensorValues[0];
        });
        console.log(this.temperatureSensor);
        console.log(this.dustSensor);
        console.log(this.lightSensor);
        console.log(this.conductivitySensor);
        console.log(this.waterSensor);
    }

}
