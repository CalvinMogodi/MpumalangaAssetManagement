import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-facility',
  templateUrl: './facility.component.html',
  styleUrls: ['./facility.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class FacilityComponent implements OnInit {

  public loading: boolean = false;
  public projects: Array<Project> = [];
  public projectsInProgress: number = 0;
  public serviceRequestsLogged: number = 0;
  public completedRequests: number = 0;
  public awaitingSignOff: number = 0;
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
  
  public items: any = [ { icon: 'pi pi-home',url: 'dashboard' },
                        { label: 'Facility Management' }
                      ];

                    
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

  }

  confirmDeleteProject(){}

  updateProject(){}

  viewProject(){}

  printProject(){}

  addProject(){

  }

}
