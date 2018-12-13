import { Injectable } from '@angular/core';
import { NotificationUrgency } from 'src/models/NotificationUrgency';
import { Notification } from 'src/models/Notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  private notifications: Notification[] = [];



  constructor() {

    this.notifications.push({
      id: 1,
      title: "Notification 1 header",
      body: "Lorem ipsum dolor set amet..",
      linkToUrl: "/home",
      urgency: NotificationUrgency.Low
    });

    this.notifications.push({
      id: 2,
      title: "Notification 2 header",
      body: "Lorem ipsum dolor set amet..",
      linkToUrl: "/home",
      urgency: NotificationUrgency.Medium
    });

    this.notifications.push({
      id: 3,
      title: "Notification 3 header",
      body: "Lorem ipsum dolor set amet..",
      linkToUrl: "/home",
      urgency: NotificationUrgency.High
    });
    this.notifications.push({
      id: 4,
      title: "Notification 4 header",
      body: "Lorem ipsum dolor set amet..",
      linkToUrl: "/home",
      urgency: NotificationUrgency.Extreme
    });
  }

  public GetNotifications(): Notification[] {
    return this.notifications;
  }


}
