import { TestBed, async } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { WeekNumberService } from './WeekNumber.service';
import { RouterLink, RouterModule } from '@angular/router';

describe('WeekNumberService', () => {
  let service: WeekNumberService = new WeekNumberService();

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule, RouterModule ]
    });
    // service = TestBed.inject(WeekNumberService);
  }));
  
  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return the correct weeknumber', () => {
    let date: Date = new Date("2020-07-02");
    let expectedWeekNumber = 27;
    let weeknumber = service.getWeek(date);
    expect(weeknumber).toBe(expectedWeekNumber);
  })
});
