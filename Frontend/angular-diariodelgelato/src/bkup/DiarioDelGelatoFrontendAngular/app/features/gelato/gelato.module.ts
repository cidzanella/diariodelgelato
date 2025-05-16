import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { GelatoRoutingModule } from './gelato-routing.module';


@NgModule({
  imports: [GelatoRoutingModule, CommonModule, RouterModule],
  declarations: [GelatoRoutingModule.components], 
  exports: []
})
export class GelatoModule { }
