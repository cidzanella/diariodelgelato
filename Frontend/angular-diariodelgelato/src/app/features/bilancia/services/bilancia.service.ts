import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BilanciaResponse } from '../models/bilancia-response';
import { catchError } from 'rxjs/operators';
import { Observable, observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class BilanciaService {

  baseURL = environment.scaleApiURL;

  constructor(private http: HttpClient, private toastr: ToastrService) {}
  
  getWeight() {
    return this.http.get<BilanciaResponse>(this.baseURL + 'getweight').pipe(
      catchError( error => this.handleError(error))
    )
  };

  private handleError(error: HttpErrorResponse): Observable<any>  {
    //select message based on error status
    let errorMessage: string = (error.status === 0)
    ? 'O serviço Dymo de balança parece não estar disponível; por gentileza tente novamente mais tarde.'
    : 'Algo não saiu como esperado; por gentileza tente novamente mais tarde.';
    // present message to user
    this.toastr.error(errorMessage);
    // forward error 
    const err: any = new Error(errorMessage);
    err.status = 0;
    throw err;
  }
}
