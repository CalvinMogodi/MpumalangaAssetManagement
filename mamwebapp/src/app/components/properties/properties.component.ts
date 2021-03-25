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
  stateOwnedPropertyCount: Number = 0;
  showDialog: Boolean = false;

  constructor(public facilityService: FacilityService) { 
    
  }

  ngOnInit() {
    this.getAllFacilities();
  }

  getAllFacilities(){
    this.facilityService.getAllFacilities().pipe(first()).subscribe(facilities => {
      this.facilities = facilities;    

      this.facilities.forEach((facility) => {
        if (new Date(facility.land.leaseStatus.terminationDate).getTime() > new Date().getTime()) {
          this.leasedPropertyCount = +this.leasedPropertyCount + 1;
        }
        else {
          this.stateOwnedPropertyCount = +this.stateOwnedPropertyCount + 1
        }
      })
    });
  }

  viewFacility(facility) {
    this.selectedFacility = facility;
    this.showDialog = true;
  }

}
