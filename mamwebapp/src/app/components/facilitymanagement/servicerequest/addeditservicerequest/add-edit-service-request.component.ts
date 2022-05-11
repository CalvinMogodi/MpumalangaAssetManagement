import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-service-request',
  templateUrl: './add-edit-service-request.component.html',
  styleUrls: ['./add-edit-service-request.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class AddEditServiceRequestComponent implements OnInit {

  public loading: boolean = false;
  public serviceRequests: Array<Project> = [];
  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public showAssets: boolean = false;
  public districts:any[] = [];
  public properties:any[] = [];
                    
  constructor(private authenticationService: AuthenticationService, private sharedService: SharedService) { }

  ngOnInit() {
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

  onDistrictChange(e) {
  }

  
}
