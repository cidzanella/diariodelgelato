import { NgModule } from '@angular/core';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [],
  imports: [ CollapseModule.forRoot(), BsDropdownModule.forRoot()],
  exports: [BsDropdownModule, CollapseModule]
})
export class SharedModule { }
