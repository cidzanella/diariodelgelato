import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { LoginComponent } from './features/login/login.component';
import { CoreModule } from './core/core.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-full-width'
    }), 
    BsDropdownModule.forRoot()
  ],
  declarations: [
    AppComponent,
  ],
  providers: [ 
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
