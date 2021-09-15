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
  regions: any[];
  localMunicipalities: any[];
  types: any[];
  
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
      rentalRate:[''],
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

    this.regions = [
      { name: 'Ehlanzeni ', code: 'U', factor: 1 },
      { name: 'Gert Sibande', code: 'R', factor: 2 },
      { name: 'Nkangala', code: 'U', factor: 3 }
    ];

    this.types = [
      { name: 'Erf', code: 'E', factor: 1 },
      { name: 'Farm', code: 'F', factor: 2 },
      { name: 'Agricultural Holding', code: 'A', factor: 3 },
      { name: 'Sectional Title', code: 'S', factor: 4 }
    ];
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

  setLocalMunicipalities(e) {
    if (e != undefined) {
      if (e.value != undefined) {
        if (e.value.factor == 1) {
          let _localMunicipalities = [
            { name: 'Bushbuckridge', code: 'B', factor: 1 },
            { name: 'Mbombela', code: 'M', factor: 2 },
            { name: 'Nkomazi', code: 'N', factor: 3 },
            { name: 'Thaba Chweu', code: 'TC', factor: 4},           
          ];
          this.localMunicipalities = _localMunicipalities;
        } else if (e.value.factor == 2) {
          let _localMunicipalities = [
            { name: 'Albert Luthuli', code: 'AL', factor: 1 },
            { name: 'Dipaleseng', code: 'D', factor: 2 },
            { name: 'Govan Mbeki', code: 'GM', factor: 3 },
            { name: 'Lekwa', code: 'L', factor: 7 },
            { name: 'Mkhondo', code: 'M', factor: 4 },                     
            { name: 'Msukaligwa', code: 'MS', factor: 5 },
            { name: 'Mkhondo', code: 'MK', factor: 6 }, 
            { name: 'Pixley Ka Seme', code: 'PKS', factor: 8 },  
          ];
          this.localMunicipalities = _localMunicipalities;
        } else if(e.value.factor == 3) {          
          let _localMunicipalities = [
            { name: 'Dr. J.S. Moroka', code: 'JSM', factor: 1 },
            { name: 'eMalahleni', code: 'M', factor: 2 },
            { name: 'eMakhazeni', code: 'MK', factor: 3},           
            { name: 'Msukaligwa', code: 'MS', factor: 4 },
            { name: 'Steve Tshwete', code: 'ST', factor: 5 },
            { name: 'Thembisile Hani', code: 'TH', factor: 6 },
            { name: 'Victor Khanye', code: 'VK', factor: 7 },            
          ];
          this.localMunicipalities = _localMunicipalities;
        }
        else {
          let _localMunicipalities = [
            { name: 'Bushbuckridge', code: 'B', factor: 1 },
            { name: 'Thaba Chweu', code: 'TC', factor: 2 },            
          ];          
          this.localMunicipalities = _localMunicipalities;
        }
      }
    }
  }

  makeId(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  addProperty(){
    const property: Property = {
      id: 0,
    userImmovableAssetManagementPlanId: this.uamp.id,
    fileReferenceNo: this.makeId(8),
    serialNo: this.makeId(8),
    district: this.propertyForm.controls["district"].value.name,
    town: this.propertyForm.controls["town"].value,
    localMunicipality: this.propertyForm.controls["localMunicipality"].value.name,
    assetDescription: this.propertyForm.controls["assetDescription"].value,
    oldStreetAddress: this.propertyForm.controls["oldStreetAddress"].value.name,
    currentStreetAddress: this.propertyForm.controls["currentStreetAddress"].value.name,
    propertyDescription: this.propertyForm.controls["propertyDescription"].value.name,
    assetType: this.propertyForm.controls["assetType"].value.name,
    noofParkingBaysAllocated: this.propertyForm.controls["noofParkingBaysAllocated"].value.name,
    lettableSpace: this.propertyForm.controls["lettableSpace"].value.name,
    extentofLand: this.propertyForm.controls["extentofLand"].value.name,
    rentalRate: this.propertyForm.controls["rentalRate"].value,
    requiredPerformanceStandard: this.propertyForm.controls["requiredPerformanceStandard"].value.name,
    accessibility: this.propertyForm.controls["accessibility"].value.name,
    conditionRating: this.propertyForm.controls["conditionRating"].value.name,
    suitabilityIndex: this.propertyForm.controls["suitabilityIndex"].value.name,
    operatingPerformanceIndex: this.propertyForm.controls["operatingPerformanceIndex"].value.name,
    functionalPerformanceIndex: this.propertyForm.controls["functionalPerformanceIndex"].value.name,
    leaseStartDate: this.propertyForm.controls["leaseStartDate"].value,
    leaseEndDate: this.propertyForm.controls["leaseEndDate"].value,
    comment: this.propertyForm.controls["comment"].value,   
    }

    this.properties.push(property);
  }
}
