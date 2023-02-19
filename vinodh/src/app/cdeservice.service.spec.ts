import { TestBed } from '@angular/core/testing';

import { CDEServiceService } from './cdeservice.service';

describe('CDEServiceService', () => {
  let service: CDEServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CDEServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
