import { Component } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { CursusService } from '../services/cursus.service';

@Component({
  selector: 'app-cursus-add-edit',
  templateUrl: './cursus-add-edit.component.html',
  styleUrls: ['./cursus-add-edit.component.css']
})
export class CursusAddEditComponent {

  fileContent: string = '';
  fileToUpload: File;
  addedCursusses: string;
  addedCursusInstanties: string;
  doubleCursusses: string;
  doubleCursusInstanties: string;

  constructor(private cursusService: CursusService)
  { }

  public onChange(files: FileList)
  {
    this.fileToUpload = files[0];
  }

  Save()
  {
    if(this.fileToUpload == null)
    {
      return;
    }

    this.cursusService.addCursus(this.fileToUpload).subscribe(data => {
      let response = data.body.toString().split(',');
      this.addedCursusses = response[0];
      this.addedCursusInstanties = response[1];
      this.doubleCursusses = response[2];
      this.doubleCursusInstanties = response[3];
    });
  }
  
}
