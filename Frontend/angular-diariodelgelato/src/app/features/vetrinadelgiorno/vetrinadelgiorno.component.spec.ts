import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VetrinadelgiornoComponent } from './vetrinadelgiorno.component';

describe('VetrinadelgiornoComponent', () => {
  let component: VetrinadelgiornoComponent;
  let fixture: ComponentFixture<VetrinadelgiornoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VetrinadelgiornoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VetrinadelgiornoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
