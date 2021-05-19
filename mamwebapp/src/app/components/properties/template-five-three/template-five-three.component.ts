import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';

@Component({
  selector: 'app-template-five-three',
  templateUrl: './template-five-three.component.html',
  styleUrls: ['./template-five-three.component.css'],
  providers: [MessageService]
})
export class TemplateFiveThreeComponent implements OnInit {
  @Input() properties: Facility[];
  operationPlanForm: FormGroup;
  prioities: any[];
  
  constructor(private formBuilder: FormBuilder, private messageService: MessageService) { 
   
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
      parkingBaysNo: new FormControl(null, {
        validators: [Validators.required]
      }),
      usableSpace: new FormControl(null, {
        validators: [Validators.required]
      }),
      constructionArea: new FormControl(null, {
        validators: [Validators.required]
      }),
      extent: new FormControl(null, {
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
