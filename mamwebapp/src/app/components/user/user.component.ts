import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { first } from 'rxjs/operators';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user/user.service';
import { MenuItem, MessageService } from 'primeng/api';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';
import { ConfirmationService } from 'primeng/api';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class UserComponent implements OnInit {
  loading = false;
  isAdding = false;
  showComfirmaDelete = false;
  showResetPasswordComfirmation: boolean = false;
  users: User[] = [];
  clonedUsers: User[] = [];
  cols: any[];
  items: MenuItem[];
  home: MenuItem;
  addUserForm: FormGroup;
  submitted = false;
  error = '';
  emailExsist: boolean = false;
  currentUser: User;
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
  header: string = 'Add User';

  constructor(private userService: UserService,
    private formBuilder: FormBuilder,
    private confirmationService: ConfirmationService,
    private authenticationService: AuthenticationService,
    private messageService: MessageService,
    private changeDetectionRef: ChangeDetectorRef) { }
  roles: any[];

  ngOnInit() {
    this.showToast('Update User', 'User has been updated successful.');
    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
    });

    this.buttonItems = [
      {
        label: 'Update', icon: 'pi pi-pencil', command: () =>
          this.update()
      },
      { separator: true },
      {
        label: 'Delete', icon: 'pi pi-trash', command: () =>
          this.confirmDelete()
      }
    ];

    this.roles = [
      { name: 'Viewer', code: 'V', factor: 1 },
      { name: 'Administrator', code: 'SA', factor: 2 },
      { name: 'Capturer', code: 'C', factor: 3 },
      { name: 'Approver', code: 'A', factor: 5 },
      { name: 'Verifier', code: 'DV', factor: 4 },
      { name: 'Manager', code: 'M', factor: 6 },
      { name: 'Department user', code: 'D', factor: 7 },

    ];
    this.departments = [
      { name: 'Agriculture, rural development, land & environmental affairs', code: 'ARALEA', factor: 1 },
      { name: 'Economic development & tourism', code: 'EDT', factor: 2 },
      { name: 'Co-operative governance & traditional affairs', code: 'CGTA', factor: 3 },
      { name: 'Community safety, security & liason', code: 'CSSL', factor: 4 },
      { name: 'Culture, sport & recreation', code: 'CSR', factor: 5 },
      { name: 'Education', code: 'E', factor: 6 },
      { name: 'Provincial treasury', code: 'PT', factor: 7 },
      { name: 'Health', code: 'H', factor: 8 },
      { name: 'Human settlements', code: 'HS', factor: 9 },
      { name: 'Social development', code: 'SD', factor: 10 },
      { name: 'Public works, roads & transport', code: 'PWRT', factor: 11 },
      { name: 'Finance', code: 'F', factor: 11 },
    ];

    this.addUserForm = this.formBuilder.group({
      name: new FormControl('', Validators.compose([Validators.required])),
      surname: new FormControl('', Validators.compose([Validators.required])),
      email: new FormControl('', Validators.compose([Validators.required, Validators.email])),
      role: new FormControl('', Validators.compose([Validators.required])),
      department: new FormControl('')
    });

    this.items = [{ icon: 'pi pi-home', url: 'dashboard' },
    { label: 'Users' }];

    this.cols = [
      { field: 'name', header: 'Name' },
      { field: 'surname', header: 'Surname' },
      { field: 'email', header: 'Email' },
      { field: 'createdDate', header: 'Created Date' },
      { field: 'role', header: 'Role', element: true },
      { field: 'department', header: 'Department', element: true },
    ];

    this.loading = true;
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.loading = false;
      this.users = users;
      this.clonedUsers = users;
    });
  }

  get f() { return this.addUserForm.controls; }

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

  onSubmit() {
    this.submitted = true;
    this.isAdding = false;

    // stop here if form is invalid
    if (this.addUserForm.invalid) {
      return;
    }
    var randomstring = Math.random().toString(36).slice(-8);

    this.isAdding = true;
    var user: User = {
      id: undefined,
      username: this.f.email.value,
      password: randomstring,
      name: this.f.name.value,
      surname: this.f.surname.value,
      roleId: this.addUserForm.controls["role"].value.factor,
      role: this.addUserForm.controls["role"].value,
      department: this.addUserForm.controls["department"].value != undefined ? this.addUserForm.controls["department"].value.name : null,
      isActive: true,
      email: this.f.email.value,
      passwordIsChanged: false,
      createdDate: new Date,
      createdUserId: this.currentUser.id
    }
    if (this.header == 'Add User') {
      this.addUser(user);
    } else {
      user.id = this.selectedUser.id;
      this.editUser(user);
    }
  }

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
    this.addUserForm = this.formBuilder.group({
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
