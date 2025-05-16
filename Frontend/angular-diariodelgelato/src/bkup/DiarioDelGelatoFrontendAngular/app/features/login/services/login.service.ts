import { Injectable } from '@angular/core';
import { Credential } from '../models/credential';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor() { }

  login(){
    // send user and pass to backend and get credentials

    // create local register of logged in user
  }

  logout(){
    // clear local logged user information

  }
}
