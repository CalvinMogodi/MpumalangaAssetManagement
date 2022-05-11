import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

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

  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public cols = [
    { field: 'district', header: 'District' },
    { field: 'name', header: 'Name' },
    { field: 'managedBy', header: 'Managed By' },
    { field: 'status', header: 'Status' }
  ];

  buttonItems: MenuItem[]; 
                    
  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewProject()
      },
      { separator: true },
      {label: 'Print', icon: 'pi pi-print', command: () => 
          this.printProject()
      },
      { separator: true },
      {label: 'Update', icon: 'pi pi-pencil', command: () => 
          this.updateProject()
      },
      {separator: true},
      {label: 'Delete', icon: 'pi pi-trash', command: () => 
          this.confirmDeleteProject()
      }]

      const serviceRequest = {
        id: 0,
        'district': 'Ehlanzeni',
        'name': 'Faulty Traffic Lights',
        'managedBy': 'John Joe',
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

  viewProject(){
    this.showDialog = true;
  }

  printProject(){
    //this.showdelete = true;
  }

  addProject(){

  }

}
