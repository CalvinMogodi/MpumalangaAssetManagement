import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
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
  public serviceRequests: Array<Project> = [];
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
  messageService: any;
                    
  constructor(private authenticationService: AuthenticationService, private faultService: FaultService) { }

  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewServiceRequest()
      },
      { separator: true },
      {label: 'Close', icon: 'pi pi-times', command: () => 
          this.closeTicket()
      },
    /*  { separator: true },
      {label: 'Update', icon: 'pi pi-pencil', command: () => 
          this.updateProject()
      },*/
      {separator: true},
      {label: 'Delete', icon: 'pi pi-trash', command: () => 
          this.confirmDeleteProject()
      }]

      this.faultService.getFaults().subscribe(faults => {
        if (faults) {
          this.serviceRequests = faults;
        }
      },
      (error) => {
        this.messageService.add({ severity: 'error', summary: 'Error Occoured', detail: 'Unable to get fault' });
        this.isSuccessful = false;
      });

      const serviceRequest = {
        id: 0,
        'loggedDate': '14 June 2022',
        'location': 'N1 south',
        'description': 'There is big pothole N1 north that is the size on the baby grave.',
        'loggedBy':'John Joe',
        'status': 'New',
      }
      this.serviceRequests.push(serviceRequest);

  }

  confirmDeleteProject(){
      this.showdelete = true;
  }

  updateProject(){
    this.showDialog = true;
  }

  viewServiceRequest(){
    this.showDialog = true;
    this.canCloseTicket = false;
  }

  closeTicket(){
    this.showDialog = true;
    this.canCloseTicket = true;
  }

  addProject(){

  }

  selectFacility (){

  }

}
