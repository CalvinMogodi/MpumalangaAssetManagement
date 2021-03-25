import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { FacilityType } from '../../models/facility-type.model';
import { DashboardWedge } from '../../models/dashboard-wedge.model';
import { facilitySummaryChart } from 'src/app/models/facility-summary-chart.model';
import { MapCoordinate } from 'src/app/models/map-oordinate.model';
import { Facility } from 'src/app/models/facility.model';

@Injectable({
  providedIn: 'root'
})
export class FacilityService {
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  getFacilityZonings() {
    return this.http.get<FacilityType[]>(`${environment.apiUrl}/api/facility/getfacilityzonings`);
  }

  getDashboardWedges() {
    return this.http.get<DashboardWedge[]>(`${environment.apiUrl}/api/facility/getdashboardwedges`);
  }

  getFacilitySummaries() {
    return this.http.get<Array<facilitySummaryChart>>(`${environment.apiUrl}/api/facility/getfacilitysummaries`);
  }
  
  getMapCoordinates() {
    return this.http.get<Array<MapCoordinate>>(`${environment.apiUrl}/api/facility/getmapcoordinates`);
  }

  getProperties(){
    return this.http.get<Array<Facility>>(`${environment.apiUrl}/api/facility/getproperties`);
  }

  getAllFacilities() {
    return this.http.get<Array<Facility>>(`${environment.apiUrl}/api/facility/getallfacilities`);
  }

  getFacilityById(id: number, facilityType) {
    return this.http.get<Facility>(`${environment.apiUrl}/api/facility/getFacilityByCode/`+id+`/`+facilityType);
  }

  deleteFacility(id : number) {
    return this.http.delete<Facility>(`${environment.apiUrl}/api/facility/deleteFacility/`+ id );
  }

  updateFacility(facility : Facility, step: string) {
    return this.http.post<Facility>(`${environment.apiUrl}/api/facility/updateFacility/` + step, facility);
  }

  saveFacility(facility : Facility, step: string) {
    return this.http.post<Facility>(`${environment.apiUrl}/api/facility/saveFacility/` + step, facility);
  }

  uploadFiles(files : any) {
    const formData: FormData = new FormData();

    formData.append('json', JSON.stringify("test"));

    for (let file of files) {
      formData.append('documento', file.data, file.data.name);
    }
    let headers = new HttpHeaders();
    return this.http.post<Facility>(`${environment.apiUrl}/api/facility/uploadFiles/`, formData,{ headers: headers });
  }
}