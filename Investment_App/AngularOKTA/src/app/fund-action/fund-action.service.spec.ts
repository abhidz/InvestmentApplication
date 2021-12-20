import { TestBed } from '@angular/core/testing';

import { FundActionService } from './fund-action.service';

describe('FundActionService', () => {
  let service: FundActionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FundActionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
