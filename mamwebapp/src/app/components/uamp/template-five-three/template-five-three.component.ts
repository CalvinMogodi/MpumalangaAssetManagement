import { Component, Input, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
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
  leaseTypes: any[];
  prioities: any[];
  uamp: UAMP;
  
  constructor(private confirmationService: ConfirmationService,private uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    

      this.operationPlans = [];
      this.uamp.templeteFivePointThree.operationPlans.forEach(element => {          
        element.leaseStartDate = element.leaseStartDate != null ? new Date(element.leaseStartDate) : undefined;
        element.leaseEndDate = element.leaseEndDate != null ? new Date(element.leaseEndDate): undefined;
        this.operationPlans.push(element);          
      })      
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

    this.leaseTypes = [
      { name: 'Land', code: 'L', factor: 1 },
      { name: 'Office', code: 'O', factor: 2 },
      { name: 'Residential', code: 'R', factor: 3 },
      { name: 'Packing', code: 'P', factor: 4 },
    ];
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

  onLeased(operationPlan: OperationPlan, e){
    if(e.checked){
      this.confirmationService.confirm({
        message: 'Are you sure that this property is leased?',
        accept: () => {
          operationPlan.leased = true;
        },
        reject:() =>{
          operationPlan.leased = false;
        }
    });
    }else{
      operationPlan.leased = false;
    }
  }
}
