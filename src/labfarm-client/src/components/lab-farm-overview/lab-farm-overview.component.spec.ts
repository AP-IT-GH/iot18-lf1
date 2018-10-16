import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabFarmOverviewComponent } from './lab-farm-overview.component';

describe('LabFarmOverviewComponent', () => {
  let component: LabFarmOverviewComponent;
  let fixture: ComponentFixture<LabFarmOverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabFarmOverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabFarmOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
