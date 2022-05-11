import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ProjectComponent implements OnInit {

  public loading: boolean = false;
  public projects: Array<Project> = [];
  public showdelete:boolean = false;
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

  public items: any = [{ icon: 'pi pi-home', url: 'dashboard' },
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
      {
        label: 'Print', icon: 'pi pi-print', command: () =>
          this.printProject()
      },
      { separator: true },
      {
        label: 'Update', icon: 'pi pi-pencil', command: () =>
          this.updateProject()
      },
      { separator: true },
      {
        label: 'Delete', icon: 'pi pi-trash', command: () =>
          this.confirmDeleteProject()
      }];
    const project = {
      id: 0,
      'district': 'Ehlanzeni',
      'name': 'N1 repair',
      'managedBy': 'John Joe',
      'status': 'In Process',
    }
    this.projects.push(project);

  }

  confirmDeleteProject() {
    this.showdelete = true;
   }

  updateProject() { }

  viewProject() { }

  printProject() { }

  addProject() {

  }

}
