import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { first } from 'rxjs/operators';
import { LeasedProperty } from 'src/app/models/leased-property.model';
import { LeasedPropertiesService } from 'src/app/services/leased-property/leased-property.service';

@Component({
  selector: 'app-lease-management',
  templateUrl: './lease-management.component.html',
  styleUrls: ['./lease-management.component.css'],
})
export class LeaseManagementComponent implements OnInit {
  @Input() leasedProperties: Array<LeasedProperty>;
  loading: boolean;
  dataIsLoaded: boolean = false;
  isBusy: boolean;
  errorMsg: string;
  error = '';
  selectedLeasedProperty: LeasedProperty;
  buttonItems: MenuItem[];
  items = [
    { icon: 'pi pi-home',url: 'dashboard' },
    { label: 'Lease Management' }];
  cols = [
    { field: 'fileReference', header: 'File Reference' },
    { field: 'type', header: 'Type' },
    { field: 'propertyCode', header: 'Property Code' },
    { field: 'facilityName', header: 'Facility Name' },
    { field: 'natureofLease', header: 'Nature of Lease' },
    { field: 'startingDate', header: 'Starting Date' },
    { field: 'terminationDate', header: 'Termination Date' }
  ];

  constructor(private leasedPropertiesService: LeasedPropertiesService) { }

  ngOnInit() {
    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewLeasedProperty()
      },
      { separator: true },
      {label: 'Snag list', icon: 'pi pi-list', command: () => 
          this.attachSnagList()
      },
      { separator: true },
      {label: 'Handover document', icon: 'pi pi-file', command: () => 
          this.attachFinalHandoverDocument()
      }
  ];  
    this.getLeasedProperties();  
  }

  getLeasedProperties() {
    this.leasedPropertiesService.getLeasedProperties().pipe(first()).subscribe(leasedProperties => {
      this.leasedProperties = leasedProperties;    
      this.dataIsLoaded = true;
    });   
  }

  viewLeasedProperty(){

  }

  attachSnagList(){

  }

  attachFinalHandoverDocument(){

  }

  selectLeasedProperty(leasedProperty: LeasedProperty){
    this.selectedLeasedProperty = leasedProperty;
  }

}
