import { Injectable } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { SensorType } from 'src/models/SensorType';
import { SensorData } from 'src/models/SensorData';
import { AuthenticationService } from '../authentication/authentication.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LabFarmDto } from 'src/models/LabFarmDto';
import { SensorValue, LastSensorValues } from 'src/models/SensorValue';

@Injectable({
    providedIn: 'root'
})
export class LabfarmService {

    private baseUrl = "http://labfarmwebapp.azurewebsites.net/api/v1";
    private authid: string;
    // private httpOptions = {
    //     headers: new HttpHeaders({
    //         'Content-Type': 'application/json',
    //         'Authorization': `Bearer ${this.auth.access_token}`
    //     })
    // }


    private userLabFarms: LabFarm[];
    private sensorTypes: SensorType[];
    private sensorDatas: SensorData[];

    constructor(private http: HttpClient, private authenticationService: AuthenticationService) {
        this.authid = this.authenticationService.getAuthId();

        // this.sensorTypes = [
        //     {
        //         TypeId: 1,
        //         TypeName: "Humidity"
        //     },
        //     {
        //         TypeId: 2,
        //         TypeName: "Dust"
        //     },
        //     {
        //         TypeId: 3,
        //         TypeName: "Light"
        //     },
        //     {
        //         TypeId: 4,
        //         TypeName: "Conductivity"
        //     },
        //     {
        //         TypeId: 5,
        //         TypeName: "Water level"
        //     }
        // ];
        // this.labFarms = [
        //     {
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
        //     },
        //     {
        //         LabFarmId: 124,
        //         AuthId: "abc124",
        //         PlantSpecies: "Tomato",
        //         DustLevelHigh: 22,
        //         DustLevelLow: 12,
        //         LightLevelHigh: 240,
        //         LightLevelLow: 160,
        //         HumidityLevelHigh: 7.8,
        //         HumidityLevelLow: 4.3,
        //         ConductivityLevelHigh: 5.5,
        //         ConductivityLevelLow: 4.3,
        //         MinimumReservoirLevel: 5,
        //         MaximumReservoirLevel: 80
        //     }
        // ];
        // this.sensorDatas = [
        //     {
        //         SensorId: 1,
        //         LabFarm: this.labFarms[0],
        //         SensorType: this.sensorTypes[0],
        //         SensorValue: 8.2,
        //         Timestamp: "01/08/18 14:16:59"
        //     },
        //     {
        //         SensorId: 2,
        //         LabFarm: this.labFarms[0],
        //         SensorType: this.sensorTypes[1],
        //         SensorValue: 4.2,
        //         Timestamp: "01/08/18 14:16:59"
        //     },
        //     {
        //         SensorId: 3,
        //         LabFarm: this.labFarms[0],
        //         SensorType: this.sensorTypes[2],
        //         SensorValue: 5.7,
        //         Timestamp: "01/08/18 14:16:59"
        //     },
        //     {
        //         SensorId: 4,
        //         LabFarm: this.labFarms[0],
        //         SensorType: this.sensorTypes[3],
        //         SensorValue: 2.1,
        //         Timestamp: "01/08/18 14:16:59"
        //     },
        //     {
        //         SensorId: 5,
        //         LabFarm: this.labFarms[0],
        //         SensorType: this.sensorTypes[4],
        //         SensorValue: 50,
        //         Timestamp: "01/08/18 14:16:59"
        //     }
        // ]
    }

    getUserLabFarms(): Observable<LabFarmDto[]> {
        console.log("Getting labfarms for user " + this.authid);
        let queryString = this.baseUrl;
        queryString += "/labfarm";
        queryString += "?authid=" + this.authid;

        // console.log(queryString);
        return this.http.get<LabFarmDto[]>(queryString);
    }

    getLabFarm(id: number): Observable<LabFarmDto> {
        console.log("Getting labfarm with id: ${id}");
        let queryString = this.baseUrl;
        queryString += "/labfarm";
        queryString += "/" + id;

        return this.http.get<LabFarmDto>(queryString);
    }

    // getSensorValues(sensorId: number)
    getSensorValues(sensorId: number, amount: number = 12): Observable<LastSensorValues> {
        console.log("Getting last " + amount + " values for sensor #" + sensorId);
        let queryString = this.baseUrl;
        queryString += "/sensor";
        queryString += `/${sensorId}`;
        queryString += "/values"
        queryString += "?count=" + amount;

        return this.http.get<LastSensorValues>(queryString);
    }

    public getLatestSensorData(): SensorData[] {
        return this.sensorDatas;
    }

}
