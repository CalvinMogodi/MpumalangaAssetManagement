import { Component, OnInit } from '@angular/core';
import { User } from 'mamwebapp/src/app/models/user.model';
import { Subject } from 'rxjs/internal/Subject';
import { first } from 'rxjs/operators';
import { Facility } from 'src/app/models/facility.model';
import { MenuItem, MessageService } from 'primeng/api';
import { UAMP } from 'src/app/models/uamp.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { UampService } from '../../services/uamp/uamp.service';

@Component({
  selector: 'app-uamp',
  templateUrl: './uamp.component.html',
  styleUrls: ['./uamp.component.css'],
  providers: [MessageService]
})
export class UampComponent implements OnInit {
  generatingUamp: boolean = true;
  value: number = 0;
  uamps: UAMP[];
  umapTemplete: any[];
  selectedUamp: UAMP;
  leasedPropertyCount: Number = 0;
  activeIndex: number = 0;
  stateOwnedPropertyCount: Number = 0;
  showDialog: Boolean = false;
  showUAMP: Boolean = false;
  currentUser: User; 
  umap: UAMP;
  buttonItems: MenuItem[];

  constructor(public messageService:MessageService, public uampService: UampService, private authenticationService: AuthenticationService) { 
    let interval = setInterval(() => {
      this.value = this.value + Math.floor(Math.random() * 10) + 1;
      if (this.value >= 100) {
          this.value = 100;
          clearInterval(interval);
      }
  }, 2000);
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.umap = value;
      }
    });
    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewUamp()
      },
      { separator: true },
      {label: 'Start UAMP', icon: 'pi pi-print', command: () => 
          this.startUamp()
      }
  ];    
  }

  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });
    this.getUamps();
  }
  selectUamp(uamp){
    this.selectedUamp = uamp;
  }

  viewUamp() {    
    this.showDialog = true;
  }

  getUamps(){
    this.uamps = [];
    this.uampService.getUamps(this.currentUser.department).pipe(first()).subscribe(uamps => {          
      this.uamps = uamps
    });
  }

  updateUamp(){
    this.showUAMP = true;
  }

  startUamp() {
    this.generatingUamp = true;
    let uamp:UAMP = {
      id: 0,
      status: 'New',
      fileReference: this.makeId(8),
      optimalSupportingAccommodationId: null,
      department: this.currentUser.department,
      createdDate: new Date(),
      userId: this.currentUser.id,
    };
    this.showUAMP = true;
    this.uampService.startuamp(uamp).pipe(first()).subscribe(uamp => {     
      this.generatingUamp = false;     
      this.selectedUamp = uamp;
      this.uampService.assignUamp(this.selectedUamp);  
      this.messageService.add({severity:'success', summary:'Generate UAMP', detail:'UAMP has been generated successful.'});   
    });   
  }
  next(){
    let umap : any = {};
    if(this.umap){
      umap = this.umap;
    }
    
    this.uampService.assignUamp(umap);
  }

  onSave(){
    this.umap.status = "Saved"
    this.uampService.createUamp(this.umap).pipe(first()).subscribe(umap => {
      this.umap = umap;
      this.uampService.assignUamp(umap);
      this.messageService.add({severity:'success', summary:'Save UAMP', detail:'UAMP has been saved successful.'}); 

      const foundUmap = this.uamps.filter(u => u.id == this.umap.id).length;
      if(foundUmap == 0)
        this.uamps.push(this.umap);
    });
  }

  onSubmit(){
    this.next();

  }

  makeId(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

}
