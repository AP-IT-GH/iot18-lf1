import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class InterceptorService implements HttpInterceptor {

    private apiVersion = '1.1';
    // private baseUrl = "http://labfarmwebapp.azurewebsites.net/api/v1";
    private baseUrl = "https://labfarm-iot.azurewebsites.net/api/v1";

    constructor(
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        });

        if(!request.url.includes("/assets/"))
            request = request.clone({ url: `${this.baseUrl}${request.url}`, headers: headers });

        return next.handle(request);
    }
}