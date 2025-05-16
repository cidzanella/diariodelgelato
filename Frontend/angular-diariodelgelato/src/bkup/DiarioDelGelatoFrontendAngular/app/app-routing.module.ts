import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

const app_routes: Routes = [
  {path: '', loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule)},
  {path: 'home', redirectTo: ''},
  {path: 'gelato', loadChildren: () => import('./features/gelato/gelato.module').then(m => m.GelatoModule)},
  {path: 'vetrinadelgiorno', loadChildren: () => import('./features/vetrinadelgiorno/vetrinadelgiorno.module').then(m => m.VetrinadelgiornoModule)},
  {path: 'bilancia', loadChildren: () => import('./features/bilancia/bilancia.module').then(m => m.BilanciaModule)},
  {path: 'bilanciadiagnostic', loadChildren: () => import('./features/bilanciadiagnostic/bilanciadiagnostic.module').then(m => m.BilanciadiagnosticModule)},
  {path: 'conodelgiorno', loadChildren: () => import('./features/conodelgiorno/conodelgiorno.module').then(m=>m.ConodelgiornoModule)},
  {path: 'login', loadChildren: () => import('./features/login/login.module').then(m=>m.LoginModule)},
];

@NgModule({
  imports: [
    CommonModule, 
    RouterModule.forRoot(app_routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
