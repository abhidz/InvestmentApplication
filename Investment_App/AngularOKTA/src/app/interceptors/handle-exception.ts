import { HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {Injectable} from '@angular/core'

@Injectable()
export class HandleExceptionInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
    
    return next.handle(request).pipe(
        catchError((error: HttpErrorResponse) => {
            let errorMsg = '';
            if (error.error instanceof ErrorEvent) {
              window.alert('Client side Error');
              errorMsg = `Error: ${error.error.message}`;
            }
            else {
              window.alert('Server side error');
              errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
            }
            window.alert(errorMsg);
            return throwError(errorMsg);
          })
    )
  }
}
