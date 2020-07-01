import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Cursus } from '../models/cursus';
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

  constructor(private cursusService: CursusService) { }

  ngOnInit() 
  {
    this.loadCursussen();
  }
  
  loadCursussen()
  {
    // this.cursussen = this.cursusService.getCursussen();
    let result = this.cursusService.getCursussen()
    .pipe( 
        map(result => result.sort((a,b) => (a.startDatum > b.startDatum) ? 1 : ((b.startDatum > a.startDatum) ? -1 : 0)))
      )
    .subscribe(result => this.cursussen = result);
  }
}
