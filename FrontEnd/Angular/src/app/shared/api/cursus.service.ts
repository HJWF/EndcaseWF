import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import cursus from '../models/Cursus';

@Injectable()
export default class CursusService {
  public API = 'http://localhost:8080/api';
  public CURSUS_API = `${this.API}/cursus`;
  constructor(private http: HttpClient) {}
  getAll(): Observable<Array<cursus>> {
    return this.http.get<Array<cursus>>(this.CURSUS_API);
  }
  get(id: string) {
    return this.http.get(`${this.CURSUS_API}/${id}`);
  }
  save(cursus: cursus): Observable<cursus> {
    let result: Observable<cursus>;
    if (cursus.id) {
      result = this.http.put<cursus>(
        `${this.CURSUS_API}/${cursus.id}`,
        cursus
      );
    } else {
      result = this.http.post<cursus>(this.CURSUS_API, cursus);
    }
    return result;
  }
  remove(id: number) {
    return this.http.delete(`${this.CURSUS_API}/${id.toString()}`);
  }
}