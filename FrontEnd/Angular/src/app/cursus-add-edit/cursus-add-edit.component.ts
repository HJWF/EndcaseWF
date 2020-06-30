import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CursusService } from '../services/cursus.service';
import { JsonMapper } from '../services/cursus.mapper';

@Component({
  selector: 'app-cursus-add-edit',
  templateUrl: './cursus-add-edit.component.html',
  styleUrls: ['./cursus-add-edit.component.css']
})
export class CursusAddEditComponent {

  fileContent: string = '';
  fileToUpload: File;

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

    this.cursusService.addCursus(this.fileToUpload)
  }
}
