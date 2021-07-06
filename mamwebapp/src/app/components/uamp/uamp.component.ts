import { Component, OnInit,Input, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { Subject } from 'rxjs/internal/Subject';
import { first } from 'rxjs/operators';
import { MenuItem, MessageService, Message} from 'primeng/api';
import { UAMP } from 'src/app/models/uamp.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { UampService } from '../../services/uamp/uamp.service';
import { TempleteTwoPointOne } from 'src/app/models/templetes/templete-two-point-one.model';


@Component({
  selector: 'app-uamp',
  templateUrl: './uamp.component.html',
  styleUrls: ['./uamp.component.css'],  
  providers: [MessageService],
})
export class UampComponent implements OnInit, AfterViewInit {
  
  templeteTwoPointOne: TempleteTwoPointOne;
  properties: any[] = [];
  generatingUamp: boolean = true;
  value: number = 0;
  uamps: UAMP[];
  umapTemplete: any[];
  leasedPropertyCount: Number = 0;
  activeIndex: number = 0;
  stateOwnedPropertyCount: Number = 0;
  showDialog: Boolean = false;
  showUAMP: Boolean = false;
  currentUser: User; 
  uamp: UAMP;
  buttonItems: MenuItem[];
  templateOne: any;
  erMsgs: Message[];

  constructor(public messageService: MessageService, public uampService: UampService, private authenticationService: AuthenticationService) { 
    let interval = setInterval(() => {
      this.value = this.value + Math.floor(Math.random() * 10) + 1;
      if (this.value >= 100) {
          this.value = 100;
          clearInterval(interval);
      }
  }, 2000);
 
    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewUamp()
      },
      { separator: true },
      {label: 'Update', icon: 'pi pi-print', command: () => 
          this.updateUamp()
      }
  ];    
  }

  public ngAfterViewInit(): void
  {
  }
  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });
    this.getUamps();
  }
  selectUamp(uamp){
    this.uamp = uamp;    
  }

  viewUamp() {    
    this.showDialog = true;
    this.generatingUamp = true;
    this.value = 10;
    this.uampService.getUamp(this.uamp.id).subscribe(
      (response) => {                    
        this.uamp = response;
        this.generatingUamp = false;
      },
      (error) => {                        
        this.erMsgs = [{severity:'error', summary:'Error Occoured', detail:'Unable to get UAMP details'}];
        this.generatingUamp = false;
      }
    );
    
  }

  getUamps(){
    this.uamps = [];   
    this.uampService.getUamps(this.currentUser.department).subscribe(
      (response) => {                    
        this.uamps = response
      },
      (error) => {                        
        this.erMsgs = [{severity:'error', summary:'Error Occoured', detail:'Unable to get UAMPS for your department'}];
      }
    );
  }

  getUamp(id: Number){    
    this.uampService.getUamp(id).subscribe(
      (response) => {                    
        this.uamp = response;
        this.generatingUamp = false;
      },
      (error) => {                        
        this.erMsgs = [{severity:'error', summary:'Error Occoured', detail:'Unable to get UAMP details'}];
        this.generatingUamp = false;
      }
    );
  }

  updateUamp(){
    this.showUAMP = true;
    this.generatingUamp = true;
    this.value = 10;
    this.getUamp(this.uamp.id)   
    //this.uampService.assignUamp(this.uampbv n); 
   // this.templeteTwoPointOne = this.uamp.nativeElement.templeteTwoPointOne;   
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
   
    this.uampService.startuamp(uamp).pipe(first()).subscribe(uamp => {     
      this.generatingUamp = false;     
      this.uamp = uamp;
      //lk;ithis.uampService.assignUamp(this.uamp);  
     // this.templeteTwoPointOne = this.uamp.templeteTwoPointOne;
      this.messageService.add({severity:'success', summary:'Generate UAMP', detail:'UAMP has been generated successful.'});   
      this.showUAMP = true;
    });   
  }

  back(){
    let uamp : any = {};
    if(this.uamp){
      uamp = this.uamp;
    }
    
    this.uampService.assignUamp(uamp);
  }

  next(){
    let uamp : any = {};
    if(this.uamp){
      uamp = this.uamp;
    }
    this.uampService.assignUamp(uamp);
  }

  updatedUamp(data:UAMP){
    if(data){
      this.uamp = data;
    }
  }

  onSave(){    
    this.uamp.status = "Saved";
    this.uampService.saveUamp(this.uamp).pipe(first()).subscribe(uamp => {
      this.uamp = uamp;
      this.uampService.assignUamp(uamp);
      this.messageService.add({severity:'success', summary:'Save UAMP', detail:'UAMP has been saved successful.'}); 

      const foundUamp = this.uamps.filter(u => u.id == this.uamp.id).length;
      if(foundUamp == 0)
        this.uamps.push(this.uamp);
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
