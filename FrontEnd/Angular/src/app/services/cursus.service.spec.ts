import { TestBed } from '@angular/core/testing';
import { CursusService } from './cursus.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('CursusService', () => {
  let service: CursusService;

  beforeEach(() => {
    TestBed.configureTestingModule({imports: [ HttpClientTestingModule ]});
    service = TestBed.inject(CursusService);
  });
  
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
