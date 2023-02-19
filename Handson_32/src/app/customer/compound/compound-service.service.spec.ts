import { TestBed } from '@angular/core/testing';

import { CompoundServiceService } from './compound-service.service';

describe('CompoundServiceService', () => {
  let service: CompoundServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompoundServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
