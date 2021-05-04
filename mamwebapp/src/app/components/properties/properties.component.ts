import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Facility } from 'src/app/models/facility.model';
import { FacilityService } from '../../services/facility/facility.service';

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrls: ['./properties.component.css']
})
export class PropertiesComponent implements OnInit {
  facilities: Facility[];
  selectedFacility: Facility;
  leasedPropertyCount: Number = 0;
  activeIndex: number = 1;
  stateOwnedPropertyCount: Number = 0;
  showDialog: Boolean = false;
  showUAMP: Boolean = false;

  constructor(public facilityService: FacilityService) { 
    
  }

  ngOnInit() {
    this.getProperties();
  }

  getFacilities() {

  }

  getProperties(){
    this.facilities = [];
    this.facilityService.getProperties().pipe(first()).subscribe(facilities => {
      
        facilities.forEach((facility) => {
          if(facility.status.toLowerCase().trim() == 'submitted'){
          if(facility.land != undefined && facility.finance != undefined){
            if(facility.land.leaseStatus != undefined && facility.land.propertyDescription != undefined 
              && facility.land.geographicalLocation != undefined && facility.land.landUseManagementDetail != undefined
              && facility.finance.secondaryInformationNote != undefined && facility.finance.valuation != undefined ){                       
              this.facilities.push(facility);
              }              
            }
            
          }        
      });
      this.stateOwnedPropertyCount = this.facilities.filter(f => f.land.landUseManagementDetail.ownershipCategory == 'State-Owned').length;
      this.leasedPropertyCount = this.facilities.filter(f => f.land.landUseManagementDetail.ownershipCategory == 'Non-State Owned').length;
    });
  }

  viewFacility(facility) {
    this.selectedFacility = facility;
    this.showDialog = true;
  }

  viewUAMP() {
    this.showUAMP = true;
  }
}
