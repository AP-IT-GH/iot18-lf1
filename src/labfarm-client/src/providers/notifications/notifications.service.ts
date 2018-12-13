import { Injectable } from '@angular/core';
import { NotificationUrgency } from 'src/models/NotificationUrgency';
import { Notification } from 'src/models/Notification';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';
import { P } from '@angular/core/src/render3';

@Injectable({
    providedIn: 'root'
})
export class NotificationsService {

    private notifications: Notification[] = [];


    constructor(private http: HttpClient, private auth: AuthenticationService) {
        this.initDemoNotifications();
    }

    public initDemoNotifications() {
        this.notifications.push({
            id: 1,
            authId: "admin",
            title: "Notification 1 header",
            body: "Notification with low urgency, we're adding some extra text to see what it looks like when this hits another line",
            linkToUrl: "/home",
            urgency: NotificationUrgency.Low
        });

        this.notifications.push({
            id: 2,
            authId: "admin",
            title: "Notification 2 header",
            body: "Notification with normal urgency",
            // linkToUrl: "/home",
            linkToUrl: null,
            urgency: NotificationUrgency.Normal
        });

        this.notifications.push({
            id: 3,
            authId: "admin",
            title: "Notification 3 header",
            body: "Notification with high urgency",
            linkToUrl: "/home",
            urgency: NotificationUrgency.High
        });
        this.notifications.push({
            id: 4,
            authId: "admin",
            title: "Notification 4 header",
            body: "Notification with extreme urgency",
            //   linkToUrl: "/home",
            linkToUrl: null,
            urgency: NotificationUrgency.Extreme
        });
        // this.notifications.push({
        //     id: 5,
        //     authId: "admin",
        //     title: "Notification 5 header",
        //     body: "Notification with normal urgency",
        //     linkToUrl: "/home",
        //     // linkToUrl: null,
        //     urgency: NotificationUrgency.Normal
        // });

        // this.notifications.push({
        //     id: 6,
        //     authId: "admin",
        //     title: "Notification 6 header",
        //     body: "Notification with normal urgency",
        //     // linkToUrl: "/home",
        //     linkToUrl: null,
        //     urgency: NotificationUrgency.Normal
        // });
    }

    public initNotifications() {
        this.notifications.forEach(n => {
            this.addNotification(n);
        })
    }

    public getNotifications(): Notification[] {
        return this.notifications;
    }

    public getRealNotifications(): Observable<Notification[]> {
        console.log("Getting notifications for user " + this.auth.getAuthId());

        return this.http.get<Notification[]>(`/notification/${this.auth.getAuthId()}`);
    }

    public deleteNotification(id: number): Observable<boolean> {
        console.log("Deleting notification with ID: " + id);

        return this.http.delete<boolean>(`/notification/${id}`);
    }

    public addNotification(n: Notification): Observable<Notification> {
        console.log("Adding a new notification for user " + this.auth.getAuthId());

        return this.http.post<Notification>(`/notification`, n);
    }

    public remove(notification: Notification): Observable<boolean> {
        console.log("Removing notification from the list");

        let observable = this.deleteNotification(notification.id);
        observable.subscribe(data => {
            this.notifications.splice(this.notifications.indexOf(notification), 1);
        })
        return observable;
    }


}
