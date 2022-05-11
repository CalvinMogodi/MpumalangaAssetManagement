import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class AddEditProjectComponent implements OnInit {

  public loading: boolean = false;
  public projectForm: FormGroup;
  public projects: Array<Project> = [];
  public projectsInProgress: number = 0;
  public serviceRequestsLogged: number = 0;
  public completedRequests: number = 0;
  public awaitingSignOff: number = 0;
  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public districts:any[] = [];
  public properties:any[] = [];
  public stateOptions: any[] = [];
  public state1Options:any[] = [];
  public hasParentProject:boolean = false;
  public parentProjectHasFinance:boolean = false;

  constructor(private authenticationService: AuthenticationService, private formBuilder: FormBuilder, private sharedService: SharedService) { 
    this.stateOptions = [{label: 'Yes', value: 'yes'}, {label: 'No', value: 'no'}];
    this.state1Options = [{label: 'Yes', value: 'yes'}, {label: 'No', value: 'no'}];
  }

  ngOnInit() {

    this.buildForm();
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.districts = this.sharedService.getDistricts();
    this.properties = [
      { name: 'Property 1', code: 'B', factor: 1 },
      { name: 'Property 2', code: 'M', factor: 2 },
      { name: 'Property 3', code: 'N', factor: 3 },
      { name: 'Property 4', code: 'TC', factor: 4 },
    ];
  }

  get f() { return this.projectForm.controls; }

  buildForm() {
    this.projectForm = this.formBuilder.group({
      district:[''],
      property:[''],
      name:[''],
      duration: [''],
      amount: [''],
      account: [''],});
    }

  confirmDeleteProject() { }

  updateProject() { }

  viewProject() { }

  printProject() { }

  addProject() {

  }

  onStateOptions(e){
    if(e.value == 'yes'){
      this.hasParentProject = true;
    }else{
      this.hasParentProject = false;
    }
  }

  onState1Options(e){
    if(e.value == 'yes'){
      this.parentProjectHasFinance = true;
    }else{
      this.parentProjectHasFinance = false;
    }
  }

}
