import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Cursus } from '../models/cursus';
import { CursusService } from '../services/cursus.service';
import { CursusInstantie } from '../models/CursusInstantie';

@Component({
  selector: 'app-cursussen',
  templateUrl: './cursussen.component.html',
  styleUrls: ['./cursussen.component.css']
})
export class CursussenComponent implements OnInit {
  cursussen: Observable<CursusInstantie[]>

  constructor(private cursusService: CursusService) { }

  ngOnInit() {
    this.loadCursussen();
  }
  
  loadCursussen(){
    this.cursussen = this.cursusService.getCursussen().pipe();
  }

}
