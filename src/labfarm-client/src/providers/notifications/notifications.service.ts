import { Injectable } from '@angular/core';
import { NotificationUrgency } from 'src/models/NotificationUrgency';
import { Notification } from 'src/models/Notification';

@Injectable({
    providedIn: 'root'
})
export class NotificationsService {

    private notifications: Notification[] = [];



    constructor() {
        this.initDemoNotifications();
    }

    public initDemoNotifications() {
        this.notifications.push({
            id: 1,
            title: "Notification 1 header",
            body: "Notification with low urgency",
            linkToUrl: "/home",
            urgency: NotificationUrgency.Low
        });

        this.notifications.push({
            id: 2,
            title: "Notification 2 header",
            body: "Notification with normal urgency",
            // linkToUrl: "/home",
            linkToUrl: null,
            urgency: NotificationUrgency.Normal
        });

        this.notifications.push({
            id: 3,
            title: "Notification 3 header",
            body: "Notification with high urgency",
            linkToUrl: "/home",
            urgency: NotificationUrgency.High
        });
        this.notifications.push({
            id: 4,
            title: "Notification 4 header",
            body: "Notification with extreme urgency",
            //   linkToUrl: "/home",
            linkToUrl: null,
            urgency: NotificationUrgency.Extreme
        });
        // this.notifications.push({
        //     id: 5,
        //     title: "Notification 5 header",
        //     body: "Notification with normal urgency",
        //     linkToUrl: "/home",
        //     // linkToUrl: null,
        //     urgency: NotificationUrgency.Normal
        // });

        // this.notifications.push({
        //     id: 6,
        //     title: "Notification 6 header",
        //     body: "Notification with normal urgency",
        //     // linkToUrl: "/home",
        //     linkToUrl: null,
        //     urgency: NotificationUrgency.Normal
        // });
    }

    public getNotifications(): Notification[] {
        return this.notifications;
    }

    public remove(notification: Notification): boolean {
        this.notifications.splice(this.notifications.indexOf(notification), 1);
        return true;
    }


}
