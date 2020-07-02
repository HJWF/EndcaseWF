import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { CursusAddEditComponent } from './cursus-add-edit.component';

describe('CursusAddEditComponent', () => {
  let component: CursusAddEditComponent;
  let fixture: ComponentFixture<CursusAddEditComponent>;
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      declarations: [ CursusAddEditComponent ]
    })
    .compileComponents();

    // Inject the http service and test controller for each test
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
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
