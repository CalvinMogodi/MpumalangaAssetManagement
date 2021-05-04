import { NumberSymbol } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Facility } from 'src/app/models/facility.model';

@Component({
  selector: 'app-template-two',
  templateUrl: './template-two.component.html',
  styleUrls: ['./template-two.component.css']
})
export class TemplateTwoComponent implements OnInit {
  @Input() facilities: Facility[];
  test: Number[];
  stateOwnedFacilities: Facility[];
  leasedFacilities: Facility[];
  stateOwnedFacilitiesExtentTotal = 0;
  leasedFacilitiesExtentTotal = 0;
  constructor() { 
    this.test = [1,2,3];
  }

  ngOnInit() {
    this.sumExtent();
    this.stateOwnedFacilities = this.facilities.filter(f => f.land.landUseManagementDetail.ownershipCategory == 'State-Owned');
    this.leasedFacilities = this.facilities.filter(f => f.land.landUseManagementDetail.ownershipCategory == 'Non-State Owned');
  }

  sumExtent(){    
    this.facilities.forEach( (element) => {
      if(element.land != null){
        if(element.land.propertyDescription != null){
          if(element.land.propertyDescription.extent != null){
            if(element.land.landUseManagementDetail.ownershipCategory == 'State-Owned'){
              this.stateOwnedFacilitiesExtentTotal = this.stateOwnedFacilitiesExtentTotal + element.land.propertyDescription.extent;
            }else if(element.land.landUseManagementDetail.ownershipCategory == 'Non-State Owned'){
              this.leasedFacilitiesExtentTotal = this.leasedFacilitiesExtentTotal + element.land.propertyDescription.extent;
            }
            
          }
        }
      }
  });
  }

}
