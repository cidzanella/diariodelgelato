import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Conodelgiorno } from '../models/conodelgiorno';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConodelgiornoService {

  baseURL = environment.diarioDelGelatoApiURL;
  
  constructor(private _http: HttpClient) { }

  registerConoDelGiorno(cono: Conodelgiorno){
    return this._http.post<Conodelgiorno>(`${this.baseURL}conodelgiorno`, cono).pipe(
      map(response => response)
    )
  }
}
