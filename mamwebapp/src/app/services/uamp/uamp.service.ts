import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Subject } from 'rxjs/internal/Subject';
import { UAMP } from 'src/app/models/uamp.model';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import { Programme } from 'src/app/models/programme.model';
import { Property } from 'src/app/models/property.model';
import { OperationPlan } from 'src/app/models/operation-plan.model';
import { StrategicAssessment } from 'src/app/models/strategic-assessment.model';
import { SurrenderPlan } from 'src/app/models/surrender-plan.model';
import { AcquisitionPlan } from 'src/app/models/acquisition-plan.model';

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

  getUamps(userDepartment: String): Observable<any>{
    return this.http.get<Array<UAMP>>(`${environment.apiUrl}/api/uamp/getuamps/`+userDepartment);
  }

  getUamp(id: Number): Observable<any>{
    return this.http.get<Array<UAMP>>(`${environment.apiUrl}/api/uamp/getampbyid/`+id);
  }

  saveUamp(uamp: UAMP){
    return this.http.post<UAMP>(`${environment.apiUrl}/api/uamp/saveuamp`,uamp);
  }

  startuamp(uamp: UAMP){
    return this.http.post<UAMP>(`${environment.apiUrl}/api/uamp/startuamp`,uamp);
  }

  deleteProgramme(programme: Programme){
    return this.http.post<boolean>(`${environment.apiUrl}/api/uamp/deleteprogramme`,programme);
  }

  deleteProperty(property: Property){
    return this.http.post<boolean>(`${environment.apiUrl}/api/uamp/deleteproperty`,property);
  }

  deleteOperationPlan(operationplan: OperationPlan){
    return this.http.post<boolean>(`${environment.apiUrl}/api/uamp/deleteoperationplan`,operationplan);
  }

  deleteStrategicAssessment(strategicassessment: StrategicAssessment){
    return this.http.post<boolean>(`${environment.apiUrl}/api/uamp/deletestrategicassessment`,strategicassessment);
  }

  deleteSurrenderPlan(surrenderplan: SurrenderPlan){
    return this.http.post<boolean>(`${environment.apiUrl}/api/uamp/deletesurrenderplan`,surrenderplan);
  }

  deleteAcquisitionPlan(acquisitionPlan: AcquisitionPlan){
    return this.http.post<boolean>(`${environment.apiUrl}/api/uamp/deleteacquisitionplan`,acquisitionPlan);
  }

  templeteSevenCalclation(uamp: UAMP){    
    return uamp;
  }

}