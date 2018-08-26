import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable()
export class CustomInterceptor implements HttpInterceptor {

    private commonUrl: string = "http://localhost:59642/api/";

    intercept(req: HttpRequest<any>, next: HttpHandler):
        Observable<HttpEvent<any>> {

        const completeReq = req.clone({
            url:  this.commonUrl + req.url
        });
        return next.handle(completeReq);
    }
}

export const httpInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: CustomInterceptor, multi: true },
];