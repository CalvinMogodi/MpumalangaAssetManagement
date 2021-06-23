import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from 'src/app/services/uamp/uamp.service';

@Component({
  selector: 'app-template-six',
  templateUrl: './template-six.component.html',
  styleUrls: ['./template-six.component.css'],
  providers: [MessageService]
})
export class TemplateSixComponent implements OnInit {
  @Input() properties: Facility[];
  operationPlanForm: FormGroup;
  uamp: any = {};

  constructor(private uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      this.uamp.templeteSix = this.properties;
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
      currentStreetAddress: new FormControl(null, {
        validators: [Validators.required]
      }),
      allocatedSpace: new FormControl(null, {
        validators: [Validators.required]
      }),
      surrenderRationale: new FormControl(null, {
        validators: [Validators.required]
      }),
      proposedHandOverDate: new FormControl(null, {
        validators: [Validators.required]
      }),
      contractualObligations: new FormControl(null, {
        validators: [Validators.required]
      })   
    });
  }
}
