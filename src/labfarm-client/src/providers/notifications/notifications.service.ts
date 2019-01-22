import { Injectable, OnInit } from '@angular/core';
import { NotificationUrgency } from 'src/models/NotificationUrgency';
import { Notification } from 'src/models/Notification';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../authentication/authentication.service';
import { P } from '@angular/core/src/render3';
import { NewNotification } from 'src/models/NewNotification';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
    providedIn: 'root'
})
export class NotificationsService  {

    private notifications: Notification[] = [];

    public notificationsToggled: boolean = true;


    constructor(private http: HttpClient, private auth: AuthenticationService, private cookieService: CookieService) {
        // this.initDemoNotifications();
        this.checkForPreferences();
    }

    public checkForPreferences() {
        this.notificationsToggled =  JSON.parse(this.cookieService.get('receiveNotifications'));

        if(this.notificationsToggled)
            this.checkForNotifications();

    }

    public initDemoNotifications() {
        this.addNotification({
            AuthId: "admin",
            Title: "Notification 1 header",
            Body: "Notification with low urgency, we're adding some extra text to see what it looks like when this expands to other lines",
            LinkToUrl: "/home",
            Urgency: NotificationUrgency.Low
        }).subscribe(success => {
            console.log(success);
        }, error => {
            console.log(error);
        });
        this.addNotification({
            AuthId: "admin",
            Title: "Notification 2 header",
            Body: "Notification with normal urgency",
            // linkToUrl: "/home",
            LinkToUrl: null,
            Urgency: NotificationUrgency.Normal
        }).subscribe(success => {
            console.log(success);
        }, error => {
            console.log(error);
        });
        this.addNotification({
            AuthId: "admin",
            Title: "Notification 3 header",
            Body: "Notification with high urgency",
            LinkToUrl: "/home",
            Urgency: NotificationUrgency.High
        }).subscribe(success => {
            console.log(success);
        }, error => {
            console.log(error);
        });
        this.addNotification({
            AuthId: "admin",
            Title: "Notification 4 header",
            Body: "Notification with extreme urgency",
            //   linkToUrl: "/home",
            LinkToUrl: null,
            Urgency: NotificationUrgency.Extreme
        }).subscribe(success => {
            console.log(success);
        }, error => {
            console.log(error);
        });
        this.addNotification({
            AuthId: "admin",
            Title: "Notification 5 header",
            Body: "Notification with extreme urgency",
            //   linkToUrl: "/home",
            LinkToUrl: null,
            Urgency: NotificationUrgency.Extreme
        }).subscribe(success => {
            console.log(success);
        }, error => {
            console.log(error);
        });
        this.addNotification({
            AuthId: "admin",
            Title: "Notification 6 header",
            Body: "Notification with normal urgency",
            // linkToUrl: "/home",
            LinkToUrl: null,
            Urgency: NotificationUrgency.Normal
        }).subscribe(success => {
            console.log(success);
        }, error => {
            console.log(error);
        });

        
    }

    public initNotifications() {
        this.notifications.forEach(n => {
            this.addNotification(n).subscribe(success => {

            }, error => {
                console.log(error);
            });
        })
    }

    public checkForNotifications() {
        this.getRealNotifications().subscribe(data => {
            console.log(`Got ${data.length} notifications`);
            this.notifications = data;
            this.notifications = this.notifications.sort(this.notificationSort);
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

    public addNotification(n: NewNotification): Observable<Notification> {
        console.log("Adding a new notification for user " + this.auth.getAuthId());

        return this.http.post<Notification>(`/notification`, n);
    }

    public remove(notification: Notification): Observable<boolean> {
        console.log("Removing notification from the list");
        console.log(notification);
        this.notifications.splice(this.notifications.indexOf(notification), 1);
        return this.deleteNotification(notification.id);
    }

    notificationSort(n1: Notification, n2: Notification): number {
        // console.log("sorting")
        if (n1.Urgency < n2.Urgency)
            return -1;

        if (n1.Urgency > n1.Urgency)
            return 1;

        return 0;
    }


}
