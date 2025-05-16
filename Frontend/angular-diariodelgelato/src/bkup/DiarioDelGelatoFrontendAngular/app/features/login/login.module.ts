import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { LoginRoutingModule } from './login-routing.module';

@NgModule({
  declarations: [LoginRoutingModule.components],
  imports: [LoginRoutingModule, CommonModule, RouterModule, FormsModule ]
})
export class LoginModule { }
