import { Component, OnInit } from '@angular/core';
import {MatSliderModule} from '@angular/material/slider';
import * as hammerjs from 'hammerjs/hammer';

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

    constructor() { }

    ngOnInit() { }

    autoModeChanged() {
        this.lightDisabled = !this.autoMode;
        this.conductivityDisabled = !this.autoMode;
    }

}
