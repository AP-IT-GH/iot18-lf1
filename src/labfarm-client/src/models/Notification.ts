import { NotificationUrgency } from "./NotificationUrgency";

export interface Notification {
    id: number,
    AuthId: string,
    Title: string,
    Body: string,
    LinkToUrl: string,
    Urgency: NotificationUrgency
}