import { TestBed } from '@angular/core/testing';

import { AffiliateInfoService } from './affiliate-info.service';

describe('AffiliateInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AffiliateInfoService = TestBed.get(AffiliateInfoService);
    expect(service).toBeTruthy();
  });
});
