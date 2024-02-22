import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { BilanciaComponent } from './bilancia.component';

const route : Routes = [{path: '', component: BilanciaComponent}]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(route)
  ], 
  exports: [RouterModule]
})
export class BilanciaRoutingModule { 
  static components = [BilanciaComponent];
}
