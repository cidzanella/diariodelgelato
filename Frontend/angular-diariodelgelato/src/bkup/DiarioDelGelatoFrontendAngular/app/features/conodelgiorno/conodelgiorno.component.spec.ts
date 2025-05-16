import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConodelgiornoComponent } from './conodelgiorno.component';

describe('ConodelgiornoComponent', () => {
  let component: ConodelgiornoComponent;
  let fixture: ComponentFixture<ConodelgiornoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConodelgiornoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConodelgiornoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
