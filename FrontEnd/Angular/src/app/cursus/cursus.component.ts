import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Cursus } from '../models/cursus';
import { CursusService } from '../services/cursus.service';
import { CursusInstantie } from '../models/CursusInstantie';

@Component({
  selector: 'app-cursus',
  templateUrl: './cursus.component.html',
  styleUrls: ['./cursus.component.css']
})
export class CursusComponent implements OnInit {
  cursussen: Observable<CursusInstantie[]>

  constructor(private cursusService: CursusService) { }

  ngOnInit() {
    this.loadCursussen();
  }
  
  loadCursussen(){
    this.cursussen = this.cursusService.getCursussen()
  }

}
