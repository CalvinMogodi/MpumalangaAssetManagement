import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MessageService, PrimeIcons } from 'primeng/api';
import { first } from 'rxjs/operators';
import { ConditionAssessment } from 'src/app/models/condition-assessment.model';
import { Facility } from 'src/app/models/facility.model';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ConditionAssessmentService } from 'src/app/services/condition-assessment/condition-assessment.service';
import { AssetregisterComponent } from '../assetregister.component';

@Component({
  selector: 'app-condition-assessment',
  templateUrl: './condition-assessment.component.html',
  styleUrls: ['./condition-assessment.component.css'],
  providers: [MessageService]
})
export class ConditionAssessmentComponent implements OnInit {
  @Input() selectedFacility: Facility;
  @Input() assetComponent: AssetregisterComponent;
  @Output("closeConditionAssessment") closeConditionAssessment = new EventEmitter<any>();
  @Output() stopSort= new EventEmitter<any>();
  conditionAssessments: Array<ConditionAssessment> = [
    {
      id: undefined,
      facilityId: undefined,
      rates: undefined,
      createdDate: undefined,
      createdBy: undefined,
      modifiedDate: new Date(),
      modifiedBy: undefined,
      creator: {
        id: 0,
        username: undefined,
        password: undefined,
        name: undefined,
        surname: undefined,
        roleId: undefined,
        role: undefined,
        isActive: undefined,
        email: undefined,
        passwordIsChanged: undefined,
        createdDate: new Date(),
        createdUserId: undefined,
        modifiedDate: new Date(),
        modifiedUserId: undefined,
        token: undefined,
        department: undefined
      }
    }];
  public pCount: number = 0;
  public aCount: number = 0;
  public cCount: number = 0;
  public sCount: number = 0;
  public oCount: number = 0;
  public fCount: number = 0;
  events1: any[];
  loading: boolean;
  dataIsLoaded: boolean = false;
  isBusy: boolean;
  currentUser: User;

  constructor(private authenticationService: AuthenticationService, public conditionAssessmentService: ConditionAssessmentService, private messageService: MessageService) { }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
    });
    this.getConditionAssessment();
    this.events1 = [
      { status: 'Ordered', date: '15/10/2020 10:30', icon: PrimeIcons.SHOPPING_CART, color: '#9C27B0', image: 'game-controller.jpg' },
      { status: 'Processing', date: '15/10/2020 14:00', icon: PrimeIcons.COG, color: '#673AB7' },
      { status: 'Shipped', date: '15/10/2020 16:15', icon: PrimeIcons.ENVELOPE, color: '#FF9800' },
      { status: 'Delivered', date: '16/10/2020 10:00', icon: PrimeIcons.CHECK, color: '#607D8B' }
    ];
  }

  getConditionAssessment() {
    this.conditionAssessmentService.getConditionAssessments(this.selectedFacility.id).pipe(first()).subscribe(conditionAssessments => {
      this.conditionAssessments = conditionAssessments;
      this.conditionAssessments.forEach(element => {
        element.displayName = element.creator.name +' ' + element.creator.surname;
        element.date = new DatePipe('en-ZA').transform(element.createdDate, 'dd MMMM yyyy');
        element.color = '#'+Math.floor(Math.random() * 16777216).toString(16);
      });
      this.dataIsLoaded = true;
    });
  }

  saveConditionAssessment() {
    this.isBusy = true;
    var conditionAssessment: ConditionAssessment = {
      id: 0,
      facilityId: this.selectedFacility.id,
      createdDate: new Date(),
      createdBy: this.currentUser.id,
      creator: this.currentUser,
      displayName: this.currentUser.name +' ' + this.currentUser.surname,
      date: new DatePipe('en-ZA').transform(new Date(), 'dd MMMM yyyy'),
      color: '#'+Math.floor(Math.random() * 16777216).toString(16),
      modifiedDate: null,
      modifiedBy: null,
      rates: [{
        value: this.pCount,
        name: "Required Performance Standard",
        key: 1
      }, {
        value: this.aCount,
        name: "Accessibility Rating",
        key: 2
      }, {
        value: this.cCount,
        name: "Condition Rating",
        key: 3
      }, {
        value: this.sCount,
        name: "Suitability Index",
        key: 4
      }, {
        value: this.oCount,
        name: "Operating Performance Index",
        key: 5
      }, {
        value: this.fCount,
        name: "Functional Performance Standard",
        key: 6
      }]
    }
   
    this.conditionAssessmentService.saveConditionAssessment(conditionAssessment).pipe(first()).subscribe(id => {
      if (id >= 0) {
        conditionAssessment.id = id;
        this.conditionAssessments.push(conditionAssessment);
        this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Condition assessment records are saved successful.' });
        this.closeConditionAssessment.emit({isChild: true});
      } else {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while saving!' });
      }
      this.isBusy = false;
    });
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
