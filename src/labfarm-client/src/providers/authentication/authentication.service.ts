import { Injectable } from '@angular/core';
import *  as auth0 from 'auth0-js';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {

    auth0 = new auth0.WebAuth({
        clientID: 'PECk3b50RvqOmI67NRkI017KaJ2pVfPp',
        domain: 'melvinb.eu.auth0.com',
        responseType: 'token id_token',
        redirectUri: 'http://localhost:4200/callback',
        scope: 'openid'
    });

    constructor(private router: Router) {

    }

    public getAccessToken(): string {
        return localStorage.getItem('access_token');
    }

    public getAuthId(): string {
        // return "Test admin";
        return "admin";
    }
    
    public getRealAuthId(): string {
        return localStorage.getItem('auth_id');
    }

    public handleAuthentication(): void {
        this.auth0.parseHash((err, authResult) => {
            console.log(authResult);
            if (authResult && authResult.accessToken && authResult.idToken) {
                window.location.hash = '';
                this.setSession(authResult);
                this.reload();
            } else if (err) {
                console.log(err);
            }
            let url = localStorage.getItem('lastPage') ? localStorage.getItem('lastPage') : '/home';

            this.router.navigate([url]);
        });
    }

    public login(): void {
        localStorage.setItem('lastPage', this.router.url);
        console.log(localStorage.getItem('lastPage'));
        this.auth0.authorize();
    }

    public logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
        localStorage.removeItem('auth_id');
        // Go back to the home route
        this.router.navigate(['/']);
    }

    public isAuthenticated(): boolean {
        const expiresAt = JSON.parse(localStorage.getItem('expires_at') || '{}');
        return new Date().getTime() < expiresAt;
    }

    private reload(): void {
        window.location.reload();
    }

    private setSession(authResult): void {
        // Set the time that the Access Token will expire at
        const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
        localStorage.setItem('access_token', authResult.accessToken);
        localStorage.setItem('id_token', authResult.idToken);
        localStorage.setItem('expires_at', expiresAt);
        localStorage.setItem('auth_id', authResult.idTokenPayload.sub);
    }
}