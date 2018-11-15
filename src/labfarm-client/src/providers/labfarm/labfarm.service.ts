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
