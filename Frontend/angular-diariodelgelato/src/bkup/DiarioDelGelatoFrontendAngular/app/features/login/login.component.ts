import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'diarioapp-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  username: string = '';
  password: string = '';
  isPasswordVisible: boolean = false;

  constructor() {}

  ngOnInit(): void {
    
  }

  onSubmit(){
  }

  onInputChange() {
    console.log('isPasswordVisible:', this.isPasswordVisible);
  }

  togglePasswordVisibility() {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

}
