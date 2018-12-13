import { Component, OnInit } from '@angular/core';
import { NotificationsService } from 'src/providers/notifications/notifications.service';

@Component({
    selector: 'app-lf-navbar',
    templateUrl: './lf-navbar.component.html',
    styleUrls: ['./lf-navbar.component.scss']
})
export class LfNavbarComponent implements OnInit {

    constructor(private notificationService: NotificationsService) { }

    ngOnInit() {
    }

}
