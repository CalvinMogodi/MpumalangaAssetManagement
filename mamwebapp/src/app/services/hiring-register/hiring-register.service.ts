import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HiredProperty } from "src/app/models/hired-property";
import { User } from "src/app/models/user.model";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
  })
  export class HiringRegisterService {
       
        constructor(private http: HttpClient) { }
        
        getHiredProperties(): Observable<any>{
            return this.http.get<Array<HiredProperty>>(`${environment.apiUrl}/api/hiringregister/gethiredproperties`);
        }

        addHiredProperty(hiredProperty: HiredProperty) {
          return this.http.post<number>(`${environment.apiUrl}/api/hiringregister/addhiredproperty`,hiredProperty);
        }
      
        updateHiredProperty(hiredProperty: HiredProperty) {
          return this.http.post<boolean>(`${environment.apiUrl}/api/hiringregister/updatehiredproperty`,hiredProperty);
        }
        deleteHiredProperty(hiredProperty: HiredProperty){
          return this.http.post<boolean>(`${environment.apiUrl}/api/hiringregister/deletehiredproperty`,hiredProperty);
        }
}