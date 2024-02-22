import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          switch (error.status) {
            case 0: //Client-side error, or CORS or Internet or API service off
              this.toastr.error(`Ops! Parece que temos um problema no aplicativo ou de conexão ao servidor.`);
              break;
            case 400: //bad request
              if (error.error.errors) {
                const modalStateErrors = [];
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    modalStateErrors.push(error.error.errors[key]);
                  }
                }
                throw modalStateErrors.flat();
              } else {
                this.toastr.error(`Ops! Temos algum problema com a requisição. O servidor retornou o erro: ${error.status}. Detalhes:`, error.error);
              }
              break;
            case 401: //unauthorized: session expired, redirect to login
              this.toastr.error(`Aparentemente sua sessão expirou. Faça o login novamente. Error:${error.error} | Status: ${error.status}`);
              console.log(error)
              //this.router.navigate(['/login'])
              break;
            case 404: //not found
            case 500: //internal server error
            default:
              // The backend returned an unsuccessful response code.
              // The response body may contain clues as to what went wrong.
              // TODO: Log this details and show a user friendly msg instead.
              this.toastr.error(`Ops! Algo inesperado deu errado... Error:${error.error} | Status: ${error.status}`);
              console.log(error)
              break;
          }
        }
        return throwError(error);
      })
    )
  }
}
