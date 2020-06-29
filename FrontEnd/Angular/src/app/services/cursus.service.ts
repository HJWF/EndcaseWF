import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Cursus} from '../models/cursus'

@Injectable({
  providedIn: 'root'
})
export class CursusService {

  myAppUrl: string;
  myApiUrl: string;
  httpOption = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) 
  { 
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/cursus'
  }

  getCursussen(): Observable<Cursus[]> {
    return this.http.get<Cursus[]>(this.myAppUrl + this.myApiUrl)
  }

  getCursus(postId: number): Observable<Cursus> {
    return this.http.get<Cursus>(this.myAppUrl + this.myApiUrl + postId)
  }
}
