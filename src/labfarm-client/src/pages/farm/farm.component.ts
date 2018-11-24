import { Component, OnInit } from '@angular/core';
import { MatSliderModule } from '@angular/material/slider';
import * as hammerjs from 'hammerjs/hammer';
import { LabFarm } from 'src/models/LabFarm';
import { SensorData } from 'src/models/SensorData';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { ActivatedRoute, Router } from '@angular/router';
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

    constructor(private route: ActivatedRoute, private labfarmService: LabfarmService, private router: Router) {

    }

    ngOnInit() {
        this.farmId = parseInt(this.route.snapshot.paramMap.get("id"));
        this.labfarmService.getLabFarmById(this.farmId).subscribe(data => {
            this.labfarm = data;
            this.sensors = data.sensors;
        }, error => {
            this.serverError = true;
        });
    }

    autoModeChanged() {
        this.lightDisabled = !this.autoMode;
        this.conductivityDisabled = !this.autoMode;
    }

    editLabfarm() {
        this.router.navigate(['/farm/' + this.farmId + '/edit'])
    }
}
