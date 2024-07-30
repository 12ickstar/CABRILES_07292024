import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    let headers = request.headers.set('X-Api-Key', environment.apiKey);

    if (!(request.body instanceof FormData)) {
      headers = headers.set('Content-Type', 'application/json');
    }

    const modifiedRequest = request.clone({
      url: `${environment.apiUrl}api/${request.url}`,
      headers
    });

    return next.handle(modifiedRequest);
  }
}
