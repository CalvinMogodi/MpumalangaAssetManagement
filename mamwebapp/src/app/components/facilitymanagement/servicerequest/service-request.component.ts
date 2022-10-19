import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Fault } from 'src/app/models/fault.model';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FaultService } from 'src/app/services/facility-management/fault.service';

@Component({
  selector: 'app-service-request',
  templateUrl: './service-request.component.html',
  styleUrls: ['./service-request.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ServiceRequestComponent implements OnInit {

  public loading: boolean = false;
  public showdelete:boolean = false;
  public serviceRequests: Array<Fault> = [];
  public selectedServiceRequest: Fault;
  public canCloseTicket = false;
  public showReportFaultDialog = false;
  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public cols = [
    { field: 'createdDate', header: 'Logged Date' },
    { field: 'propertyDescription', header: 'Property Description' },
    { field: 'incidentDescription', header: 'Description' },
    { field: 'contactName', header: 'Logged By' },
    { field: 'status', header: 'Status' }
  ];

  buttonItems: MenuItem[]; 
  status: any;
  isSuccessful: boolean;
                    
  constructor(private authenticationService: AuthenticationService, private faultService: FaultService,
              private messageService: MessageService) { }

  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewServiceRequest()
      }     
    ];

    this.faultService.getFaults().subscribe(faults => {
        if (faults) {
          faults.forEach(element => {
            switch (element.status) {
              case 'Closed':
                element.status = 'red';
                break;
              case 'New':
                  element.status = 'green';
                  break;
              default:
                element.status = 'orange';
                break;
            }
          });
          this.serviceRequests = faults;
        }
      },
      (error) => {
        this.messageService.add({ severity: 'error', summary: 'Error Occoured', detail: 'Unable to get fault' });
        this.isSuccessful = false;
      });
  }

  confirmDeleteProject(){
      this.showdelete = true;
  }

  updateProject(){
    this.showDialog = true;
  }

  closeServiceRequest(e){
    if (e.isChild) {
      this.showDialog = false;
    }
  }

  viewServiceRequest(){
    if (this.selectedServiceRequest.status === 'New') {
      this.selectedServiceRequest.status = 'In Progress';
      this.selectedServiceRequest.modifiedDate = new Date();
      this.faultService.updateFault(this.selectedServiceRequest).pipe().subscribe(isUpdated =>{
        if (isUpdated) {
          this.showDialog = true;
          this.canCloseTicket = false;
        }
      });
    } else {
      this.showDialog = true;
      this.canCloseTicket = false;
    }
  }

  closeTicket(){
    this.showDialog = true;
    this.canCloseTicket = true;
  }

  addProject(){

  }

  selectFacility (selectedServiceRequest: Fault) {   
    this.selectedServiceRequest = selectedServiceRequest;
  }

  showToast(summary: string, detail: string, severity: string) {
    this.messageService.add({ severity, summary, detail });
  }

  onDeleteFault(){
    this.faultService.deleteFault(this.selectedServiceRequest).pipe().subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Fault', 'Your fault has been deleted successfully.', 'success');
        const index = this.serviceRequests.indexOf(this.selectedServiceRequest);
        this.serviceRequests.splice(index, 1);
      } else {
        this.showToast('Report a Fault', 'Your fault has not been deleted successfully.', 'error');
      }
      this.showdelete = false;
    },
      error => {
        this.messageService.add({
          severity: 'error', summary: 'Error Occurred',
          detail: 'An error occurred while processing your request. please try again!'
        });
      });
  }

}
