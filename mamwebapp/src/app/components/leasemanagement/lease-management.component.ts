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
  home: MenuItem;
  selectedLeasedProperty: LeasedProperty;
  buttonItems: MenuItem[];
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
    this.home = {icon: 'pi pi-home'};    
    this.getLeasedProperties();  
  }

  getLeasedProperties() {
    const leasedProperties: Array<LeasedProperty> = [
      { id:1, leaseStatusesId: 21, fileReference : 'MB012', type:'Land', propertyCode: '12354', facilityName: 'Facility 1', natureofLease:'Business', startingDate: new Date('01/01/2020'), terminationDate: new Date('01-01-2020') },
      { id:2, leaseStatusesId: 22, fileReference : 'MB013', type:'Land', propertyCode: '1235454', facilityName: 'Facility 2', natureofLease:'Residential', startingDate: new Date('5/10/2020'), terminationDate: new Date('5/10/2020') },
      { id:3, leaseStatusesId: 23, fileReference : 'MB014', type:'Land', propertyCode: '123544', facilityName: 'Facility 3', natureofLease:'Residential', startingDate: new Date('1/10/2020'), terminationDate: new Date('5/10/2020') },
      { id:4, leaseStatusesId: 24, fileReference : 'MB015', type:'Land', propertyCode: '12354', facilityName: 'Facility 4', natureofLease:'Business', startingDate: new Date('1/10/2020'), terminationDate: new Date('5/10/2020') },
    ];
    this.leasedProperties = leasedProperties;    
    this.dataIsLoaded = true;
    return leasedProperties;
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
