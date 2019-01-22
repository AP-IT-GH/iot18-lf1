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


    private authid: string;

    // 'Authorization': `Bearer ${this.authenticationService.getAccessToken()}`

    private userLabFarms: LabFarm[];
    private sensorTypes: SensorType[];
    private sensorDatas: SensorData[];

    constructor(private http: HttpClient, private authenticationService: AuthenticationService) {
        this.authid = this.authenticationService.getAuthId();
    }

    getUserLabFarms(): Observable<LabFarm[]> {
        console.log("Getting labfarms for user " + this.authid);

        return this.http.get<LabFarm[]>(`/labfarm?authid=${this.authid}`);
    }

    getLabFarmById(id: number): Observable<LabFarm> {
        console.log("Getting labfarm with id: ${id}");

        return this.http.get<LabFarm>(`/labfarm/${id}`);
    }

    getSensorValues(sensorId: number, amount: number = 12): Observable<LastSensorValues> {
        console.log("Getting last " + amount + " values for sensor #" + sensorId);

        return this.http.get<LastSensorValues>(`/sensor/${sensorId}/values?count=${amount}`);
    }

    postLabFarm(newLabfarm: NewLabfarm): Observable<NewLabfarm> {
        console.log("Saving new labfarm " + newLabfarm.Name + " to the API");

        return this.http.post<NewLabfarm>('/labfarm', newLabfarm);
    }

    updateLabFarm(lf: LabFarm, labfarmId: number): Observable<LabFarm> {
        console.log("Updating labfarm " + lf.name + " to the API");

        return this.http.put<LabFarm>(`/labfarm/${labfarmId}`, lf);
    }

    deleteLabFarm(labfarmId: number): Observable<Boolean> {
        console.log("Deleting labfarm with ID: " + labfarmId);

        return this.http.delete<Boolean>(`/labfarm/${labfarmId}`);
    }

    getPictures(plantId: number, startDate: Date, pictureCount: number, pageSize: number, pageCount: number): Observable<Picture[]> {
        console.log(`Getting ${pictureCount} pictures of plant ${plantId}`);

        let tempDate = new Date(startDate);

        let queryString = `/plant/${plantId}/pictures?startDate=${tempDate.getTime()}&hours=${pictureCount}&page=${pageCount}&pageSize=${pageSize}`;
        // let queryString = `/plant/${plantId}/pictures?skip=${pageCount - 1}&take=${pageSize}`;

        console.log(queryString);

        return this.http.get<Picture[]>(queryString);
    }

    updatePicture(p: Picture): Observable<Picture> {
        console.log("Updating picture with ID " + p.id);

        return this.http.put<Picture>(`/picture/${p.id}`, p);
    }
    deletePicture(p: Picture): Observable<Picture> {
        console.log("Deleting picture with ID " + p.id);

        return this.http.delete<Picture>(`/picture/${p.id}`);
    }

    public getLatestSensorData(): SensorData[] {
        return this.sensorDatas;
    }

}
