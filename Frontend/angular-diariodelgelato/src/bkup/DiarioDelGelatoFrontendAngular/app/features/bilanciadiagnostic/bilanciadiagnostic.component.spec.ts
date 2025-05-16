import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BilanciadiagnosticComponent } from './bilanciadiagnostic.component';

describe('BilanciadiagnosticComponent', () => {
  let component: BilanciadiagnosticComponent;
  let fixture: ComponentFixture<BilanciadiagnosticComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BilanciadiagnosticComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BilanciadiagnosticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
