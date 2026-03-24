import { TestBed } from '@angular/core/testing';

import { Evidencia } from './evidencia';

describe('Evidencia', () => {
  let service: Evidencia;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Evidencia);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
