import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { WeekNumberService }  from '../services/WeekNumber.service';
import { CursusService } from '../services/cursus.service';
import { CursusInstantie } from '../models/CursusInstantie';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-cursussen',
  templateUrl: './cursussen.component.html',
  styleUrls: ['./cursussen.component.css']
})
export class CursussenComponent implements OnInit {
  cursussen: CursusInstantie[] = [];
  sortedCursussen: CursusInstantie[];
  currentWeekNumber: number;
  currentYear: number = new Date().getFullYear()
  weekNumber: number;
  weekNumberService: WeekNumberService = new WeekNumberService();
  weekStartEnd: Date[] = [];

  constructor(private cursusService: CursusService) { }

  ngOnInit() 
  {
    this.determineCurrentWeek();
    this.loadCursussen();
  }
  
  loadCursussen()
  {
    this.cursusService.getCursussen().pipe( 
        map(result => {
          result.sort((a,b) => (a.startDatum > b.startDatum) ? 1 : ((b.startDatum > a.startDatum) ? -1 : 0));
          result.filter( (item) => {
            item.startDatum
          })
          return result;
        })
      )
    .subscribe(result => this.cursussen = result);
  }

  loadCursussenForWeek(year: number, weekNumber: number)
  {
    this.cursusService.getCursussenForWeek(year, weekNumber).pipe( 
        map(result => {
          result.sort((a,b) => (a.startDatum > b.startDatum) ? 1 : ((b.startDatum > a.startDatum) ? -1 : 0));
          return result;
        })
      )
    .subscribe(result => this.cursussen = result);
    this.weekNumber = weekNumber;
  }

  determineCurrentWeek()
  {
    let date: Date = new Date();
    this.currentWeekNumber = this.weekNumberService.getWeek(date)
  }
}
