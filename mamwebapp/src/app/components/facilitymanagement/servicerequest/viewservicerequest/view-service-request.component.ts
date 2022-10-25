import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { flatMap } from 'rxjs/operators';
import { FaultNote } from 'src/app/models/fault-note.model';
import { Fault } from 'src/app/models/fault.model';
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
  @Output('closeServiceRequest') closeServiceRequest = new EventEmitter<any>();

  public checked: boolean = true;
  public supplierCheckbox: boolean = false;
  public projectCheckbox: boolean = false;
  public isUpdated: boolean = false;
  public note: string = '';
  public showSupplier = true;
  public showClose = false;
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
  public supplier: any = {};
  public project: any = {};
  public completionCertificate: any;
  public contractInvoice: any;
  public ticketHasCompletionCertificate: boolean = false;
  public ticketHasContractInvoice: boolean = false;
  public attachments: any = [];
  public showCompletionCertificateUrl = false;
  public showContractInvoiceUrl = false;

  constructor(private authenticationService: AuthenticationService, private sharedService: SharedService,
    private messageService: MessageService, private projectService: ProjectService,
    private supplierService: SupplierService, private faultService: FaultService) { }

  ngOnInit() {
    this.getFiles(this.selectedServiceRequest.referenceNo + '_' + this.selectedServiceRequest.id);

    this.ticketHasCompletionCertificate = this.selectedServiceRequest.hasCompletionCertificate;
    this.ticketHasContractInvoice = this.selectedServiceRequest.hasContractInvoice;
    this.supplierCheckbox = this.selectedServiceRequest.supplierId == null ? false : true;
    this.projectCheckbox = this.selectedServiceRequest.projectId == null ? false : true;
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    this.supplierService.getSuppliers().subscribe(suppliers => {
      if (suppliers.length > 0) {
        this.suppliers = [];
        suppliers.forEach(element => {
          const option = { name: element.companyName + ' - ' + element.companyNumber, code: element.id, factor: element.id };
          this.suppliers.push(option);
          if (option.code === this.selectedServiceRequest.supplierId) {
            this.supplier = option;
          }
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
          const option = { name: project.name, code: project.id, factor: project.id };
          this.projects.push(option);
          if (option.code === this.selectedServiceRequest.projectId) {
            this.project = option;
          }
        });
      }
    },
      (error) => {
        //this.isSuccessful = false;
      });

    if (this.selectedServiceRequest.hasCompletionCertificate) {
      this.showCompletionCertificateUrl = true;
    }

    if (this.selectedServiceRequest.hasContractInvoice) {
      this.showContractInvoiceUrl = true;
    }

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
    const now = new Date();
    const today = new Date(now.setHours(now.getHours() + 2));
    this.selectedServiceRequest.faultNotes.forEach(element => {
      if(element.id < 1){
        element.createdDate = today;
      }
    });
    this.faultService.updateFault(this.selectedServiceRequest).pipe().subscribe(isUpdated => {
      if (isUpdated) {
        if (this.selectedServiceRequest.hasCompletionCertificate && this.completionCertificate) {
          this.uploadCompletionCertificate();
        }

        if (this.selectedServiceRequest.hasCompletionCertificate && this.contractInvoice) {
          this.uploadContractInvoice();
        }

        this.showToast('Fault', 'Your fault has been submitted successfully.', 'success');
        this.isUpdated = true;
        this.onCancel();
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

  showCloseTicket() {
    if (!this.selectedServiceRequest.supplierId && !this.selectedServiceRequest.projectId)
      return false;

    if (!this.selectedServiceRequest.hasCompletionCertificate)
      return false;

    if (!this.selectedServiceRequest.hasContractInvoice)
      return false;

    return true;
  }

  showToast(summary: string, detail: string, severity: string) {
    this.messageService.add({ severity, summary, detail });
  }


  onCloseicket() {
    this.isUpdated = false;
    this.selectedServiceRequest.status = 'Closed';
    
    const now = new Date();
    const today = new Date(now.setHours(now.getHours() + 2));
    this.selectedServiceRequest.faultNotes.forEach(element => {
      if(element.id < 1){
        element.createdDate = today;
      }
    });
    this.selectedServiceRequest.modifiedDate = today;
    this.faultService.updateFault(this.selectedServiceRequest).pipe().subscribe(isUpdated => {
      if (isUpdated) {
        this.showToast('Fault', 'Your fault has been closed successfully.', 'success');
        this.isUpdated = true;
        this.onCancel();
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

  onSupplierCheckboxChange(e){
    this.showSupplier = e.checked;
    this.showProject = !this.showSupplier;
    if (this.showSupplier) {
      this.project = undefined;
      this.selectedServiceRequest.projectId = null;
      this.projectCheckbox = false;
    }
  }

  onProjectCheckboxChange(e){
    this.showProject  = e.checked;
    this.showSupplier = !this.showProject;
    if (this.showProject) {
      this.supplier = undefined;
      this.selectedServiceRequest.supplierId = null;
      this.supplierCheckbox = false;
    }
  }

  getFiles(fileReference: string) {
    this.faultService.getFiles(fileReference).pipe().subscribe(files => {
      for (let i = 0; i < files.length; i++) {
        let name = files[i].split('\\').pop();
        let url = 'https://amethysthemisphere.dedicated.co.za:81/Uploads/Faults/' + name;

        if (name.includes('Contract')) {
          this.selectedServiceRequest.contractInvoiceUrl = url;
         } else if (name.includes('Completion')) {
          this.selectedServiceRequest.completionCertificateUrl = url;
        } else {
          this.attachments.push({ url: url, name: 'Fault' + fileReference + '_' + i });
        }
      };
    });
  }

  onAddNote() {
    if (this.note !== '') {
      const faultnote: FaultNote = {
        id: 0,
        faultId: this.selectedServiceRequest.id,
        comment: this.note,
        createdDate: new Date(),
        createdById: this.currentUser.id
      };
      this.selectedServiceRequest.faultNotes.push(faultnote);
      this.note = '';
    }
  }

  onChooseContractInvoice(evt: any) {
    const uploadedFile = evt[0];
    this.contractInvoice = uploadedFile;
  }

  onChooseCompletionCertificate(evt: any) {
    const uploadedFile = evt[0];
    this.completionCertificate = uploadedFile;
  }

  uploadCompletionCertificate() {
    this.faultService.uploadFiles(this.completionCertificate, 'Completion certificate - ' +
      this.selectedServiceRequest.referenceNo + '_' + this.selectedServiceRequest.id).pipe().subscribe(isUploaded => {
        if (isUploaded) {
          this.showCompletionCertificateUrl = true;
        } else {
          this.selectedServiceRequest.hasCompletionCertificate = false;
        }
      },
        error => {
          this.messageService.add({
            severity: 'error', summary: 'Error Occurred',
            detail: 'An error occurred while processing your request. please try again!'
          });
          this.selectedServiceRequest.hasCompletionCertificate = false;
        });
  }

  uploadContractInvoice() {
    this.faultService.uploadFiles(this.contractInvoice, 'Contract invoice - ' +
      this.selectedServiceRequest.referenceNo + '_' + this.selectedServiceRequest.id).pipe().subscribe(isUploaded => {
        if (isUploaded) {
          this.showContractInvoiceUrl = true;
        } else {
          this.selectedServiceRequest.hasContractInvoice = false;
        }
      },
        error => {
          this.messageService.add({
            severity: 'error', summary: 'Error Occurred',
            detail: 'An error occurred while processing your request. please try again!'
          });
          this.selectedServiceRequest.hasContractInvoice = false;
        });
  }

  contractInvoiceUrl() {
    return this.selectedServiceRequest.contractInvoiceUrl;
  }

  completionCertificateUrl() {
    return this.selectedServiceRequest.completionCertificateUrl;
  }
}
