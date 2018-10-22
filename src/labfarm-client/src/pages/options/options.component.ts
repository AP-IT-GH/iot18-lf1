import { Component, OnInit } from '@angular/core';
import { PushNotificationsService } from 'src/providers/push-notifications/push-notifications.service';

@Component({
    selector: 'app-options',
    templateUrl: './options.component.html',
    styleUrls: ['./options.component.scss']
})
export class OptionsComponent implements OnInit {

    private notificationTitle: string = "Browser Push Notifications!";

    private preferences_lf123: boolean = false;
    private preferences_lf124: boolean = false;

    constructor(private notificationService: PushNotificationsService) {
        
     }

    ngOnInit() {
    }

    notify() {
        let data: Array <any> = [];
        data.push({
            'title': 'Lab farm warning!',
            'alertContent': 'Be wary, the light intensity level of Labfarm 123 is low!'
        });

        this.notificationService.generateNotification(data);
    }

    toggleNotifications(event) {
        if(!this.preferences_lf123 || !this.preferences_lf124){
            console.log("Requesting permission");
            this.notificationService.requestPermission();

        }
    }

    savePreferences() {
        this.notify();
    }

}
