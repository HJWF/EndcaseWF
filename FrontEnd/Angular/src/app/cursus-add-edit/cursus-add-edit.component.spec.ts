import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CursusAddEditComponent } from './cursus-add-edit.component';

describe('CursusAddEditComponent', () => {
  let component: CursusAddEditComponent;
  let fixture: ComponentFixture<CursusAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CursusAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CursusAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
