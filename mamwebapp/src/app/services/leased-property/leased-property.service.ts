import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeasedProperty } from 'src/app/models/leased-property.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LeasedPropertiesService {
    
      constructor(private http: HttpClient) { }

      getLeasedProperties(): Observable<any>{
        return this.http.get<Array<LeasedProperty>>(`${environment.apiUrl}/api/leasemanagement/getleasedproperties`);
      }
}