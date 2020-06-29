import { Component, OnInit } from '@angular/core';
import CursusService from "../shared/api/cursus.service";
import Cursus from "../shared/models/Cursus"

@Component({
  selector: 'app-cursus-list',
  templateUrl: './cursus-list.component.html',
  styleUrls: ['./cursus-list.component.css']
})
export class CursusListComponent implements OnInit 
{
  cursussen: Array<Cursus>;
  constructor(private cursusService: CursusService) { }

  ngOnInit(): void 
  {
    this.cursusService.getAll().subscribe(data => {
      this.cursussen = data;
    })
  }

}
