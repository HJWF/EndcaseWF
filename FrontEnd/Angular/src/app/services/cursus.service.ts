import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, count } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CursusInstantie} from '../models/CursusInstantie'
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class CursusService {
  myAppUrl: string;
  myApiUrl: string;

  httpOption = {
    headers: new HttpHeaders(
      {
        'Content-Type': 'application/json; charset=utf-8'
      })
  };

  constructor(private http: HttpClient) 
  { 
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/cursus'
  }

  getCursussen(): Observable<CursusInstantie[]> 
  {
    return this.http.get<CursusInstantie[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      map((response: any) => response),
      catchError((err: any, result?) => {
        console.log(err)
        return of(result)
      }
    ));
  }

  addCursus(fileToUpload: File)
  {
    const data: FormData = new FormData();

    data.append('filekey', fileToUpload, fileToUpload.name);

    return this.http.post(this.myAppUrl + this.myApiUrl, data, {observe: 'response'})
  }
}
