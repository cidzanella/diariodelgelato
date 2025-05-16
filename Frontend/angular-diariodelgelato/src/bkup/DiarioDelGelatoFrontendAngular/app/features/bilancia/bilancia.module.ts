import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BilanciaRoutingModule } from './bilancia-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';



@NgModule({
  declarations: [BilanciaRoutingModule.components],
  imports: [
    CommonModule,
    BilanciaRoutingModule,
    BsDropdownModule
  ],
  exports: [BilanciaRoutingModule.components]

})
export class BilanciaModule { }
