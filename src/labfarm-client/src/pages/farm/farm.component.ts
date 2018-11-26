import { Component, OnInit } from '@angular/core';
import { MatSliderModule } from '@angular/material/slider';
import * as hammerjs from 'hammerjs/hammer';
import { LabFarm } from 'src/models/LabFarm';
import { SensorData } from 'src/models/SensorData';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { ActivatedRoute } from '@angular/router';
import { Sensor } from 'src/models/Sensor';

@Component({
    selector: 'app-farm',
    templateUrl: './farm.component.html',
    styleUrls: ['./farm.component.scss']
})
export class FarmComponent implements OnInit {

    public serverError: boolean = false;

    public autoMode = true;

    public farmId: number;
    public labfarm: LabFarm;

    public lightLevel = 160;
    public lightDisabled = true;
    public conductivityLevel = 60;
    public conductivityDisabled = true;

    public labFarm: LabFarm;
    public sensors: Sensor[];

    public lastUpdate: Date;
    public lastPicture: string;

    constructor(private route: ActivatedRoute, private labfarmService: LabfarmService) {

    }

    ngOnInit() {
        this.farmId = parseInt(this.route.snapshot.paramMap.get("id"));
        this.labfarmService.getLabFarmById(this.farmId).subscribe(data => {
            this.labfarm = data;
            this.sensors = data.sensors;

            this.setLastUpdated();
            this.setPictures();

        }, error => {
            this.serverError = true;
        });

    }

    setLastUpdated() {
        this.lastUpdate = new Date();
        if (this.labfarm.sensors[0])
            if (this.labfarm.sensors[0].sensorValues[0])
                this.lastUpdate = this.labfarm.sensors[0].sensorValues[0].timeStamp

    }

    setPictures() {
        if (this.labfarm.plants[0])
            if (this.labfarm.plants[0].pictures)
                this.lastPicture = this.labfarm.plants[0].pictures[0].content;

    }

    autoModeChanged() {
        this.lightDisabled = !this.autoMode;
        this.conductivityDisabled = !this.autoMode;
    }

}
