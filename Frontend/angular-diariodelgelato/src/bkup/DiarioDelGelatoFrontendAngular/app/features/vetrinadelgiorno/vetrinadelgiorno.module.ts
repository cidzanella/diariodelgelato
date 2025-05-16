import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { VetrinadelgiornoRoutingModule } from './vetrinadelgiorno-routing.module';



@NgModule({
  imports: [
    CommonModule, RouterModule, VetrinadelgiornoRoutingModule
  ],
  declarations: [VetrinadelgiornoRoutingModule.components]
})
export class VetrinadelgiornoModule { }
