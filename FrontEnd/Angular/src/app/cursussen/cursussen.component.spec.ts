import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CursussenComponent } from './cursussen.component';

describe('CursussenComponent', () => {
  let component: CursussenComponent;
  let fixture: ComponentFixture<CursussenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      declarations: [ CursussenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CursussenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have Nieuwe cursus button', () => {   
    expect(document.getElementById('newCursusBtn')).toBeTruthy();
  });
});
