import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { OperationPlan } from 'src/app/models/operation-plan.model';
import { UAMP } from 'src/app/models/uamp.model';

@Component({
  selector: 'app-template-five-three',
  templateUrl: './template-five-three.component.html',
  styleUrls: ['./template-five-three.component.css'],
  providers: [MessageService]
})
export class TemplateFiveThreeComponent implements OnInit {
  operationPlans: Array<OperationPlan> = [];
  operationPlanForm: FormGroup;
  prioities: any[];
  uamp: UAMP;
  
  constructor(private uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      this.operationPlans = this.uamp.templeteFivePointThree.operationPlans;
    });
  }

  ngOnInit() {
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
      leaseType: new FormControl(null, {
        validators: [Validators.required]
      }),
      noofParkingBays: new FormControl(null, {
        validators: [Validators.required]
      }),
      usableSpace: new FormControl(null, {
        validators: [Validators.required]
      }),
      constructionArea: new FormControl(null, {
        validators: [Validators.required]
      }),
      leaseStartDate: new FormControl(null, {
        validators: [Validators.required]
      }),
      leaseEndDate: new FormControl(null, {
        validators: [Validators.required]
      }),
      rentalPmPa: new FormControl(null, {
        validators: [Validators.required]
      }),
      comment: new FormControl(null, {
        validators: [Validators.required]
      })    
    });
  }
}
