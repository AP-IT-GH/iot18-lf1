import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';
import { LabfarmConfigService } from 'src/providers/labfarm-config/labfarm-config.service';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-options',
    templateUrl: './options.component.html',
    styleUrls: ['./options.component.scss']
})
export class OptionsComponent implements OnInit {

    private notificationTitle: string = "Browser Push Notifications!";

    private cookieValue = "UNKNOWN";

    private preferences: boolean;

    constructor(private cookieService: CookieService, private authService: AuthenticationService, private toastr: ToastrService) {
    }

    ngOnInit() {
        let preferencesCookie = this.cookieService.get('receiveNotifications');

        if (preferencesCookie)
            this.preferences = JSON.parse(preferencesCookie);
    }

    toggleNotifications(event) {
        
    }

    savePreferences() {
        this.cookieService.set('receiveNotifications', "" + this.preferences);
        this.toastr.success('Successfully saved preferences', 'Success!', {
            easeTime: 300,
            positionClass: 'toast-top-center',
            // disableTimeOut: true
        });
    }

}
