import { Component, OnInit } from '@angular/core';
import { User } from 'mamwebapp/src/app/models/user.model';
import { Subject } from 'rxjs/internal/Subject';
import { first } from 'rxjs/operators';
import { Facility } from 'src/app/models/facility.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FacilityService } from '../../services/facility/facility.service';

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrls: ['./properties.component.css']
})
export class PropertiesComponent implements OnInit {
  properties: Facility[];
  umapTemplete: any[];
  selectedFacility: Facility;
  leasedPropertyCount: Number = 0;
  activeIndex: number = 0;
  stateOwnedPropertyCount: Number = 0;
  showDialog: Boolean = false;
  showUAMP: Boolean = false;
  currentUser: User; 
  umap: any;

  constructor(public facilityService: FacilityService, private authenticationService: AuthenticationService) { 
     this.facilityService.uampTempleteChange.subscribe((value) => {
      this.umap = value
  })
  }

  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });
    this.getProperties();
  }

  getProperties(){
    this.properties = [];
    this.facilityService.getProperties(this.currentUser.department).pipe(first()).subscribe(properties => {      
      properties.forEach((facility) => {
          if(facility.status.toLowerCase().trim() == 'submitted'){
          if(facility.land != undefined && facility.finance != undefined){
            if(facility.land.leaseStatus != undefined && facility.land.propertyDescription != undefined 
              && facility.land.geographicalLocation != undefined && facility.land.landUseManagementDetail != undefined
              && facility.finance.secondaryInformationNote != undefined && facility.finance.valuation != undefined ){                       
              this.properties.push(facility);
              }               
            }
            
          }        
      });
      this.stateOwnedPropertyCount = this.properties.filter(f => f.land.landUseManagementDetail.ownershipCategory == 'State-Owned').length;
      this.leasedPropertyCount = this.properties.filter(f => f.land.landUseManagementDetail.ownershipCategory == 'Non-State Owned').length;
    });
  }

  viewFacility(facility) {
    this.selectedFacility = facility;
    this.showDialog = true;
  }

  viewUAMP() {
    this.showUAMP = true;
  }
  next(){
    let umap : any = {};
    if(this.umap){
      umap = this.umap;
    }
    
    this.facilityService.assignuampTemplete(umap);
  }

  onSave(){
    this.next();
  }

  onSubmit(){
    this.next();

  }


}
