import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { RadioControlRegistry } from 'primeng/radiobutton';
import { Project } from 'src/app/models/project.model';
import { Supplier } from 'src/app/models/supplier';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ProjectService } from 'src/app/services/facility-management/project.service';
import { SupplierService } from 'src/app/services/facility-management/supplier.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.css'],
  providers: [MessageService, ConfirmationService, RadioControlRegistry]
})
export class AddEditProjectComponent implements OnInit {

  public project: Project;
  public isSuccessful = false;
  public projectForm: FormGroup;

  val: string;
  val6: string;
  public isManagedByExternalCompany = false;
  public hasParentChecked: false;
  public financeChecked: false;
  public loading = false;

  public managedByForm: FormGroup;
  public supplierForm: FormGroup;
  public projects: Array<Project> = [];
  public projectList: any[] = [];
  public suppliers: any[] = [];
  public supplierDropdownOptions: any[] = [];

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
  public selectedSupplierIndex = 0;
  public selectedSupplier:any =  {
    companyName: '',
    companyNumber: '',
    contactName: '',
    contactNumber: '',
  };
  buttonItems: MenuItem[];
  public supplierCols = [
    { field: 'supplier', header: 'Supplier' },
    { field: 'companyName', header: 'Company Name' },
    { field: 'companyNumber', header: 'Company Number' },
    { field: 'contactName', header: 'Contact Name' },
    { field: 'contactNumber', header: 'Contact Number' }
  ];

