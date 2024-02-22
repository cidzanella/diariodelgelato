import { TestBed } from '@angular/core/testing';

import { BilanciaService } from './bilancia.service';

describe('BilanciaService', () => {
  let service: BilanciaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BilanciaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
