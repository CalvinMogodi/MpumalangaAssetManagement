import { NumberSymbol } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from 'src/app/services/uamp/uamp.service';

@Component({
  selector: 'app-template-two-two',
  templateUrl: './template-two-two.component.html',
  styleUrls: ['./template-two-two.component.css']
})
export class TemplateTwoTwoComponent implements OnInit {
  @Input() properties: Facility[];
  test: Number[];
  stateOwnedFacilities: Facility[];
  leasedFacilities: Facility[];
  stateOwnedFacilitiesExtentTotal = 0;
  leasedFacilitiesExtentTotal = 0;
  submitted: boolean = false;
  propertyForm: FormGroup;
  uamp: any = {};
  
  constructor(private uampService: UampService, private formBuilder: FormBuilder) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      this.uamp.templeteTwoPointTwo = this.properties;
  })
  }

  ngOnInit() {
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
      lettableSpace: new FormControl(null, {
        validators: [Validators.required]
      }),
      rentalAmountPM: new FormControl(null, {
        validators: [Validators.required]
      }),
      rentalAmountPA: new FormControl(null, {
        validators: [Validators.required]
      }),
      operationalCost: new FormControl(null, {
        validators: [Validators.required]
      }),
      leaseStartDate: new FormControl(null, {
        validators: [Validators.required]
      }),
      leaseEndDate: new FormControl(null, {
        validators: [Validators.required]
      }),
      leaseTerm: new FormControl(null, {
        validators: [Validators.required]
      })     
    });
  }
}
