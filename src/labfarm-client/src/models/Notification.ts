import { NotificationUrgency } from "./NotificationUrgency";

export interface Notification {
    Id: number,
    AuthId: string,
    Title: string,
    Body: string,
    LinkToUrl: string,
    Urgency: NotificationUrgency
}