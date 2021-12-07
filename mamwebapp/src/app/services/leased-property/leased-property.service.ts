import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeasedProperty } from 'src/app/models/leased-property.model';

@Injectable({
  providedIn: 'root'
})
export class LeasedPropertiesService {
    
      constructor(private http: HttpClient) { }

      getLeasedProperties(): any{//Observable<any>{
         
          //return [];
      }
}