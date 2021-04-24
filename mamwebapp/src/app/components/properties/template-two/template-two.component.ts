import { NumberSymbol } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Facility } from 'src/app/models/facility.model';

@Component({
  selector: 'app-template-two',
  templateUrl: './template-two.component.html',
  styleUrls: ['./template-two.component.css']
})
export class TemplateTwoComponent implements OnInit {
  @Input() facilities: Facility[];
  test: Number[];
  constructor() { 
    this.test = [1,2,3];
  }

  ngOnInit() {
  }

}
