import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { RadioButtonModule, RadioControlRegistry } from 'primeng/radiobutton';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.css'],
  providers: [MessageService, ConfirmationService, RadioControlRegistry]
})
export class AddEditProjectComponent implements OnInit {

  public hasParentChecked: false;
  public financeChecked: false;
  public loading = false;
  public detailsForm: FormGroup;
  public managedByForm: FormGroup;
  public supplierForm: FormGroup;
  public projects: Array<Project> = [];
  public projectList: any[] = [];
  public city: string;
  public projectsInProgress = 0;
  public serviceRequestsLogged = 0;
  public completedRequests = 0;
  public awaitingSignOff = 0;
  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public districts: any[] = [];
  public properties: any[] = [];
  public hasParentProject = false;
  public parentProjectHasFinance = false;
  public activeIndex = 0;
  public managedBylist: any[] = [];
  public supplierList: any[] = [];
  public supplierCols = [
    { field: 'supplier', header: 'Supplier' },
    { field: 'companyName', header: 'Company Name' },
    { field: 'companyNumber', header: 'Company Number' },
    { field: 'contactName', header: 'Contact Name' },
    { field: 'contactNumber', header: 'Contact Number' }
  ];
  
  constructor(private authenticationService: AuthenticationService, private formBuilder: FormBuilder
    ,         private sharedService: SharedService) {
  }

  ngOnInit() {

    this.buildForm();
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.districts = this.sharedService.getDistricts();
    this.properties = [
      { name: 'N1 repair', code: 'B', factor: 1 }
    ];

    this.managedBylist = this.sharedService.getManagedBylist();

    this.projectList = [
      { name: 'N1 repair', code: '1', factor: 1 }
    ];
  }

  get f() { return this.detailsForm.controls; }

  buildForm() {
    this.detailsForm = this.formBuilder.group({
      district: [''],
      property: [''],
      name: [''],
      city: [''],
      hasParentProject: [''],
      hasProjectFinance: [''],
      duration: [''],
      amount: [''],
      account: [''],
      startDate: [''],
      scope: [''],
      completionDate: ['']
    });

    this.managedByForm = this.formBuilder.group({
      managedBy: [''],
      name: [''],
      employeeCompanyNumber: [''],
      contactName: [''],
      contactNumber: [''],
    });

    this.supplierForm = this.formBuilder.group({
      supplier: [''],
      companyName: [''],
      companyNumber: [''],
      contactName: [''],
      contactNumber: [''],
    });
  }

  confirmDeleteProject() { }

  updateProject() { }

  viewProject() { }

  printProject() { }

  addProject() {

  }

  hasParentChange(e) {
    this.hasParentChecked = e.checked;
  }

  hasProjectFinanceChange(e) {
    this.financeChecked = e.checked;
  }

  onManagedByChange(e) {
    if (e.value === 'yes') {
      this.parentProjectHasFinance = true;
    } else {
      this.parentProjectHasFinance = false;
    }
  }

  supplierImprovement(){

  }

}
