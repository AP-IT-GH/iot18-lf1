import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

    private authId: string;

    constructor(private authService: AuthenticationService) {

    }

    ngOnInit() {
        this.authId = this.authService.getRealAuthId();
    }

}
