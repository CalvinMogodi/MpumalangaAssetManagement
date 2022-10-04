import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Fault } from 'src/app/models/fault';
import { Project } from 'src/app/models/project.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FaultService } from 'src/app/services/facility-management/fault.service';
import { ProjectService } from 'src/app/services/facility-management/project.service';
import { SupplierService } from 'src/app/services/facility-management/supplier.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-view-service-request',
  templateUrl: './view-service-request.component.html',
  styleUrls: ['./view-service-request.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ViewServiceRequestComponent implements OnInit {

  @Input() canCloseTicket: boolean;
  @Input() selectedServiceRequest: Fault;
  @Output("closeServiceRequest") closeServiceRequest = new EventEmitter<any>();

  public isUpdated: boolean = false;
  public showSupplier = true;
  public projects: any[] = [];
  public showProject = true;
  public loading: boolean = false;
  public isViewOnly: boolean = false;
  public serviceRequests: Array<Project> = [];
  public errorMsg: string;
  public currentUser: User;
  public showDialog: boolean;
  public showAssets: boolean = false;
  public suppliers: any[] = [];
  public completionCertificate = false;
  public contractInvoice = false;
  public ticketHasCompletionCertificate: boolean = false;
  public ticketHasContractInvoice: boolean = false;

  constructor(private authenticationService: AuthenticationService, private sharedService: SharedService,
              private messageService: MessageService, private projectService: ProjectService, 
              private supplierService: SupplierService, private faultService: FaultService) { }

  ngOnInit() {

    this.ticketHasCompletionCertificate = this.selectedServiceRequest.hasCompletionCertificate;
    this.ticketHasContractInvoice = this.selectedServiceRequest.hasContractInvoice;
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.supplierService.getSuppliers().subscribe(suppliers => {
      if (suppliers.length > 0) {
        this.suppliers = [];
        suppliers.forEach(element => {
          const option = { name: element.companyName + ' - ' + element.companyNumber, code: element.id, factor: element.id };
          this.suppliers.push(option);
        });
      }
    },
      (error) => {
        //this.messageService.add({ severity: 'error', summary: 'Error Occoured', detail: 'Unable to get fault' });
        //this.isSuccessful = false;
      });

    this.projectService.getProjects().subscribe(projects => {
      if (projects.length > 0) {
        this.projects = [];
        projects.forEach(project => {
          const name = project.employeeName !== '' ? project.employeeName + ' - ' + project.employeeNumber
            : project.businessName + ' - ' + project.businessRegNumber;
          const option = { name: name, code: project.id, factor: project.id };
          this.projects.push(option);
        });
      }
    },
      (error) => {
        //this.isSuccessful = false;
      });

    if (this.canCloseTicket) {
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

  onCancel() {
    this.closeServiceRequest.emit({ isChild: true });
  }

  onSupplierChange(e) {
    this.showSupplier = true;
    this.showProject = false;
    this.selectedServiceRequest.supplierId = Number(e.value.code);
  }

  onProjectChange(e) {
    this.showProject = true;
    this.showSupplier = false;
    this.selectedServiceRequest.projectId = Number(e.value.code);
  }

  onCompletionCertificateChange(e) {
    this.selectedServiceRequest.hasCompletionCertificate = e.checked;
  }

  onContractInvoiceChange(e) {
    this.selectedServiceRequest.hasContractInvoice = e.checked;
  }

  onSubmit() {
    this.isUpdated = false;
    this.faultService.updateFault(this.selectedServiceRequest).pipe().subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Fault', 'Your fault has been submitted successfully.', 'success');
        this.isUpdated = true;
      } else {
        this.showToast('Report a Fault', 'Your fault has not been submitted successfully.', 'error');
      }
    },
      error => {
        this.messageService.add({
          severity: 'error', summary: 'Error Occurred',
          detail: 'An error occurred while processing your request. please try again!'
        });
        this.isUpdated = false;
      });
  }
  showToast(summary: string, detail: string, severity: string) {
    this.messageService.add({ severity, summary, detail });
  }


  onCloseicket() {
    this.isUpdated = false;
    this.selectedServiceRequest.status = 'Close';
    this.selectedServiceRequest.modifiedDate = new Date();
    this.faultService.updateFault(this.selectedServiceRequest).pipe().subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Fault', 'Your fault has been closed successfully.', 'success');
        this.isUpdated = true;
      } else {
        this.showToast('Report a Fault', 'Your fault has not been closed successfully.', 'error');
      }
    },
      error => {
        this.messageService.add({
          severity: 'error', summary: 'Error Occurred',
          detail: 'An error occurred while processing your request. please try again!'
        });
        this.isUpdated = false;
      });

  }


}