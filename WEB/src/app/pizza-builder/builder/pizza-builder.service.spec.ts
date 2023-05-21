import { TestBed } from '@angular/core/testing';

import { PizzaBuilderService } from './pizza-builder.service';

describe('PizzaBuilderService', () => {
  let service: PizzaBuilderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PizzaBuilderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
