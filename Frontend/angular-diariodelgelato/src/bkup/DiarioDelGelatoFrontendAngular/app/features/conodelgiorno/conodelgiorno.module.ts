import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConodelgiornoRoutingModule } from './conodelgiorno-routing.module';
import { BilanciaModule } from '../bilancia/bilancia.module';


@NgModule({
  declarations: [ConodelgiornoRoutingModule.components],
  imports: [
    CommonModule,
    ConodelgiornoRoutingModule,
    BilanciaModule
  ]
})
export class ConodelgiornoModule { }
