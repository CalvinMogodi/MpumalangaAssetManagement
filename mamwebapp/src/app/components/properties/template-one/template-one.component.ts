import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';

import { Programme } from '../../../models/programme.model';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css']
})
export class TemplateOneComponent implements OnInit {
  programmes: Programme[];

  constructor(public uampService: UAMPService) { 
    this.programmes = [];
    this.programmes.push(new Programme());
  }

  ngOnInit() {
  }

  addProgram() {
    this.programmes.push(new Programme());
  }

  saveProgrammes() {
    this.uampService.addProgrammes(this.programmes).pipe(first()).subscribe(result => {
              
    });
  }

}
