import { NumberSymbol } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { element } from 'protractor';
import { Facility } from 'src/app/models/facility.model';
import { Property } from 'src/app/models/property.model';
import { UAMP } from 'src/app/models/uamp.model';
import { UampService } from 'src/app/services/uamp/uamp.service';

@Component({
  selector: 'app-template-two-two',
  templateUrl: './template-two-two.component.html',
  styleUrls: ['./template-two-two.component.css']
})
export class TemplateTwoTwoComponent implements OnInit {
  properties: Property[] = [];
  test: Number[];
  stateOwnedFacilities: Facility[];
  leasedFacilities: Facility[];
  stateOwnedFacilitiesExtentTotal = 0;
  leasedFacilitiesExtentTotal = 0;
  submitted: boolean = false;
  propertyForm: FormGroup;
  uamp: UAMP;
  conditionRatings: any[];
  functionalPerformanceIndexs: any[];
  operatingPerformanceIndexs: any[];
  suitabilityIndexs: any[];
  accessibilities: any[];
  requiredPerformanceStandards: any[];
  
  constructor(private uampService: UampService, private formBuilder: FormBuilder) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.properties = [];
        this.uamp = value;
        this.properties = [];
        this.uamp.templeteTwoPointTwo.properties.forEach(element => {
          
          element.leaseStartDate = element.leaseStartDate != null ? new Date(element.leaseStartDate) : undefined;
          element.leaseEndDate = element.leaseEndDate != null ? new Date(element.leaseEndDate): undefined;
          this.properties.push(element);          
        })
      }    
  })
  }

  ngOnInit() {
    this.propertyForm = this.formBuilder.group({
      fileReferenceNo: [''],
      serialNo: [''],
      district: [''],
      town: [''],
      localMunicipality: [''],
      localAuthority: [''],
      assetDescription: [''],
      oldStreetAddress: [''],
      currentStreetAddress: [''],
      propertyDescription: [''],
      assetType: [''],
      noofParkingBays: [''],
      noofParkingBaysAllocated: [''],
      usableAllocatedSpace: [''],
      lettableSpace: [''],
      extentofLand: [''],
      rentalPM: [''],
      rentalPA: [''],
      municipalUtilityServices: [''],
      MunicipalUtilityServiceTotal: [''],
      propertyRatesTaxes: [''],
      operationalCosts: [''],
      requiredPerformanceStandard: [''],
      accessibility: [''],
      conditionRating: [''],
      suitabilityIndex: [''],
      operatingPerformanceIndex: [''],
      functionalPerformanceIndex: [''],
      leaseStartDate: [''],
      leaseEndDate: [''],
      leaseTerm: [''],
      comment: ['']
    });
    this.conditionRatings = [
      { name: 'C1 (Excellent)', code: 'C1', factor: 1 },
      { name: 'C2 (Good)', code: 'C2', factor: 2 },
      { name: 'C3 (Fair)', code: 'C3', factor: 3 },
      { name: 'C4 (Poor)', code: 'C4', factor: 4 },
      { name: 'C5 (Very Poor)', code: 'C5', factor: 5 },
    ];

    this.functionalPerformanceIndexs = [
      { name: 'B1', code: 'B1', factor: 1 },
      { name: 'B2', code: 'B2', factor: 2 },
      { name: 'B3', code: 'B3', factor: 3 }
    ];

    this.operatingPerformanceIndexs = [
      { name: '1', code: '1', factor: 1 },
      { name: '2', code: '2', factor: 2 },
      { name: '3', code: '3', factor: 3 }
    ];
    this.suitabilityIndexs = [
      { name: 'A', code: 'A', factor: 1 },
      { name: 'B', code: 'B', factor: 2 },
      { name: 'C', code: 'C', factor: 3 }
    ];

    this.accessibilities = [
      { name: 'A1', code: 'A1', factor: 1 },
      { name: 'A2', code: 'A2', factor: 2 },
      { name: 'A3', code: 'A3', factor: 3 }
    ];

    this.requiredPerformanceStandards = [
      { name: 'P1', code: 'P1', factor: 1 },
      { name: 'P2', code: 'P2', factor: 2 },
      { name: 'P3', code: 'P3', factor: 3 }
    ];
    
  }

  get tableRowArray(): FormArray {
    return this.propertyForm.get('tableRowArray') as FormArray;
  }

  get p() { return this.propertyForm.controls; }

}
