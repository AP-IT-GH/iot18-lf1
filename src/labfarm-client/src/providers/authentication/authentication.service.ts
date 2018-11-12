import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    private auth_id = "Test admin";

    constructor() { }

    public getAuthId(): string {
        return this.auth_id;
    }
}
