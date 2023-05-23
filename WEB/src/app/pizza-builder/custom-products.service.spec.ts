import { TestBed } from '@angular/core/testing';

import { CustomProductsService } from './custom-products.service';

describe('CustomProductsService', () => {
  let service: CustomProductsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomProductsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
