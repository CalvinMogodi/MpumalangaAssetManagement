import { Component, OnInit} from '@angular/core';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from '../../../services/uamp/uamp.service';
import { FormBuilder, FormGroup, Validators, FormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { FormControl, FormArray } from '@angular/forms';
import { DialogService } from 'primeng/dynamicdialog';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { AddMunicipalUtilityServicesComponent } from './add-municipal-utility-services/add-municipal-utility-services';
import { TempleteTwoPointOne } from 'src/app/models/templetes/templete-two-point-one.model';
import { Property } from 'src/app/models/property.model';
import { UAMP } from 'src/app/models/uamp.model';
import { element } from 'protractor';

@Component({
  selector: 'app-template-two-one',
  templateUrl: './template-two-one.component.html',
  styleUrls: ['./template-two-one.component.css'],
  providers: [MessageService, DialogService, DynamicDialogRef]
})
export class TemplateTwoOneComponent implements OnInit {
  properties: Array<Property> = [];
  submitted: boolean = false;
  propertyForm: FormGroup;
  municipalUtilityServices: any[];
  operationalCosts: any[];
  conditionRatings: any[];
  functionalPerformanceIndexs: any[];
  operatingPerformanceIndexs: any[];
  suitabilityIndexs: any[];
  accessibilities: any[];
  requiredPerformanceStandards: any[];
  uamp: UAMP;

  constructor(private uampService: UampService,
              public ref: DynamicDialogRef,  
              public dialogService: DialogService, 
              private formBuilder: FormBuilder) {
    
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.properties = [];
        this.uamp = value;
        
        this.uamp.templeteTwoPointOne.properties.forEach( element => {
          if(element.accessibility)
            element.accessibilityObj = this.accessibilities.filter(a => a.name == element.accessibility)[0];

          if(element.conditionRating)
            element.conditionRatingObj = this.accessibilities.filter(a => a.name == element.conditionRating)[0];

          if(element.suitabilityIndex)
            element.suitabilityIndexObj = this.suitabilityIndexs.filter(a => a.name == element.suitabilityIndex)[0];
          
          if(element.operatingPerformanceIndex)
            element.operatingPerformanceIndexObj = this.operatingPerformanceIndexs.filter(a => a.name == element.operatingPerformanceIndex)[0];
          
          if(element.functionalPerformanceIndex)
            element.functionalPerformanceIndexObj = this.functionalPerformanceIndexs.filter(a => a.name == element.functionalPerformanceIndex)[0];

          if(element.requiredPerformanceStandard)
            element.requiredPerformanceStandardObj = this.requiredPerformanceStandards.filter(a => a.name == element.requiredPerformanceStandard)[0];

          this.properties.push(element);
        }
        )        
      } 
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
      { name: 'Cleaning', code: 'C', factor: 4 }
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
      noofParkingBays: new FormControl(null, {
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
      requiredPerformanceStandard: new FormControl(null, {
        validators: [Validators.required]
      }),
      operationalCosts: new FormControl(null, {
        validators: [Validators.required]
      })
    });
  }

  conditionRatingCahnged(property: Property, e){
    property.conditionRating = e.value.factor;
  }

  onRequiredPerformanceStandardChange(property: Property, e){
    property.requiredPerformanceStandard = e.value.name;
  }

  onAccessibilityChange(property: Property, e){
    property.accessibility = e.value.name;
  }

  onSuitabilityIndexChange(property: Property, e){
    property.suitabilityIndex = e.value.name;
  }

  onOperatingPerformanceIndexChange(property: Property, e){
    property.operatingPerformanceIndex = e.value.name;
  }

  onFunctionalPerformanceChange(property: Property, e){
    property.functionalPerformanceIndex = e.value.name;
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
