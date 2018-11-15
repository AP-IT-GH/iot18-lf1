import { Component, OnInit } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { LabFarmDto } from 'src/models/LabFarmDto';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';

@Component({
    selector: 'app-new-labfarm',
    templateUrl: './new-labfarm.component.html',
    styleUrls: ['./new-labfarm.component.scss']
})
export class NewLabfarmComponent implements OnInit {

    private name: string;
    private plantSpecies: string;
    private dustLow: number;
    private dustHigh: number;
    private lightLow: number;
    private lightHigh: number;
    private tempLow: number;
    private tempHigh: number;
    private condLow: number;
    private condHigh: number;
    private waterLow: number;
    private waterHigh: number;


    constructor(private authService: AuthenticationService) { 
    }

    ngOnInit() {

    }

    private saveLabFarm(){
        let newLabFarm: LabFarmDto = {
            id: null,
            authId: this.authService.getAuthId(),
            name: this.name,
            plantSpecies: this.plantSpecies,
            dustLevelHigh: this.dustHigh,
            dustLevelLow: this.dustLow,
            lightLevelHigh: this.lightHigh,
            lightLevelLow: this.lightLow,
            temperatureLevelHigh: this.tempHigh,
            temperatureLevelLow: this.tempLow,
            conductivityLevelHigh: this.condHigh,
            conductivityLevelLow: this.condLow,
            maximumReservoirLevel: this.waterHigh,
            minimumReservoirLevel: this.waterLow,
            autoMode: false,
            plants: [],
            sensors: []            
        }

        

        console.log(newLabFarm);
    }

}
