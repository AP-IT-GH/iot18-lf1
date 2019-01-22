import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PictureviewerComponent } from './pictureviewer.component';

describe('PictureviewerComponent', () => {
  let component: PictureviewerComponent;
  let fixture: ComponentFixture<PictureviewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PictureviewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PictureviewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
