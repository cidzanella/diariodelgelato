import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { GelatoComponent } from './gelato.component';

const routes: Routes = [ { path: '', component: GelatoComponent } ];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule]    
})

export class GelatoRoutingModule { 
  static components = [GelatoComponent]; 
}
