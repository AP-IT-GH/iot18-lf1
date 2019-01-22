import { TestBed, inject } from '@angular/core/testing';

import { LabfarmConfigService } from './labfarm-config.service';

describe('LabfarmConfigService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LabfarmConfigService]
    });
  });

  it('should be created', inject([LabfarmConfigService], (service: LabfarmConfigService) => {
    expect(service).toBeTruthy();
  }));
});
