import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PictureTimelineComponent } from './picture-timeline.component';

describe('PictureTimelineComponent', () => {
  let component: PictureTimelineComponent;
  let fixture: ComponentFixture<PictureTimelineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PictureTimelineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PictureTimelineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
