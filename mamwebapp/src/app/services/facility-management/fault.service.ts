import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fault } from 'src/app/models/fault';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FaultService {

    constructor(private http: HttpClient) { }

    getFaults(): Observable<Array<Fault>> {
        return this.http.get<Array<Fault>>(`${environment.apiUrl}/api/fault/getfaults`);
    }

    addFault(fault: Fault) {
        return this.http.post<number>(`${environment.apiUrl}/api/fault/addfault`, fault);
    }

    updateFault(fault: Fault) {
        return this.http.post<boolean>(`${environment.apiUrl}/api/fault/updatefault`, fault);
    }

    deleteFault(fault: Fault) {
        return this.http.post<boolean>(`${environment.apiUrl}/api/fault/deletefault`, fault);
    }

    getFaultReferenceNo(referenceNo: string) {
        return this.http.get<Fault>(`${environment.apiUrl}/api/fault/getfaultbyreferenceno/${referenceNo}`);
    }
}
