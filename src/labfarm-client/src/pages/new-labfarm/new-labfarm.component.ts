import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { NewLabfarm } from 'src/models/NewLabfarm';
import { Router } from '@angular/router';

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

    private labfarmForm: FormGroup;

    private savingLabfarm: boolean = false;
    private inputError: boolean = false;

    constructor(private authService: AuthenticationService, private labfarmService: LabfarmService, private router: Router) {
    }

    ngOnInit() {



    }

    private checkLabFarm() {
        this.inputError = false;

        this.labfarmForm = new FormGroup({
            'name': new FormControl(this.name, [
                Validators.required,
                Validators.minLength(4)
            ]),
            'plantSpecies': new FormControl(this.plantSpecies, [
                Validators.required,
                Validators.minLength(4)
            ]),
            'dustLow': new FormControl(this.dustLow, Validators.required),
            'dustHigh': new FormControl(this.dustHigh, Validators.required),
            'lightLow': new FormControl(this.lightLow, Validators.required),
            'lightHigh': new FormControl(this.lightHigh, Validators.required),
            'tempLow': new FormControl(this.tempLow, Validators.required),
            'tempHigh': new FormControl(this.tempHigh, Validators.required),
            'condLow': new FormControl(this.condLow, Validators.required),
            'condHigh': new FormControl(this.condHigh, Validators.required),
            'waterLow': new FormControl(this.waterLow, Validators.required),
            'waterHigh': new FormControl(this.waterHigh, Validators.required)
        });


        if (this.labfarmForm.valid)
            this.saveLabFarm();
        else 
           this.invalidFormInput(); 
    }

    private invalidFormInput(){
        console.log("New labfarm input is invalid");
        this.inputError = true;
    }

    private saveLabFarm() {
        console.log("New labfarm input is valid, sending it to the API");

        let newLabFarm: NewLabfarm = {
            AuthId: this.authService.getAuthId(),
            Name: this.name,
            PlantSpecies: this.plantSpecies,
            DustLevelHigh: this.dustHigh,
            DustLevelLow: this.dustLow,
            LightLevelHigh: this.lightHigh,
            LightLevelLow: this.lightLow,
            TemperatureLevelHigh: this.tempHigh,
            TemperatureLevelLow: this.tempLow,
            ConductivityLevelHigh: this.condHigh,
            ConductivityLevelLow: this.condLow,
            MaximumReservoirLevel: this.waterHigh,
            MinimumReservoirLevel: this.waterLow,
            autoMode: false,
            plants: [],
            sensors: []
        }
        console.log(JSON.stringify(newLabFarm));

        this.savingLabfarm = true;
        this.labfarmService.postLabFarm(newLabFarm).subscribe(success => {
            console.log(success);
            this.router.navigate(['/home']);
        }, error => {
            console.log(error);
        });
        
    }

}
