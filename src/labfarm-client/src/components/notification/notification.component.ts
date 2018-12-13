import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Notification } from 'src/models/Notification';
import { NgbPopover } from '@ng-bootstrap/ng-bootstrap';
import { NotificationsService } from 'src/providers/notifications/notifications.service';

@Component({
    selector: 'app-notification',
    templateUrl: './notification.component.html',
    styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {

    @Input() notification: Notification;
    @Input() popover: NgbPopover;

    constructor(private notificationService: NotificationsService) { }

    ngOnInit() {

    }

    private remove() {
        this.notificationService.remove(this.notification);
        this.popover.open();
        setTimeout(() => {
            this.popover.open();
        });
    }


}
