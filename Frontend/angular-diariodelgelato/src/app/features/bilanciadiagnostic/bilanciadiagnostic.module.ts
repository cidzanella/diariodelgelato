import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BilanciadiagnosticRoutingModule } from './bilanciadiagnostic-routing.module';
import { BilanciaModule } from '../bilancia/bilancia.module';


@NgModule({
  declarations: [BilanciadiagnosticRoutingModule.components],
  imports: [
    CommonModule,
    BilanciadiagnosticRoutingModule,
    BilanciaModule
  ],
  exports: []
})
export class BilanciadiagnosticModule { }
