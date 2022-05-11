import { DatePipe } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { LeasedProperty } from 'src/app/models/leased-property.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { LeasedPropertiesService } from 'src/app/services/leased-property/leased-property.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-facility-management',
  templateUrl: './facility-management.component.html',
  styleUrls: ['./facility-management.component.css'],
  providers: [MessageService,]
})
export class FacilityManagementComponent implements OnInit {

  public projectsInProgress: number = 0;
  public serviceRequestsLogged: number = 0;
  public completedRequests: number = 0;
  public awaitingSignOff: number = 0;
  public items: any = [ { icon: 'pi pi-home',url: 'dashboard' },
  { label: 'Facility Management' }
];

  constructor() {
  
  }

  ngOnInit() {
  
  }
}