  getOrderNumber(length): string {
    let result = '';
    const characters = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  constructor(private authenticationService: AuthenticationService, private formBuilder: FormBuilder,
              private supplierService: SupplierService, private sharedService: SharedService,
              private projectService: ProjectService, private messageService: MessageService) {
    this.project = {
      id: 0,
      orderNumber: this.getOrderNumber(7),
      district: '',
      propertyId: 0,
      name: '',
      plannedDuration: '',
      startDate: new Date,
      practicalCompletionDate: new Date(),
      scopeofWork: '',
      hasFinancials: false,
      hasParentProject: false,
      parentProjectId: null,
      amount: 0,
      account: 0,
      managedBy: '',
      employeeName: '',
      employeeNumber: null,
      contactName: '',
      contactNumber: '',
      businessName: '',
      businessRegNumber: '',
      createdDate: new Date(),
      modifiedDate: null,
      suppliers: [],
      isDeleted: false,
      status: 'New'
    };
  }

  ngOnInit() {

    this.buttonItems = [
      {
        label: 'Delete', icon: 'pi pi-trash', command: () =>
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

    this.supplierService.getSuppliers().subscribe(suppliers => {
      if (suppliers.length > 0) {
        this.suppliers = suppliers;
        this.supplierDropdownOptions = [];
        suppliers.forEach(element => {
           const option = { name: element.companyName + ' - ' + element.companyNumber , code: element.id, factor: 1 };
           this.supplierDropdownOptions.push(option);
        });
      }
    },
    (error) => {
      this.messageService.add({ severity: 'error', summary: 'Error Occoured', detail: 'Unable to get fault' });
      this.isSuccessful = false;
    });

    this.projectService.getProperties().subscribe(propertyList => {
      if (propertyList.length > 0) {

        this.properties = [];
        propertyList.forEach(element => {
           const option = { name: element.clientCode + ' - ' + element.name, code: element.id, factor: element.id };
           this.properties.push(option);
        });
      }
    },
    (error) => {
      this.messageService.add({ severity: 'error', summary: 'Error Occoured', detail: 'Unable to get fault' });
      this.isSuccessful = false;
    });

    this.managedBylist = this.sharedService.getManagedBylist();

    this.projectList = [
      { name: 'N1 repair', code: '1', factor: 1 }
    ];

    this.buildForm();
  }

  get f() { return this.projectForm.controls; }

  buildForm() {
    this.projectForm = this.formBuilder.group({
      district: [''],
      property: [''],
      name: [''],
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

  saveDetails() {
    switch (this.activeIndex) {
      case this.activeIndex = 0:
        if (this.projectForm.valid) {
          this.assignProject();
          this.addProject();
        }
        break;
      case this.activeIndex = 1:
          if (this.managedByForm.valid) {
            this.assignManager();
            this.updateProject();
          }
          break;
    }
  }
  confirmDeleteProject() { }

  updateProject() {
    this.projectService.updateProject(this.project).pipe().subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Add project', 'Your data is saved successfully.', 'success');
        this.isSuccessful = true;
        this.activeIndex = this.activeIndex + 1;
      } else {
        this.showToast('Add project', 'Your data is not saved successfully.', 'error');
      }
    },
      error => {
        this.messageService.add({
          severity: 'error', summary: 'Error Occurred',
          detail: 'An error occurred while processing your request. please try again!'
        });
        this.isSuccessful = false;
      });
   }

  viewProject() { }

  printProject() { }

  onSaveSuppliers() {
    if (this.project.suppliers.length > 0) {
      this.addSuppliers();
    }
  }

  addSuppliers(){
    this.projectService.updateProject(this.project).pipe().subscribe(project => {
      if (project) {
        this.showToast('Add project', 'Your project details has been saved successfully.', 'success');
        this.isSuccessful = true;
        this.activeIndex = this.activeIndex + 1;
        this.project = project;
      } else {
        this.showToast('Add project', 'Your project details has not been saved successfully.', 'error');
      }
    },
      error => {
        this.messageService.add({
          severity: 'error', summary: 'Error Occurred',
          detail: 'An error occurred while processing your request. please try again!'
        });
        this.isSuccessful = false;
      });
  }

  addProject() {
    this.projectService.addProject(this.project).pipe().subscribe(id => {
      if (id > 0) {
        this.project.id = id;
        this.showToast('Add project', 'Your project details has been saved successfully.', 'success');
        this.isSuccessful = true;
        this.activeIndex = this.activeIndex + 1;
      } else {
        this.showToast('Add project', 'Your project details has not been saved successfully.', 'error');
      }
    },
      error => {
        this.messageService.add({
          severity: 'error', summary: 'Error Occurred',
          detail: 'An error occurred while processing your request. please try again!'
        });
        this.isSuccessful = false;
      });
  }

  assignManager(){
    if (this.isManagedByExternalCompany) {
      this.project.businessName = this.managedByForm.controls['name'].value;
      this.project.businessRegNumber = this.managedByForm.controls['employeeCompanyNumber'].value;
    } else {
      this.project.employeeName = this.managedByForm.controls['name'].value;
      this.project.employeeNumber = Number(this.managedByForm.controls['employeeCompanyNumber'].value);
    }

    this.project.contactName = this.managedByForm.controls['contactName'].value;
    this.project.contactNumber = this.managedByForm.controls['contactNumber'].value;
  }

  assignProject() {

    this.project.name = this.projectForm.controls['name'].value;
    this.project.plannedDuration = this.projectForm.controls['duration'].value;
    this.project.amount = this.projectForm.controls['amount'].value != '' ? Number(this.projectForm.controls['amount'].value) : null;
    this.project.account = this.projectForm.controls['amount'].value != '' ? this.projectForm.controls['account'].value : null;
    this.project.startDate = this.projectForm.controls['startDate'].value;
    this.project.scopeofWork = this.projectForm.controls['scope'].value;
    this.project.practicalCompletionDate = this.projectForm.controls['completionDate'].value;

    return this.project;

  }

  onDistrictChange(e: any) {
    this.project.district = e.value.name;
  }

  onPropertyChange(e: any) {
    this.project.propertyId = Number(e.value.code);
  }

  hasParentChange(e) {
    this.hasParentChecked = e.checked;
    this.project.hasParentProject = e.checked;
  }

  hasProjectFinanceChange(e) {
    this.financeChecked = e.checked;
    this.project.hasFinancials = e.checked;
  }

  onManagedByChange(e) {
    if (e.value.factor === 2) {
      this.isManagedByExternalCompany = true;
    } else {
      this.isManagedByExternalCompany = false;
    }
  }

  onSupplierChange(e){
    this.selectedSupplier = e.value;
  }

  onAddSupplier() {
    const supplier = this.suppliers.filter(s => s.id === this.selectedSupplier.code)[0];
    this.project.suppliers.push(supplier);
  }

  selectSupplier(supplier: any) {
    this.selectedSupplier = supplier;
  }

  deleteSupplier() {
    const index = this.project.suppliers.indexOf(this.selectedSupplier);
    this.project.suppliers.splice(index, 1);
  }

  showToast(summary: string, detail: string, severity: string) {
    this.messageService.add({ severity, summary, detail });
  }
}
