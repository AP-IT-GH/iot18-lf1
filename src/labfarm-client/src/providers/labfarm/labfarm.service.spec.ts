import { TestBed, inject } from '@angular/core/testing';

import { LabfarmService } from './labfarm.service';

describe('LabfarmService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LabfarmService]
    });
  });

  it('should be created', inject([LabfarmService], (service: LabfarmService) => {
    expect(service).toBeTruthy();
  }));
});
