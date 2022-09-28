import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RadioControlRegistry } from 'primeng/radiobutton';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FaultService } from 'src/app/services/facility-management/fault.service';
import { SharedService } from 'src/app/services/shared.service';
import { Fault } from '../../../../models/fault';

@Component({
  selector: 'app-add-fault',
  templateUrl: './add.fault.component.html',
  styleUrls: ['./add.fault.component.css'],
  providers: [MessageService, ConfirmationService, RadioControlRegistry]
})
export class AddFaultComponent implements OnInit {

  public fault: Fault;
  public attachments: [];
  public submitted = false;
  public isSuccessful = false;
  public reportFaultForm: FormGroup;
  public referenceNumber = '';
  public buildings = [
    { code: '1', name: 'Vacant Land (Loshlelo Roads Camp) - Stinkhout Street, Bethal Rand, Bethal, Mpumalanga' },
    { code: '2', name: 'Land for Cultural Hub - Cnr Brugman Street/Pienaar Street, Badplaas, Badplaas, Mpumalanga' },
    { code: '3', name: 'Township Development - Brugman Street, Badplaas, Badplaas, Mpumalanga' },
    { code: '4', name: 'Farm - Sarel Cilliers Street, Badplaas, Badplaas, Mpumalanga' },
    { code: '5', name: 'Lynnville Township - Louws Creek Street 6, Aerorand, Middelburg, Mpumalanga' }
  ];

  getReferenceNumber(length): string {
    let result = '';
    const characters = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  constructor(private formBuilder: FormBuilder, private faultService: FaultService, private messageService: MessageService) {
    this.fault = {
      id: 0,
      facilityId: 1,
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
      notes: undefined,
      status: 'New',
      isDeleted: false,
    };
  }

  ngOnInit() {
    this.buildForm();
  }

  get f() { return this.reportFaultForm.controls; }

  buildForm() {
    this.reportFaultForm = this.formBuilder.group({
      buildingName: [''],
      propertyDescription: [''],
      descriptionoftheIssue: [''],
      nameSurname: [''],
      contactNumber: ['']
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
            this.showToast('Report a Fault', 'Your fault has been added successfully.', 'success');
            this.isSuccessful = true;
          } else {
            this.showToast('Report a Fault', 'Your fault has not been added successfully.', 'error');
          }
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error Occurred',
         detail: 'An error occurred while processing your request. please try again!' });
        this.isSuccessful = false;
      });

      //this.fault.hasCompletionCertificate  = this.
      //this.fault.hasContractInvoice = this.
    }
  }

  showToast(summary: string, detail: string, severity: string) {
    this.messageService.add({ severity, summary, detail });
  }
}
