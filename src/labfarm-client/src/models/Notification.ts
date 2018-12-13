import { NotificationUrgency } from "./NotificationUrgency";

export interface Notification {
    id: number,
    title: string,
    body: string,
    linkToUrl: string,
    urgency: NotificationUrgency
}