import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Cursus } from '../models/cursus';
import { CursusService } from '../services/cursus.service';

@Component({
  selector: 'app-cursus',
  templateUrl: './cursus.component.html',
  styleUrls: ['./cursus.component.css']
})
export class CursusComponent implements OnInit {
  cursussen: Observable<Cursus[]>

  constructor(private cursusService: CursusService) { }

  ngOnInit() {
    this.loadCursussen();
  }
  
  loadCursussen(){
    this.cursussen = this.cursusService.getCursussen()
  }

}
