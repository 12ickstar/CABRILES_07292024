import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    let modifiedRequest = request.clone({
      url: `${environment.baseApiUrl}/${request.url}`
    });
    if (!(request.body instanceof FormData)) {
      modifiedRequest = modifiedRequest.clone({
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        })
      });
    }

    return next.handle(modifiedRequest);
  }
}
