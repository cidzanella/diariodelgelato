import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BilanciadiagnosticComponent } from './bilanciadiagnostic.component';

const routes: Routes = [{path:'', component: BilanciadiagnosticComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BilanciadiagnosticRoutingModule { 
  static components = [BilanciadiagnosticComponent];
}
