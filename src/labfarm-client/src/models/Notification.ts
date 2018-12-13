import { NotificationUrgency } from "./NotificationUrgency";

export interface Notification {
    id: number,
    authId: string,
    title: string,
    body: string,
    linkToUrl: string,
    urgency: NotificationUrgency
}