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

  val: string;
  val6: string;
  public isManagedByExternalCompany = false;
  public hasParentChecked: false;
  public financeChecked: false;
  public loading = false;
  public detailsForm: FormGroup;
  public managedByForm: FormGroup;
  public supplierForm: FormGroup;
  public projects: Array<Project> = [];
  public projectList: any[] = [];
  public suppliers: any[] = [];
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
  public selectedSupplierIndex = 0;
  public selectedSupplier: any;
  buttonItems: MenuItem[];
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

    this.buttonItems = [
      {label: 'Delete', icon: 'pi pi-trash', command: () => 
          this.deleteSupplier()
      }
  ];

    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.districts = this.sharedService.getDistricts();
    this.properties = [
      { name: 'N1 repair', code: 'B', factor: 1 }
    ];

    this.suppliers = [ { name: '1st Supplier', code: 'B', factor: 1 },
    { name: '2nd Supplier', code: 'B', factor: 2 },
    { name: '3th Supplier', code: 'B', factor: 3 }];

    this.managedBylist = this.sharedService.getManagedBylist();

    this.projectList = [
      { name: 'N1 repair', code: '1', factor: 1 }
    ];

    this.buildForm();
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

    const managedByEmployee = this.managedBylist[0];
    this.managedByForm = this.formBuilder.group({
      managedBy: [managedByEmployee],
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
    if (e.value.factor === 2) {
      this.isManagedByExternalCompany = true;
    } else {
      this.isManagedByExternalCompany = false;
    }
  }

  onAddSupplier() {
    const supplier = {
      supplier: this.supplierForm.controls.supplier.value !== undefined ? this.supplierForm.controls.supplier.value.name : null,
      companyName: this.supplierForm.controls.companyName.value,
      companyNumber: this.supplierForm.controls.companyNumber.value,
      contactName: this.supplierForm.controls.contactName.value,
      contactNumber: this.supplierForm.controls.contactNumber.value
    };

    this.supplierList.push(supplier);    
    this.supplierForm = this.formBuilder.group({
      supplier: [''],
      companyName: [''],
      companyNumber: [''],
      contactName: [''],
      contactNumber: [''],
    });
  }
  selectSupplier(supplier: any) {
    this.selectedSupplier = supplier;
  }

  deleteSupplier(){
    const index = this.supplierList.indexOf(this.selectedSupplier);
    this.supplierList.splice(index, 1);
  }
}
