import { Component, Input, OnInit } from '@angular/core';
import { PrimeIcons } from 'primeng/api';

@Component({
  selector: 'app-condition-assessment',
  templateUrl: './condition-assessment.component.html',
  styleUrls: ['./condition-assessment.component.css']
})
export class ConditionAssessmentComponent implements OnInit {
  @Input() selectedFacility;
  conditionsAssessments: any[];
  public pCount: number = 0;
  public aCount: number = 0;
  public cCount: number = 0;
  public sCount: number = 0;
  public oCount: number = 0;
  public fCount: number = 0;
  events1: any[];

  constructor() { }

  ngOnInit() {
    this.getConditionAssessment();
    this.events1 = [
      {status: 'Ordered', date: '15/10/2020 10:30', icon: PrimeIcons.SHOPPING_CART, color: '#9C27B0', image: 'game-controller.jpg'},
      {status: 'Processing', date: '15/10/2020 14:00', icon: PrimeIcons.COG, color: '#673AB7'},
      {status: 'Shipped', date: '15/10/2020 16:15', icon: PrimeIcons.ENVELOPE, color: '#FF9800'},
      {status: 'Delivered', date: '16/10/2020 10:00', icon: PrimeIcons.CHECK, color: '#607D8B'}
  ];
  }

  getConditionAssessment() {
    this.conditionsAssessments = [
      {
        status: 'John Doe', color: '#9C27B0', date: '15/10/2020 10:30', ratings: [{ name: 'Required performance standard', rate: 2 }, { name: 'Accessibility Rating', rate: 2 }
          , { name: 'Condition rating', rate: 1 }, { name: 'Suitability index', rate: 4 }, { name: 'Operating performance index', rate: 2 }, { name: 'Functional performance index', rate: 2 }]
      },
      {
        status: 'John Doe', color: '#673AB7', date: '25/11/2020 10:30', ratings: [{ name: 'Required performance standard', rate: 2 }, { name: 'Accessibility Rating', rate: 2 }
          , { name: 'Condition rating', rate: 5 }, { name: 'Suitability index', rate: 2 }, { name: 'Operating performance index', rate: 3 }, { name: 'Functional performance index', rate: 1}]
      },{
        status: 'John Doe', color: '#673AB7', date: '05/12/2020 10:30', ratings: [{ name: 'Required performance standard', rate: 2 }, { name: 'Accessibility Rating', rate: 2 }
          , { name: 'Condition rating', rate: 2 }, { name: 'Suitability index', rate: 2 }, { name: 'Operating performance index', rate: 2 }, { name: 'Functional performance index', rate: 2 }]
      },
    ]; this
  }

  setRate() {
    this.sCount = 0;


    if (((this.pCount == 2 || this.pCount == 3 || this.pCount == 4 || this.pCount == 5) && this.aCount == 1) || (this.pCount == 1) || (this.aCount == 2 && (this.pCount == 5 || this.pCount == 4))) {
      this.sCount = 3;
    }

    if (((this.pCount == 3 || this.pCount == 2) && this.aCount == 2) || (this.aCount == 3 && (this.pCount == 5 || this.pCount == 4 || this.pCount == 3))) {
      this.sCount = 2;
    }

    if ((this.aCount == 3 && (this.pCount == 2)) || ((this.pCount == 2 || this.pCount == 3 || this.pCount == 4 || this.pCount == 5) && this.aCount == 4) || (this.aCount == 5 && (this.pCount == 5 || this.pCount == 4 || this.pCount == 3 || this.pCount == 2))) {
      this.sCount = 1;
    }

    if ((this.cCount == 1 && (this.pCount == 2 || this.pCount == 3 || this.pCount == 4 || this.pCount == 5) || (this.cCount == 2 && (this.pCount == 3 || this.pCount == 4 || this.pCount == 5)) || (this.cCount == 3 && (this.pCount == 5)))) {
      this.oCount = 1
    }

    if ((this.cCount == 1 && this.pCount == 1) || (this.cCount == 2 && (this.pCount == 2 || this.pCount == 1)) || (this.cCount == 3 && (this.pCount == 3 || this.pCount == 2)) || (this.cCount == 4 && this.pCount == 4)) {
      this.oCount = 2
    }

    if ((this.cCount == 3 && (this.pCount == 1 || this.pCount == 2)) || (this.cCount == 4 && (this.pCount == 1 || this.pCount == 2 || this.pCount == 3 || this.pCount == 4)) || (this.cCount == 5 && (this.pCount == 1 || this.pCount == 2 || this.pCount == 3 || this.pCount == 4 || this.pCount == 5))) {
      this.oCount = 3
    }

    if (this.sCount == 1 && this.oCount == 1) {
      this.fCount = 1;
    }

    if ((this.sCount == 1 && this.oCount == 2)) {
      this.fCount = 4;
    }

    if ((this.sCount == 1 && this.oCount == 3)) {
      this.fCount = 7;
    }

    if (this.sCount == 2 && this.oCount == 1) {
      this.fCount = 2;
    }

    if ((this.sCount == 2 && this.oCount == 2)) {
      this.fCount = 5;
    }

    if ((this.sCount == 2 && this.oCount == 3)) {
      this.fCount = 8;
    }

    if (this.sCount == 3 && this.oCount == 1) {
      this.fCount = 3;
    }

    if ((this.sCount == 3 && this.oCount == 2)) {
      this.fCount = 6;
    }

    if ((this.sCount == 3 && this.oCount == 3)) {
      this.fCount = 9;
    }
  }
}
