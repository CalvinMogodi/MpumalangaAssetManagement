import { ChangeDetectorRef, Component, OnInit, Input, OnChanges, OnDestroy } from '@angular/core';
import { first } from 'rxjs/operators';
import { FacilityService } from '../../services/facility/facility.service';
import { MenuItem, MessageService } from 'primeng/api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';
import { ConfirmationService } from 'primeng/api';
import { Facility, Land } from 'src/app/models/facility.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-assetregister',
  templateUrl: './assetregister.component.html',
  styleUrls: ['./assetregister.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class AssetregisterComponent implements OnInit  {
  loading = false;
  showPrintDialog: boolean= false;
  dialogHeader:string = '';  
  printDialogHeader: string = '';
  showdelete: boolean = false;
  @Input() selectedAsset: any
  buttonItems: MenuItem[];
  facility: Facility;
  newCaptured = 0;
  awaitingAppoval = 0;
  awaitingVerification = 0;
  deleting = false;
  home: MenuItem;
  showDialog: boolean = false;
  errorMsg: string;
  mode: string = 'Add'; 
  error = '';
  items = [
    { label: 'Dashboard', url: 'dashboard' },
    { label: 'Asset Register' }];
  cols = [
    { field: 'fileReference', header: 'File Reference' },
    { field: 'clientCode', header: 'Property Code' },
    { field: 'status', header: 'Status' }
  ];
  facilities = [];
  landTotal: number = 0;
  buildingTotal:number = 0;
  
  constructor(private confirmationService: ConfirmationService,  public facilityService: FacilityService, private formBuilder: FormBuilder, private messageService: MessageService) { }

  ngOnInit() {
    this.buttonItems = [
      {label: 'Print', icon: 'pi pi-print', command: () => 
          this.print()
      },
      {label: 'Update', icon: 'pi pi-pencil', command: () => 
          this.update()
      },
      {separator: true},
      {label: 'Delete', icon: 'pi pi-trash', command: () => 
          this.confirmDelete()
      }
  ];
    this.home = {icon: 'pi pi-home'};    
    this.facilityService.getAllFacilities().pipe(first()).subscribe(facilities => {
      this.loading = false;
      this.facilities = facilities;
      this.landTotal = facilities.filter(f => f.type == "Land").length;
      this.buildingTotal = facilities.filter(f => f.type != "Land").length;
    });
  }

  someAction(facility){
    this.facility = facility;
  }

  addFacility(){
    this.selectedAsset = {
      mode : 'Add',
      facilityId: undefined,
      facilityType: undefined
    };
    this.showDialog = true;
  }  

  update() {
    this.showDialog = false;
    if(this.facility != undefined){
      this.dialogHeader = this.facility.type + ' ' + this.facility.clientCode;
      this.selectedAsset = {
        mode : 'Edit',
        facilityId: this.facility.id,
        facilityType: this.facility.type,
        facility: this.facility
      };
      this.showDialog = true;
    }    
  }

  print() {
    this.showPrintDialog = false;
    if(this.facility != undefined){
      this.printDialogHeader = this.facility.type + ' ' + this.facility.clientCode;
      this.selectedAsset = this.facility
      this.showPrintDialog = true;
    }    
  }

  confirmDelete() {  

    this.showdelete = true;
     /* this.confirmationService.confirm({
          message: 'Are you sure that you want to delete this asset?',
          accept: () => {
            this.deleting = true;
            this.deleteFacility(this.facility);
          }
      });   */  
  }

  deleteFacility(){
    let facility = this.facility;
    this.facilityService.deleteFacility(facility.id).pipe(first()).subscribe(isDeleted => {
      if(isDeleted){
        this.deleting = false;
        this.messageService.add({severity:'warn', summary:'Deleted', detail:'Asset is deleted successful.'});
        this.facilities = this.facilities.filter(f => f.id != facility.id);
        this.landTotal = this.facilities.filter(f => f.facilityType == "Land" && f.Id != facility.id).length;
        this.buildingTotal = this.facilities.filter(f => f.facilityType != "Land" && f.Id != facility.id).length;
      }
      else{
        this.deleting = false;
        this.messageService.add({severity:'error', summary:'Error', detail:'An error occurred while delete asset.'});
      }   
      this.showdelete = false;  
    });
  }

  selectFacility(facility){
    this.facility = facility;
  }

  addUpdateAsset(e){
    if(e.response = "isAddedSuccessful"){
      this.showDialog = false;
      this.facilities.push(e.data)
    }else if(e.response = "isUpdatedSuccessful"){
      
    }
  }
  
    
}
