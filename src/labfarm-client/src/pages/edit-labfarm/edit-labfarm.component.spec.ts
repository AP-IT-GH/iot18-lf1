import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLabfarmComponent } from './edit-labfarm.component';

describe('EditLabfarmComponent', () => {
  let component: EditLabfarmComponent;
  let fixture: ComponentFixture<EditLabfarmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditLabfarmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditLabfarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
