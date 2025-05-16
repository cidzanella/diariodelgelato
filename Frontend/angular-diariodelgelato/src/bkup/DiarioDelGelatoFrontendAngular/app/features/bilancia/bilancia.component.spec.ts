import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BilanciaComponent } from './bilancia.component';

describe('BilanciaComponent', () => {
  let component: BilanciaComponent;
  let fixture: ComponentFixture<BilanciaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BilanciaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BilanciaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
