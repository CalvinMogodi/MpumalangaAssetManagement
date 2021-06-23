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
  styleUrls: ['./uamp.component.css']
})
export class UampComponent implements OnInit {
  uamps: UAMP[];
  umapTemplete: any[];
  selectedUamp: UAMP;
  leasedPropertyCount: Number = 0;
  activeIndex: number = 0;
  stateOwnedPropertyCount: Number = 0;
  showDialog: Boolean = false;
  showUAMP: Boolean = false;
  currentUser: User; 
  umap: any;
  buttonItems: MenuItem[];

  constructor(public uampService: UampService, private authenticationService: AuthenticationService) { 
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
    this.showUAMP = true;
  }
  next(){
    let umap : any = {};
    if(this.umap){
      umap = this.umap;
    }
    
    this.uampService.assignUamp(umap);
  }

  onSave(){
    this.next();
  }

  onSubmit(){
    this.next();

  }


}
