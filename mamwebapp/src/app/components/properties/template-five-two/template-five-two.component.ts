import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';
import { FacilityService } from 'src/app/services/facility/facility.service';

@Component({
  selector: 'app-template-five-two',
  templateUrl: './template-five-two.component.html',
  styleUrls: ['./template-five-two.component.css'],
  providers: [MessageService]
})
export class TemplateFiveTwoComponent implements OnInit {
  @Input() properties: Facility[];
  operationPlanForm: FormGroup;
  prioities: any[];
  uamp: any = {};
  
  constructor(private facilityService: FacilityService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.facilityService.uampTempleteChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      this.uamp.templeteFivePointTwo = this.properties;
    });
  }

  ngOnInit() {
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
      prioity: new FormControl(null, {
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
}
