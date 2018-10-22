import { Injectable } from '@angular/core';
import { PushNotification } from 'src/models/PushNotification';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class PushNotificationsService {
    public permission: Permission;

    constructor() { 
        this.permission = this.isSupported() ? 'default' : 'denied';
    }

    public isSupported(): boolean {
        return 'Notification' in window;
    }

    public requestPermission(): void {
        let self = this;
        if(this.isSupported()) {
            Notification.requestPermission(function(status) {
                return self.permission = status;
            })
        } else {
            console.log("Notifications are not supported by this browser");
        }
    }

    public create(title: string, options ? : PushNotification): any {
        let self = this;
        return new Observable(function(obs) {
            if (!('Notification' in window)) {
                console.log("Notifications are not available in this environment");
                obs.complete();
            }
            if (self.permission !== 'granted') {
                console.log("The user hasn't granted you permission to send push notifications");
                obs.complete();
            }
            let _notify = new Notification(title, options);
            _notify.onshow = function(e) {
                return obs.next({
                    notification: _notify,
                    event: e
                });
            };
            _notify.onclick = function(e) {
                return obs.next({
                    notification: _notify,
                    event: e
                });
            };
            _notify.onerror = function(e) {
                return obs.error({
                    notification: _notify,
                    event: e
                });
            };
            _notify.onclose = function() {
                return obs.complete();
            };

        })
    }

    public generateNotification(source: Array <any>): void {
        let self = this;
        source.forEach((item) => {
            let options = {
                body: item.alertContent,
                icon: "assets/images/leaf.png",
            };
            let notify = self.create(item.title, options).subscribe();
        })
    }
}


export declare type Permission = 'denied' | 'granted' | 'default';