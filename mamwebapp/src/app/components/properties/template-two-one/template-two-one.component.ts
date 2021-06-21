import { Component, Input, OnInit } from '@angular/core';
import { Facility } from 'src/app/models/facility.model';
import { FacilityService } from '../../../services/facility/facility.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { FormControl, FormArray } from '@angular/forms';
import { DialogService } from 'primeng/dynamicdialog';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { AddMunicipalUtilityServicesComponent } from './add-municipal-utility-services/add-municipal-utility-services';

@Component({
  selector: 'app-template-two-one',
  templateUrl: './template-two-one.component.html',
  styleUrls: ['./template-two-one.component.css'],
  providers: [MessageService, DialogService, DynamicDialogRef]
})
export class TemplateTwoOneComponent implements OnInit {
  @Input() properties: Facility[];
  submitted: boolean = false;
  propertyForm: FormGroup;
  municipalUtilityServices: any[];
  operationalCosts: any[];
  conditionRatings: any[];
  uamp: any = {};

  constructor(private facilityService: FacilityService,
              public ref: DynamicDialogRef,  
              public dialogService: DialogService, 
              private formBuilder: FormBuilder) {
    this.facilityService.uampTempleteChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }   
      this.uamp.templeteTwoPointOne = this.properties;       
    });
  }

  ngOnInit() {
    this.municipalUtilityServices = [
      { name: 'Electricity', code: 'E', factor: 1 },
      { name: 'Water', code: 'W', factor: 2 },
      { name: 'Sewer & Refuse', code: 'SR', factor: 3 }];
    this.operationalCosts = [
      { name: 'Security', code: 'S', factor: 1 },
      { name: 'Telephone', code: 'T', factor: 2 },
      { name: 'Gardening', code: 'G', factor: 3 },
      { name: 'Cleaning', code: 'C', factor: 4 }];
    this.conditionRatings = [
      { name: 'C1 (Excellent)', code: 'C1', factor: 1 },
      { name: 'C2 (Good)', code: 'C2', factor: 2 },
      { name: 'C3 (Fair)', code: 'C3', factor: 3 },
      { name: 'C4 (Poor)', code: 'C4', factor: 4 },
      { name: 'C5 (Very Poor)', code: 'C5', factor: 5 },
    ];
    this.createForm();
  }

  private createForm(): void {
    this.propertyForm = this.formBuilder.group({
      tableRowArray: this.formBuilder.array([
        this.createTableRow()
      ])
    })
  }

  get tableRowArray(): FormArray {
    return this.propertyForm.get('tableRowArray') as FormArray;
  }

  get p() { return this.propertyForm.controls; }

  private createTableRow(): FormGroup {
    return this.formBuilder.group({
      parkingBaysNumber: new FormControl(null, {
        validators: [Validators.required]
      }),
      usableAllocatedSpace: new FormControl(null, {
        validators: [Validators.required]
      }),
      municipalUtilityService: new FormControl(null, {
        validators: [Validators.required]
      }),
      propertyRatesTaxes: new FormControl(null, {
        validators: [Validators.required]
      }),
      comment: new FormControl(null, {
        validators: [Validators.required]
      }),
      functionalPerformanceIndex: new FormControl(null, {
        validators: [Validators.required]
      }),
      operationalPerformanceIndex: new FormControl(null, {
        validators: [Validators.required]
      }),
      suitabilityIndex: new FormControl(null, {
        validators: [Validators.required]
      }),
      conditionRating: new FormControl(null, {
        validators: [Validators.required]
      }),
      accessibility: new FormControl(null, {
        validators: [Validators.required]
      }),
      requiredPerfomanceStandard: new FormControl(null, {
        validators: [Validators.required]
      }),
      operationalCost: new FormControl(null, {
        validators: [Validators.required]
      })
    });
  }

  show(property:any) {
    const ref = this.dialogService.open(AddMunicipalUtilityServicesComponent, {
        header: 'Municipal Utility Service',
        width: '40%',
        contentStyle: {"max-height": "500px", "overflow": "auto"},
        baseZIndex: 10000,
        data: {property: property}
    });

    ref.onClose.subscribe(result => {
      console.log(result);
       if (property) {
         property = property;
      }
    });
  }
}
