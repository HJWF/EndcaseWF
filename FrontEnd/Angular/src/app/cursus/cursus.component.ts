import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CursusService } from '../services/cursus.service';
import { CursusInstantie } from '../models/CursusInstantie';
import { WeekNumberService } from '../services/WeekNumber.service';
import { map } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cursus',
  templateUrl: './cursus.component.html',
  styleUrls: ['./cursus.component.css']
})
export class CursusComponent implements OnInit {
  cursussen: CursusInstantie[] = [];
  currentWeekNumber: number;
  currentYear: number;
  weekNumber: number;
  year: number;
  weekNumberService: WeekNumberService = new WeekNumberService();
  errorMessage: string;
  validWeekNumber: boolean = false;
  validYear: boolean = false;
  id: number;
  yearWeek: number;
  subscription: Subscription;

  constructor(private cursusService: CursusService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() 
  {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      
    })
    this.currentWeekNumber = Number.parseInt(this.id.toString().substring(4));
    this.currentYear = Number.parseInt(this.id.toString().substring(0, 4));
    this.yearWeek = Number.parseInt( '' + this.currentYear + this.currentWeekNumber);

    this.loadCursussenForWeek(this.currentYear, this.currentWeekNumber);

    this.router.navigate(['/cursus', this.yearWeek]);
  }
  
  loadCursussenForWeek(year: number, weekNumber: number)
  {
    this.subscription = this.cursusService.getCursussenForWeek(year, weekNumber).pipe( 
        map(result => {
          result.sort((a,b) => (a.startDatum > b.startDatum) ? 1 : ((b.startDatum > a.startDatum) ? -1 : 0));
          return result;
        })
      )
    .subscribe(result => this.cursussen = result);
  }

  updateWeekNumber(){
    this.errorMessage = '';

    if(this.validWeekNumber == false)
    {
      this.errorMessage += ' Geen geldig weeknummer';
      return;
    }

    if(this.validYear == false)
    {
      this.errorMessage += ' Geen geldig jaar';
      return;
    }

    if(this.validWeekNumber == true && this.validYear == true)
    {
      this.subscription.unsubscribe();

      this.currentYear = this.year;
      this.currentWeekNumber = this.weekNumber;
      this.yearWeek = Number.parseInt( '' + this.currentYear + this.currentWeekNumber);

      this.loadCursussenForWeek(this.currentYear, this.currentWeekNumber);

      this.router.navigate(['/cursus', this.yearWeek]);
    }
  }

  public onChangeWeekNummer(input: number){
    this.errorMessage = '';
    if(input.toString().length > 2 || input > 53 || input < 1)
    {
      this.errorMessage += ' Geen geldig weeknummer';
      this.validWeekNumber = false;
      return;
    }

    this.validWeekNumber = true;;
    this.weekNumber = input;
  }

  public onChangeYear(input: number ){
    this.errorMessage = '';
    if(input.toString().length != 4 )
    {
      this.errorMessage += ' Geen geldig jaar';
      this.validYear = false;
      return;
    }

    this.validYear = true;;
    this.year = input;
  }
  
  determineCurrentWeek()
  {
    let date: Date = new Date();
    this.currentWeekNumber = this.weekNumberService.getWeek(date)
  }

  public nextWeek()
  {
    this.subscription.unsubscribe();

    this.currentWeekNumber ++;
    this.yearWeek = Number.parseInt( '' + this.currentYear + this.currentWeekNumber);

    this.loadCursussenForWeek(this.currentYear, this.currentWeekNumber);

    this.router.navigate(['/cursus', this.yearWeek]);
  }

  public previousWeek()
  {
    this.subscription.unsubscribe();

    this.currentWeekNumber --;
    this.yearWeek = Number.parseInt( '' + this.currentYear + this.currentWeekNumber);

    this.loadCursussenForWeek(this.currentYear, this.currentWeekNumber);

    this.router.navigate(['/cursus', this.yearWeek]);
  }
}
