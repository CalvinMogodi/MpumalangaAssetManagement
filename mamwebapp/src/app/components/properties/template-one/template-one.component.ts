import { Component, OnInit } from '@angular/core';

import { Programme } from '../../../models/programme.model';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css']
})
export class TemplateOneComponent implements OnInit {
  programmes: Programme[];

  constructor() { 
    this.programmes = [];
    this.programmes.push(new Programme());
  }

  ngOnInit() {
  }

  addProgram() {
    this.programmes.push(new Programme());
  }

}
