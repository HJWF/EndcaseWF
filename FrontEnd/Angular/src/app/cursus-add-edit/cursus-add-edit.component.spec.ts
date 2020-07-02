import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CursusAddEditComponent } from './cursus-add-edit.component';

describe('CursusAddEditComponent', () => {
  let component: CursusAddEditComponent;
  let fixture: ComponentFixture<CursusAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
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

  it('should have upload button', () => {   
    expect(document.getElementById('uploadBtn')).toBeTruthy();
  });

  it('should have overview button', () => {   
    expect(document.getElementById('overviewBtn')).toBeTruthy();
  });
});
