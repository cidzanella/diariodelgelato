import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { of, throwError } from 'rxjs';

import { Gelato } from '../models/gelato';

@Injectable({
  providedIn: 'root'
})
export class GelatoService {

  baseURL = environment.diarioDelGelatoApiURL;

  //app state: service storage
  gelatos: Gelato[] = [];

  constructor(private http: HttpClient) { 
  }

  getGelatos() {

    // try to get it locally
    if (this.gelatos.length > 0) return of(this.gelatos);

    // get via http api call
    return this.http.get<Gelato[]>(`${this.baseURL}gelato`)
      .pipe(
        map(gelatos => {
          this.gelatos = gelatos;
          this.gelatos.sort((a, b) => a.name < b.name ? -1 : (a.name > b.name ? 1 : 0) );
          return this.gelatos;
        }),
        catchError(this.handleError)
    );
  }
  
  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
        const errMessage = error.error.message;
        return throwError(() => errMessage);
        // Use the following instead if using lite-server
        // return Observable.throw(err.text() || 'backend server error');
    }
    return throwError(() => error || 'Server error!');
  }
  
}
