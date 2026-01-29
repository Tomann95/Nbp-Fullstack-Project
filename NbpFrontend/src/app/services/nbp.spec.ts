import { TestBed } from '@angular/core/testing';

import { Nbp } from './nbp';

describe('Nbp', () => {
  let service: Nbp;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Nbp);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
