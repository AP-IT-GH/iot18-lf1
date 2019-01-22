import { NotificationUrgency } from "./NotificationUrgency";

export interface NewNotification {
    AuthId: string,
    Title: string,
    Body: string,
    LinkToUrl: string,
    Urgency: NotificationUrgency
}