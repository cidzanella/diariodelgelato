import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarModule } from './components/navbar/navbar.module';
import { NotFoundErrorComponent } from './components/errors/not-found-error/not-found-error.component';
import { ServerErrorComponent } from './components/errors/server-error/server-error.component';
import { UnauthorizedErrorComponent } from './components/errors/unauthorized-error/unauthorized-error.component';

@NgModule({
  declarations: [
    NotFoundErrorComponent,
    ServerErrorComponent,
    UnauthorizedErrorComponent
  ],
  imports: [
    CommonModule, NavbarModule 
  ],
  exports: [NavbarModule]
})
export class CoreModule { }
