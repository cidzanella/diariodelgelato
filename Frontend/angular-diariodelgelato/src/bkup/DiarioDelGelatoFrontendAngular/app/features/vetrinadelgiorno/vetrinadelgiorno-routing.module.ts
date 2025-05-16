import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { VetrinadelgiornoComponent } from './vetrinadelgiorno.component';

const routes : Routes = [{path: '', component: VetrinadelgiornoComponent}];


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class VetrinadelgiornoRoutingModule { 
  static components = [VetrinadelgiornoComponent];
}
