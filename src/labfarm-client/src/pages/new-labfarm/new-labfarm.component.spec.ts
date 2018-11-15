import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewLabfarmComponent } from './new-labfarm.component';

describe('NewLabfarmComponent', () => {
  let component: NewLabfarmComponent;
  let fixture: ComponentFixture<NewLabfarmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewLabfarmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewLabfarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
