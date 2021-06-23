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
  uamp: any[];

  uampChange: Subject<any[]> = new Subject<any[]>();

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  assignUamp(umap: any[]) {
    this.uamp = umap
    this.uampChange.next(this.uamp);
}

  getUamps(userDepartment){
    return this.http.get<Array<UAMP>>(`${environment.apiUrl}/api/uamp/getuamps/`+userDepartment);
  }
}