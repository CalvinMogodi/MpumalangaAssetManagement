import { Component, Input, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-view-service-request',
  templateUrl: './view-service-request.component.html',
  styleUrls: ['./view-service-request.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ViewServiceRequestComponent implements OnInit {

  @Input() canCloseTicket: boolean;
  @Input() selectedServiceRequest: any;
  public loading: boolean = false;
  public isViewOnly: boolean = false;
  public serviceRequests: Array<Project> = [];
  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public showAssets: boolean = false;
  public suppliers:any[] = [];
  public completionCertificate = false;
  public contractInvoice = false;
  public ticketHasCompletionCertificate:boolean = false;
  public ticketHasContractInvoice:boolean = false;
                    
  constructor(private authenticationService: AuthenticationService, private sharedService: SharedService) { }

  ngOnInit() {
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });   

    if(this.canCloseTicket){
      this.ticketHasCompletionCertificate = true;
      this.ticketHasContractInvoice = true;
    }
   

    this.suppliers = [
      { name: 'Property 1', code: 'B', factor: 1 },
      { name: 'Property 2', code: 'M', factor: 2 },
      { name: 'Property 3', code: 'N', factor: 3 },
      { name: 'Property 4', code: 'TC', factor: 4 },
    ];
  }

  onDistrictChange(e) {
  }  
}
