import { Injectable } from '@angular/core';
import *  as auth0 from 'auth0-js';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {

    auth0 = new auth0.WebAuth({
        clientID: 'PECk3b50RvqOmI67NRkI017KaJ2pVfPp',
        domain: 'melvinb.eu.auth0.com',
        responseType: 'token id_token',
        redirectUri: 'http://localhost:4200/#/callback',
        scope: 'openid'
    });

    constructor(private router: Router) {

    }

    public static get_auth_token(): string {
        return localStorage.getItem('access_token');
    }

    public getAuthId(): string {
        return "Test admin";
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
            this.router.navigate(['/home']);
        });
    }

    public login(): void {
        this.auth0.authorize();
    }

    public logout(): void {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
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
    }
}