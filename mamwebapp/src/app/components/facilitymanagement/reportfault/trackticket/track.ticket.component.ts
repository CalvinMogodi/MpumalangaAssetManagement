import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RadioControlRegistry } from 'primeng/radiobutton';
import { AuthenticationService } from 'src/app/services/authentication.service';
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
  public reportFaultForm: FormGroup;
  public referenceNumber = '';
  public buildings = [
    { code: 'supplier', name: 'Vacant Land (Loshlelo Roads Camp) - Stinkhout Street, Bethal Rand, Bethal, Mpumalanga' },
    { code: 'companyName', name: 'Land for Cultural Hub - Cnr Brugman Street/Pienaar Street, Badplaas, Badplaas, Mpumalanga' },
    { code: 'companyNumber', name: 'Township Development - Brugman Street, Badplaas, Badplaas, Mpumalanga' },
    { code: 'contactName', name: 'Farm - Sarel Cilliers Street, Badplaas, Badplaas, Mpumalanga' },
    { code: 'contactNumber', name: 'Lynnville Township - Louws Creek Street 6, Aerorand, Middelburg, Mpumalanga' }
  ];

  constructor(private authenticationService: AuthenticationService, private formBuilder: FormBuilder, private sharedService: SharedService)
  {
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

  onSubmit() {
    this.submitted = true;
    if (this.reportFaultForm.valid) {
      this.isSuccessful = true;
      this.referenceNumber = this.getReferenceNumber(7);
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
