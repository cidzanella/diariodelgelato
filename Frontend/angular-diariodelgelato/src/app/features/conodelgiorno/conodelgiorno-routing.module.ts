import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ConodelgiornoComponent } from './conodelgiorno.component';

const routes: Routes = [{path:'', component: ConodelgiornoComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConodelgiornoRoutingModule {
  static components = [ConodelgiornoComponent];
}
