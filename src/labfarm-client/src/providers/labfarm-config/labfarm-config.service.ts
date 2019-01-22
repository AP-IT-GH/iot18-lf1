import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class LabfarmConfigService {

    private labfarmConfigFile = 'src/assets/labfarm-config.json';
    private labfarmConfig: LabfarmConfig;

    constructor(private http: HttpClient) {
        this.loadConfig();
    }

    private loadConfig() {
        this.http.get(this.labfarmConfigFile).toPromise().then((config : LabfarmConfig) => {
            this.labfarmConfig = config;
            console.log("Config loaded: " + this.labfarmConfig);
        }).catch((response: any) => {
            console.log(response);
        })


    }

    private saveConfig(cfg: LabfarmConfig) {
        this.http.post(this.labfarmConfigFile, cfg).subscribe(config => {
            console.log(config);
        })
    }
}

export interface LabfarmConfig {
    ReceiveNotifications: boolean;
}
