import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { first } from 'rxjs/operators';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user/user.service';
import { MenuItem, MessageService } from 'primeng/api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';
import { ConfirmationService } from 'primeng/api';
import { FormControl } from '@angular/forms';
import { SharedService } from 'src/app/services/shared.service';
import { type } from 'os';
import { HiredProperty } from 'src/app/models/hired-property';

@Component({
  selector: 'app-hiring',
  templateUrl: './hiring.component.html',
  styleUrls: ['./hiring.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class HiringComponent implements OnInit {
  loading = false;
  isAdding = false;
  hiringForm: FormGroup;
  types: any = [];
  userDepartments: any[] = [];
  statuses: any[] = [];
  districts: any[] = [];
  buildingConditions: any[] = [];
  hiredProperty: HiredProperty;
  currentUser: User;

  showComfirmaDelete = false;
  showResetPasswordComfirmation: boolean = false;
  users: User[] = [];
  clonedUsers: User[] = [];
  cols: any[];
  items: MenuItem[];
  home: MenuItem;
  submitted = false;
  error = '';
  emailExsist: boolean = false;

  resetUser: User;
  selectedUser: User;
  index: any;
  showDialog: boolean = false;
  showConfirmResetPassword: boolean = false;
  msgs: any[] = [];
  newUserError: string = '';
  errorMsg: string = 'error';
  departments: any[] = [];
  selectedRole: Number = 0;
  buttonItems: MenuItem[];
  header: string = 'Add Candidate';

  constructor(private userService: UserService,
    private formBuilder: FormBuilder,
    private confirmationService: ConfirmationService,
    private authenticationService: AuthenticationService,
    private messageService: MessageService,
    private sharedService: SharedService) { }
  roles: any[];

  ngOnInit() {

    this.showToast('Update User', 'User has been updated successful.');
    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
    });

    this.buttonItems = [
      {
        label: 'View', icon: 'pi pi-eye', command: () =>
          this.viewProperty()
      }
    ];

    this.types = this.sharedService.getPropertyTypes();
    this.userDepartments = this.sharedService.getDepartments();
    this.statuses = this.sharedService.getHiringPropertyStatuses();
    this.districts = this.sharedService.getDistricts();
    this.buildingConditions = this.sharedService.getConditionRatings();
    
    this.hiringForm = this.formBuilder.group({
      district: new FormControl('', Validators.compose([Validators.required])),
      type: new FormControl('', Validators.compose([Validators.required])),
      propertyCode: new FormControl('', Validators.compose([Validators.required])),
      town: new FormControl('', Validators.compose([Validators.required])),
      rentalAmount: new FormControl('', Validators.compose([Validators.required])),
      startDate: new FormControl('', Validators.compose([Validators.required])),
      terminationDate: new FormControl('', Validators.compose([Validators.required])),
      address: new FormControl('', Validators.compose([Validators.required])),
      userDepartment: new FormControl('', Validators.compose([Validators.required])),
      status: new FormControl('', Validators.compose([Validators.required])),
      stuffNumber: new FormControl('', Validators.compose([Validators.required])),
      area: new FormControl('', Validators.compose([Validators.required])),
      escalationRate: new FormControl('', Validators.compose([Validators.required])),
      buildingCondition: new FormControl('', Validators.compose([Validators.required])),

      
    });

    this.items = [{ icon: 'pi pi-home', url: 'dashboard' },
    { label: 'Hiring Register' }];

    this.cols = [
      { field: 'propertyCode', header: 'Property code' },
      { field: 'typeofLeasedProperty', header: 'Type' },     
      { field: 'district', header: 'District' },
      { field: 'userDepartment', header: 'User Department' },
      { field: 'startDateofLease', header: 'Start Date of Lease' },
      { field: 'terminationDateofLease', header: 'Termination Date of Lease' },
      { field: 'status', header: 'Status' }    
    ];

    this.loading = false;   
  
  }

  viewProperty(){

  }

  get f() { return this.hiringForm.controls; }

  onSubmit(){

    const hiredProperty = {
      id: 0,
    type: this.hiringForm.controls["type"].value != undefined ? this.hiringForm.controls["type"].value.name : null,
    district: this.hiringForm.controls["district"].value != undefined ? this.hiringForm.controls["district"].value.name : null,
    propertyCode: this.hiringForm.controls["propertyCode"].value,
    startingDate: this.hiringForm.controls["startingDate"].value,
    terminationDate: this.hiringForm.controls["terminationDate"].value,
    monthlyRental: this.hiringForm.controls["monthlyRental"].value, 
    town: this.hiringForm.controls["town"].value,
    status: this.hiringForm.controls["status"].value != undefined ? this.hiringForm.controls["status"].value.name : null,
    userDepartment: this.hiringForm.controls["userDepartment"].value != undefined ? this.hiringForm.controls["userDepartment"].value.name : null,
    buildingCondition: this.hiringForm.controls["buildingCondition"].value != undefined ? this.hiringForm.controls["buildingCondition"].value.name : null,
    landlandAgentName: this.hiringForm.controls["landlandAgentName"].value,
    numberofStuff: this.hiringForm.controls["numberofStuff"].value,
    escalationRate: this.hiringForm.controls["escalationRate"].value,
    area: this.hiringForm.controls["area"].value,
    address: this.hiringForm.controls["address"].value,
    createdByUser: this.currentUser,
    createdUserId: this.currentUser.id,
    createdDate: new Date()
    }   
    
  }

  onRowEditSave(user: User) {
    if (user.name === undefined || user.name === '') {
      return;
    }

    if (user.surname === undefined || user.surname === '') {
      return;
    }

    if (this.validEmail(user.email, user.id)) {
      return;
    }

    this.userService.updateUser(user).pipe(first()).subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Update User', 'User has been updated successful.');
        this.loading = false;
      } else {
        this.showErrorToast('Update User', 'User has not been updated successful.');
        this.loading = false;
      }
    });
  }

  validEmail(str: string, id: number) {
    var email = str == undefined ? this.f.email.value : str;
    if (id != undefined) {//for edit
      if (str === undefined || str === '')
        return false
      else
        return this.users.filter(u => u.email.toLowerCase() == email.toLowerCase() && u.id != id).length > 0;
    } else { //for add      
      return this.users.filter(u => u.email.toLowerCase() == email.toLowerCase()).length > 0 ? this.emailExsist = true : this.emailExsist = false;
    }
  }

  onRowEditCancel() {
    let user = this.selectedUser;
    let index = this.index;
    this.users[index] = this.clonedUsers[user.id];
  }

  showToast(summary: string, detail: string) {
    this.messageService.add({ severity: 'success', summary: summary, detail: detail });
  }
  showErrorToast(summary: string, detail: string) {
    this.messageService.add({ severity: 'error', summary: summary, detail: detail });
  }

  setRole(e) {
    this.selectedRole = e.value.factor
  }

  onRowEditInit(e) { }

  editUser(user: User) {
    this.userService.updateUser(user).pipe().subscribe(newUser => {
      if (newUser) {
        this.users[this.index] = user;
        this.messageService.add({ severity: 'success', summary: 'Update User', detail: 'User has been updated successful.' });
      } else {
        this.messageService.add({ severity: 'error', summary: 'Update User', detail: 'User has been updated successful' });
      }
      this.showDialog = false;
      this.isAdding = false;
    },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
        this.error = error;
        this.isAdding = false;
      });
  }

  addUser(user: User) {
    this.userService.addUser(user).pipe().subscribe(newUser => {
      if (newUser.id != 0) {
        this.users.push(newUser);
        this.showToast('Add User', 'User has been added successful');
      } else {
        this.messageService.add({ severity: 'error', summary: 'Add User', detail: 'User is not added successful.' });
      }
      this.showDialog = false;
      this.isAdding = false;
    },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
        this.error = error;
        this.isAdding = false;
      });
  }

  resetPassword() {
    var randomstring = Math.random().toString(36).slice(-8);
    this.userService.resetPassword(this.resetUser.username, randomstring).pipe(first()).subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Reset Password', 'Please check your email to reset your password');
        this.loading = false;
      } else {
        this.messageService.add({ severity: 'error', summary: 'Reset Password', detail: 'Failed to reset your password.' });
        this.loading = false;
      }
    }, error => {
      this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
      this.loading = false;
    });
  }

  deleteUser() {
    this.userService.deleteUser(this.selectedUser).pipe(first()).subscribe(isDeleted => {
      if (isDeleted) {
        this.messageService.add({ severity: 'warn', summary: 'Delete User', detail: 'User has been deleted successful.' });
        this.users.splice(this.index, 1);
      } else {
        this.messageService.add({ severity: 'error', summary: 'Delete User', detail: 'User is not deleted successful.' });
      }
      this.loading = false;
    }, error => {
      this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
    });
  }

  confirmResetPassword(user) {
    this.resetUser = user;
    this.showResetPasswordComfirmation = true;
  }

  confirmDelete() {
    this.showComfirmaDelete = true;
  }

  update() {
    this.header = 'Edit User';
    this.showDialog = true;
    this.selectedRole = this.selectedUser.roleId;
    let role = this.roles.filter(u => u.factor == this.selectedUser.roleId)[0];
    let department = this.departments.filter(u => u.name == this.selectedUser.department)[0];
    this.hiringForm = this.formBuilder.group({
      name: new FormControl(this.selectedUser.name, Validators.compose([Validators.required])),
      surname: new FormControl(this.selectedUser.surname, Validators.compose([Validators.required])),
      email: new FormControl(this.selectedUser.email, Validators.compose([Validators.required, Validators.email])),
      role: new FormControl(role, Validators.compose([Validators.required])),
      department: new FormControl(department)
    });
  }

  selectUser(user: User, index: Number) {

    this.selectedUser = user;
    this.index = index;
  }
}
