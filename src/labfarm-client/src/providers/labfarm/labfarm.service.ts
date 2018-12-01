import { Injectable } from '@angular/core';
import { LabFarm } from 'src/models/LabFarm';
import { SensorType } from 'src/models/SensorType';
import { SensorData } from 'src/models/SensorData';
import { AuthenticationService } from '../authentication/authentication.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SensorValue, LastSensorValues } from 'src/models/SensorValue';
import { NewLabfarm } from 'src/models/NewLabfarm';
import { Picture } from 'src/models/Picture';

@Injectable({
    providedIn: 'root'
})
export class LabfarmService {

    // private baseUrl = "http://labfarmwebapp.azurewebsites.net/api/v1";
    private baseUrl = "http://labfarm-iot-hub-v3.azurewebsites.net/api/v1";
    private authid: string;
    
    private httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
            // 'Authorization': `Bearer ${this.auth.access_token}`
        })
    }


    private userLabFarms: LabFarm[];
    private sensorTypes: SensorType[];
    private sensorDatas: SensorData[];

    constructor(private http: HttpClient, private authenticationService: AuthenticationService) {
        this.authid = this.authenticationService.getAuthId();
    }

    getUserLabFarms(): Observable<LabFarm[]> {
        console.log("Getting labfarms for user " + this.authid);
        let queryString = this.baseUrl;
        queryString += "/labfarm";
        queryString += "?authid=" + this.authid;

        console.log(queryString);
        return this.http.get<LabFarm[]>(queryString);
    }

    getLabFarmById(id: number): Observable<LabFarm> {
        console.log("Getting labfarm with id: ${id}");
        let queryString = this.baseUrl;
        queryString += "/labfarm";
        queryString += "/" + id;

        return this.http.get<LabFarm>(queryString);
    }

    getSensorValues(sensorId: number, amount: number = 12): Observable<LastSensorValues> {
        console.log("Getting last " + amount + " values for sensor #" + sensorId);
        let queryString = this.baseUrl;
        queryString += "/sensor";
        queryString += `/${sensorId}`;
        queryString += "/values"
        queryString += "?count=" + amount;

        return this.http.get<LastSensorValues>(queryString);
    }

    postLabFarm(newLabfarm: NewLabfarm): Observable<NewLabfarm>{
        console.log("Saving new labfarm " + newLabfarm.Name + " to the API");
        let queryString = this.baseUrl;
        queryString += "/labfarm";

        console.log(queryString);
        return this.http.post<NewLabfarm>(queryString, newLabfarm, this.httpOptions);
    }

    updateLabFarm(lf: LabFarm, labfarmId: number): Observable<LabFarm>{
        console.log("Updating labfarm " + lf.name + " to the API");
        let queryString = this.baseUrl;
        queryString += "/labfarm/" + labfarmId;

        console.log(queryString);
        return this.http.put<LabFarm>(queryString, lf, this.httpOptions);
    }

    deleteLabFarm(labfarmId: number): Observable<Boolean> {
        console.log("Deleting labfarm with ID: " + labfarmId);
        let queryString = this.baseUrl;
        queryString += "/labfarm/" + labfarmId;

        return this.http.delete<Boolean>(queryString, this.httpOptions);
    }

    getPictures(): Observable<Picture[]> {
        console.log("Getting all pictures");
        let queryString = this.baseUrl;
        queryString += "/picture";

        return this.http.get<Picture[]>(queryString, this.httpOptions);
    }

    updatePicture(p: Picture): Observable<Picture> {
        console.log("Updating picture with ID " + p.id);
        let queryString = this.baseUrl;
        queryString += "/picture/" + p.id;

        return this.http.put<Picture>(queryString, this.httpOptions);
    }
    deletePicture(p: Picture): Observable<Picture> {
        console.log("Deleting picture with ID " + p.id);
        let queryString = this.baseUrl;
        queryString += "/picture/" + p.id;

        return this.http.delete<Picture>(queryString, this.httpOptions);
    }

    public getLatestSensorData(): SensorData[] {
        return this.sensorDatas;
    }

}
