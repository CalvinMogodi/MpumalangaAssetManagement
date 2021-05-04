import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { FacilityType } from '../../models/facility-type.model';
import { DashboardWedge } from '../../models/dashboard-wedge.model';
import { facilitySummaryChart } from 'src/app/models/facility-summary-chart.model';
import { MapCoordinate } from 'src/app/models/map-oordinate.model';
import { Facility } from 'src/app/models/facility.model';
import { Programme } from 'src/app/models/programme.model';
import { AssetFunctionalPerformance } from 'src/app/models/asset-functional-performance.model';
import { CurrentUtlisation } from 'src/app/models/current-utilisation.model';

@Injectable({
  providedIn: 'root'
})
export class UAMPService {
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  addProgrammes(programmes : Programme[]) {
    return this.http.post<Boolean>(`${environment.apiUrl}/api/uamp/addprogrammes`, programmes);
  }

  getProgrammes(){
    return this.http.get<Array<Programme>>(`${environment.apiUrl}/api/uamp/programmes`);
  }

  addFunctionalPerformances(programmes : AssetFunctionalPerformance[]) {
    return this.http.post<Boolean>(`${environment.apiUrl}/api/uamp/addfunctionalperformances`, programmes);
  }

  getFunctionalPerformances(){
    return this.http.get<Array<AssetFunctionalPerformance>>(`${environment.apiUrl}/api/uamp/functionalperformances`);
  }

  addUtilisations(programmes : CurrentUtlisation[]) {
    return this.http.post<Boolean>(`${environment.apiUrl}/api/uamp/addutilisations`, programmes);
  }

  getUtilisations(){
    return this.http.get<Array<CurrentUtlisation>>(`${environment.apiUrl}/api/uamp/utilisations`);
  }
}