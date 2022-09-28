import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RadioControlRegistry } from 'primeng/radiobutton';
import { FaultService } from 'src/app/services/facility-management/fault.service';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-track-ticket',
  templateUrl: './track.ticket.component.html',
  styleUrls: ['./track.ticket.component.css'],
  providers: [MessageService, ConfirmationService, RadioControlRegistry]
})
export class TrackTicketComponent implements OnInit {

  public attachments: [];
  public submitted = false;
  public isSuccessful = false;
  public trackFaultForm: FormGroup;
  public referenceNumber = '';
  public status = '';
  public buildings = [
    { code: 'supplier', name: 'Vacant Land (Loshlelo Roads Camp) - Stinkhout Street, Bethal Rand, Bethal, Mpumalanga' },
    { code: 'companyName', name: 'Land for Cultural Hub - Cnr Brugman Street/Pienaar Street, Badplaas, Badplaas, Mpumalanga' },
    { code: 'companyNumber', name: 'Township Development - Brugman Street, Badplaas, Badplaas, Mpumalanga' },
    { code: 'contactName', name: 'Farm - Sarel Cilliers Street, Badplaas, Badplaas, Mpumalanga' },
    { code: 'contactNumber', name: 'Lynnville Township - Louws Creek Street 6, Aerorand, Middelburg, Mpumalanga' }
  ];

  constructor(private faultService: FaultService, private formBuilder: FormBuilder, private messageService: MessageService)
  {
  
  }

  ngOnInit() {
    this.buildForm();
  }

  get f() { return this.trackFaultForm.controls; }

  buildForm() {
    this.trackFaultForm = this.formBuilder.group({
      referenceNumber: [''],
    });
  }

  onRemoveAttachment(e) { }

  onSelectAttachment(files) { }

  onSearch() {
    this.isSuccessful = false;
    if (this.trackFaultForm.valid) {
      const referenceNo = this.trackFaultForm.controls['referenceNumber'].value;
      this.faultService.getFaultReferenceNo(referenceNo).subscribe(fault => {
        if (fault) {
          this.status = fault.status;
          this.isSuccessful = true;
        }
      },
      (error) => {
        this.messageService.add({ severity: 'error', summary: 'Error Occoured', detail: 'Unable to get fault' });
        this.isSuccessful = false;
      });
    }
  }

  getReferenceNumber(length): string {
    let result = '';
    const characters = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }
}
