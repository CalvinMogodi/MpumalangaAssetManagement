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

@Injectable({
  providedIn: 'root'
})
export class UAMPService {
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  addProgrammes(programmes : Programme[]) {
    return this.http.post<Facility>(`${environment.apiUrl}/api/uamp/addProgrammes`, programmes);
  }
}