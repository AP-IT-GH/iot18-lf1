import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LfNavbarComponent } from './lf-navbar.component';

describe('LfNavbarComponent', () => {
  let component: LfNavbarComponent;
  let fixture: ComponentFixture<LfNavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LfNavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LfNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
