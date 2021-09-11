import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { OperationPlan } from 'src/app/models/operation-plan.model';
import { UAMP } from 'src/app/models/uamp.model';
import { element } from 'protractor';

@Component({
  selector: 'app-template-five-two',
  templateUrl: './template-five-two.component.html',
  styleUrls: ['./template-five-two.component.css'],
  providers: [MessageService]
})
export class TemplateFiveTwoComponent implements OnInit {
  operationPlans: Array<OperationPlan> = [];
  operationPlanForm: FormGroup;
  newOperationPlanForm: FormGroup;
  prioities: any[];
  initialNeedYears: any[];
  uamp: UAMP;
  
  constructor(private uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      this.operationPlans = [];
      this.uamp.templeteFivePointTwo.operationPlans.forEach( element => {
        if(element.priorityServiceRanking)
          element.initialNeedYearObj =  this.initialNeedYears.filter(p => p.name == element.initialNeedYear)[0];
          element.priorityServiceRankingObj =  this.prioities.filter(p => p.name == element.priorityServiceRanking)[0];
        this.operationPlans.push(element);
      });
    });
  }

  ngOnInit() {

    this.newOperationPlanForm = this.formBuilder.group({
      districtRegion: [''],
      town: [''],
      localMunicipality: [''],
      assetDescription: [''],
      repairDescription: [''],
      priorityServiceRanking: [''],
      initialNeedYear: [''],
      cashFlowYear1: [''],
      cashFlowYear2: [''],
      cashFlowYear3: [''],
      cashFlowYear4: [''],
      cashFlowYear5: [''],
      totalAmountRequired: ['']
    });
    this.prioities = [
      { name: 'Extremely Critical 1', code: 'C1', factor: 1 },
      { name: '2', code: 'C2', factor: 2 },
      { name: '3', code: 'C3', factor: 3 },
      { name: '4', code: 'C4', factor: 4 },
      { name: '5', code: 'C5', factor: 5 },
      { name: '6', code: 'C2', factor: 6 },
      { name: '7', code: 'C3', factor: 7 },
      { name: '8', code: 'C4', factor: 8 },
      { name: '9', code: 'C5', factor: 9 },
      { name: 'Defer 10', code: 'C5', factor: 10 },
    ];

    this.initialNeedYears = [
      { name: '2005', code: '5', factor: 1 },
      { name: '2006', code: '6', factor: 2 },
      { name: '2007', code: '7', factor: 3 },
      { name: '2008', code: '8', factor: 4 },
      { name: '2009', code: '9', factor: 5 },
      { name: '2010', code: '10', factor: 6 },
      { name: '2011', code: '11', factor: 7 },
      { name: '2012', code: '12', factor: 8 },
      { name: '2013', code: '13', factor: 9 },
      { name: '2014', code: '14', factor: 10 },
      { name: '2015', code: '15', factor: 11 },
      { name: '2016', code: '16', factor: 12 },
      { name: '2017', code: '17', factor: 13 },
      { name: '2018', code: '18', factor: 14 },
      { name: '2019', code: '19', factor: 15 },
      { name: '2020', code: '20', factor: 16 },
      { name: '2021', code: '21', factor: 17 },
    ];
    this.createForm();
  }

  private createForm(): void {
    this.operationPlanForm = this.formBuilder.group({
      tableRowArray: this.formBuilder.array([
        this.createTableRow()
      ])
    })
  }

  get tableRowArray(): FormArray {
    return this.operationPlanForm.get('tableRowArray') as FormArray;
  }

  get p() { return this.operationPlanForm.controls; }

  private createTableRow(): FormGroup {
    return this.formBuilder.group({
      repairDescription: new FormControl(null, {
        validators: [Validators.required]
      }),
      initialNeedYear: new FormControl(null, {
        validators: [Validators.required]
      }),
      prioityServiceReanking: new FormControl(null, {
        validators: [Validators.required]
      }),
      totalAmountRequired: new FormControl(null, {
        validators: [Validators.required]
      }),
      cashFlowYear1: new FormControl(null, {
        validators: [Validators.required]
      }),
      cashFlowYear2: new FormControl(null, {
        validators: [Validators.required]
      }),
      cashFlowYear3: new FormControl(null, {
        validators: [Validators.required]
      }),
      cashFlowYear4: new FormControl(null, {
        validators: [Validators.required]
      }),
      cashFlowYear5: new FormControl(null, {
        validators: [Validators.required]
      })    
    });
  }

  onPrioityServiceReankingChange(operationPlan: OperationPlan, e){
    operationPlan.priorityServiceRanking = e.value.name;   
  }
  onInitialNeedYearChange(operationPlan: OperationPlan, e){
    operationPlan.initialNeedYear = Number(e.value.name); 
  }

  calculateDbTotalAmountRequired(operationPlan: OperationPlan){
    let total = 0;
    let year1 = operationPlan.cashFlowYear1;
    let year2 = operationPlan.cashFlowYear2;
    let year3 = operationPlan.cashFlowYear3;
    let year4 = operationPlan.cashFlowYear4;
    let year5 = operationPlan.cashFlowYear5;

    if(year1)
      total = total + year1;
      if(year2)
      total = total + year2;
      if(year3)
      total = total + year3;
      if(year4)
      total = total + year4;
      if(year5)
      total = total + year5;

      return total;

  }

  calculateTotalAmountRequired(){
    const year1 = this.newOperationPlanForm.controls["cashFlowYear1"].value;
    const year2 = this.newOperationPlanForm.controls["cashFlowYear2"].value;
    const year3 = this.newOperationPlanForm.controls["cashFlowYear3"].value;
    const year4 = this.newOperationPlanForm.controls["cashFlowYear4"].value;
    const year5 = this.newOperationPlanForm.controls["cashFlowYear5"].value;
    let total = 0;

      if(year1)
        total = total + year1;
      if(year2)
      total = total + year2;
      if(year3)
      total = total + year3;
      if(year4)
      total = total + year4;
      if(year5)
      total = total + year5;

      this.newOperationPlanForm.controls["totalAmountRequired"].setValue(total);  
  }

}
