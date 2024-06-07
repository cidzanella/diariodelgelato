import { TestBed } from '@angular/core/testing';

import { ConodelgiornoService } from './conodelgiorno.service';

describe('ConodelgiornoService', () => {
  let service: ConodelgiornoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConodelgiornoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
