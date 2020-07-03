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
  errorReason: string;
  errorMessage: string;

  constructor(private cursusService: CursusService)
  { }

  public onChange(files: FileList)
  {
    this.fileToUpload = files[0];
    this.addedCursusses = "";
    this.addedCursusInstanties = "";
    this.doubleCursusses = "";
    this.doubleCursusInstanties = "";
    this.errorReason = "";
    this.errorMessage = "";
  }

  Upload()
  {
    this.errorMessage = "";
    if(this.fileToUpload == null)
    {
      this.errorMessage = "Geen bestand geselecteerd";
      return;
    }

    this.cursusService.addCursus(this.fileToUpload).subscribe((data:HttpResponse<object>) => {
      if (data.status == 200) {
        let response = data.body.toString().split('.');
        this.addedCursusses = response[0];
        this.addedCursusInstanties = response[1];
        this.doubleCursusses = response[2];
        this.doubleCursusInstanties = response[3];
      }
      if (data.status == 202) {
        let response = data.body.toString().split('.');
        this.errorReason = response[0];
        this.errorMessage = response[1];
      }
    });
  }
  
}
