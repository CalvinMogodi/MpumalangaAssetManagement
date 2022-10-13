import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RadioControlRegistry } from 'primeng/radiobutton';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FaultService } from 'src/app/services/facility-management/fault.service';
import { ProjectService } from 'src/app/services/facility-management/project.service';
import { SharedService } from 'src/app/services/shared.service';
import { Fault } from '../../../../models/fault.model';

@Component({
  selector: 'app-add-fault',
  templateUrl: './add.fault.component.html',
  styleUrls: ['./add.fault.component.css'],
  providers: [MessageService, ConfirmationService, RadioControlRegistry]
})
export class AddFaultComponent implements OnInit {

  public fault: Fault;
  public attachments: any = [];
  public submitted = false;
  public isSuccessful = false;
  public reportFaultForm: FormGroup;
  public showTrackTicketDialog: boolean;
  public referenceNumber = '';
  public properties: any = [];

  getReferenceNumber(length): string {
    let result = '';
    const characters = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  constructor(private formBuilder: FormBuilder, private faultService: FaultService, private messageService: MessageService,
              private projectService: ProjectService) {
    this.fault = {
      id: 0,
      facilityId: 1,
      facilityName: null,
      propertyDescription: '',
      incidentDescription: '',
      contactName: '',
      contactNumber: '',
      createdDate: new Date(),
      modifiedDate: null,
      referenceNo: this.getReferenceNumber(7),
      hasCompletionCertificate: false,
      hasContractInvoice: false,
      supplierId: null,
      projectId: null,
      faultNotes: [],
      status: 'New',
      isDeleted: false,
    };
  }

  ngOnInit() {
    this.buildForm();

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

  }

  get f() { return this.reportFaultForm.controls; }

  buildForm() {
    this.reportFaultForm = this.formBuilder.group({
      buildingName: [''],
      propertyDescription: [''],
      descriptionoftheIssue: [''],
      nameSurname: [''],
      contactNumber: ['', Validators.minLength(10)]
    });
  }

  onRemoveAttachment(e) { }

  onSelectAttachment(files) { }

  onBuildingChange(e) {
    this.fault.facilityId = Number(e.value.code);
  }

  onSubmit() {
    this.submitted = true;
    this.isSuccessful = false;
    if (this.reportFaultForm.valid) {
     
      this.fault.incidentDescription = this.reportFaultForm.controls['descriptionoftheIssue'].value;
      this.fault.propertyDescription = this.reportFaultForm.controls['propertyDescription'].value;
      this.fault.contactNumber = this.reportFaultForm.controls['contactNumber'].value;
      this.fault.contactName = this.reportFaultForm.controls['nameSurname'].value;

      this.faultService.addFault(this.fault).pipe().subscribe(id => {
          if (id > 0) {
            this.fault.id = id;
            this.uploadFiles();
            this.isSuccessful = true;
          } else {
            //this.showToast('Report a Fault', 'Your fault has not been added successfully.', 'error');
          }
      },
      error => {
        //this.messageService.add({ severity: 'error', summary: 'Error Occurred',
        // detail: 'An error occurred while processing your request. please try again!' });
        this.isSuccessful = false;
      });

      //this.fault.hasCompletionCertificate  = this.
      //this.fault.hasContractInvoice = this.
    }
  }

  showToast(summary: string, detail: string, severity: string) {
    this.messageService.add({ severity, summary, detail });
  }

  onChooseFile(evt: any) {
    const uploadedFile = evt[0];
    this.attachments.push(uploadedFile);
  }

  uploadFiles(){
    this.faultService.uploadFiles(this.attachments, 'Fault' + this.fault.referenceNo + '_' + this.fault.id).pipe().subscribe(isUploaded => {
      if (isUploaded) {

      }
    });
  }
}
