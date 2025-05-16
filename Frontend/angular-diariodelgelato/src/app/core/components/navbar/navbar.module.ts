import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';


@NgModule({
  declarations: [NavbarComponent],
  imports: [CommonModule, RouterModule, BsDropdownModule],
  exports: [NavbarComponent]
})
export class NavbarModule { }
