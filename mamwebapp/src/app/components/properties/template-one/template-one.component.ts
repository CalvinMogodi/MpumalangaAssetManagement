import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';

import { Programme } from '../../../models/programme.model';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css'],
  providers: [MessageService]
})
export class TemplateOneComponent implements OnInit {
  programmes: Programme[];

  constructor(public uampService: UAMPService, private messageService: MessageService) { 
    this.programmes = [];
    //this.programmes.push(new Programme());
  }

  ngOnInit() {
    this.getProgrammes();
  }

  addProgram() {
    this.programmes.push(new Programme());
  }

  saveProgrammes() {
    this.uampService.addProgrammes(this.programmes).pipe(first()).subscribe(result => {
      this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Programmes are saved successful.' });
    });
  }

  getProgrammes() {
    this.uampService.getProgrammes().pipe(first()).subscribe(programmes => {
      this.programmes = programmes;
    });
  }

}
