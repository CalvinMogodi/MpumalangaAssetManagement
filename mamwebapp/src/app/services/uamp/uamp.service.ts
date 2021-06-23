import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Subject } from 'rxjs/internal/Subject';
import { UAMP } from 'src/app/models/uamp.model';

@Injectable({
  providedIn: 'root'
})
export class UampService {
  uamp: UAMP;

  uampChange: Subject<UAMP> = new Subject<UAMP>();

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  assignUamp(umap: UAMP) {
    this.uamp = umap
    this.uampChange.next(this.uamp);
}

  getUamps(userDepartment){
    return this.http.get<Array<UAMP>>(`${environment.apiUrl}/api/uamp/getuamps/`+userDepartment);
  }

  createUamp(uamp: UAMP){
    return this.http.post<UAMP>(`${environment.apiUrl}/api/uamp/saveuamp`,uamp);
  }

  startuamp(uamp: UAMP){
    return this.http.post<UAMP>(`${environment.apiUrl}/api/uamp/startuamp`,uamp);
  }
}