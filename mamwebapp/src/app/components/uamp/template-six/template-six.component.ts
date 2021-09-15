import { Component, Input, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { SurrenderPlan } from 'src/app/models/surrender-plan.model';
import { UAMP } from 'src/app/models/uamp.model';
import { element } from 'protractor';
import { StrategicAssessment } from 'src/app/models/strategic-assessment.model';
import { Property } from 'src/app/models/property.model';
import { AcquisitionPlan } from 'src/app/models/acquisition-plan.model';

@Component({
  selector: 'app-template-six',
  templateUrl: './template-six.component.html',
  styleUrls: ['./template-six.component.css'],
  providers: [MessageService]
})
export class TemplateSixComponent implements OnInit {
  surrenderPlans: Array<SurrenderPlan> = [];  
  localMunicipalities: any[];
  assetTypes: any[];
  regions: any[];
  newSurrenderPlanForm: FormGroup;
  uamp: UAMP;

  constructor(private confirmationService: ConfirmationService, private uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      this.uamp.templeteSix.surrenderPlans.forEach(element => {
        if(element.proposedHandOverDate)
          element.proposedHandOverDate = new Date(element.proposedHandOverDate);
        this.surrenderPlans.push(element);
      });

      this.uamp.templeteThree.strategicAssessments.forEach(element =>{
        const matchItem = this.uamp.templeteSix.surrenderPlans.filter(s => s.strategicAssessmentId == element.id);
        if(element.percentageUtilised < 0 && matchItem.length > 0){
          this.surrenderPlans.push(this.createSPFromStrategicAssessment(element));
        }
      });

      this.uamp.templeteThree.strategicAssessments.forEach(element =>{
        const matchItem = this.surrenderPlans.filter(s => s.strategicAssessmentId == element.id);

        if(element.percentageUtilised < 0 && matchItem.length > 0){
          this.surrenderPlans.push(this.createSPFromStrategicAssessment(element));
        }
      });

      this.uamp.templeteTwoPointTwo.properties.forEach(element => {
        const matchItem = this.surrenderPlans.filter(s => s.propertyId == element.id);

        if(element.leaseEndDate < new Date() && matchItem.length == 0){
          this.surrenderPlans.push(this.createSPFromProperty(element));
        }
      });
    });
  }
  
  ngOnInit() {
    this.newSurrenderPlanForm = this.formBuilder.group({     
      district: [''],
      town: [''],
      localMunicipality: [''],
      currentStreetAddress: [''],
      assetType: [''],
      propertyDescription: [''],
      allocatedLettableSpace: [''],
      extentofLand: [''],
      surrenderRationale: [''],
      proposedHandOverDate: [''],
      contractualObligations: [''],
    });
    
    this.assetTypes = [
      { name: 'Erf', code: 'E', factor: 1 },
      { name: 'Farm', code: 'F', factor: 2 },
      { name: 'Agricultural Holding', code: 'A', factor: 3 },
      { name: 'Sectional Title', code: 'S', factor: 4 }
    ];

    this.regions = [
      { name: 'Ehlanzeni ', code: 'U', factor: 1 },
      { name: 'Gert Sibande', code: 'R', factor: 2 },
      { name: 'Nkangala', code: 'U', factor: 3 }
    ];
  }

  createSPFromProperty(property: Property): SurrenderPlan{
    const surrenderPlan: SurrenderPlan = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uamp.id,
      propertyId: property.id,
      strategicAssessmentId: undefined,
      district: property.district,
      town: undefined,
      localMunicipality: undefined,
      currentStreetAddress: undefined,
      assetType: undefined,
      propertyDescription: undefined,
      allocatedLettableSpace: undefined,
      extentofLand: undefined,
      surrenderRationale: undefined,
      proposedHandOverDate: undefined,
      contractualObligations: undefined,
      relinquish: undefined
    };
    return surrenderPlan;
  }

  createSPFromStrategicAssessment(strategicAssessment: StrategicAssessment): SurrenderPlan{
    const surrenderPlan: SurrenderPlan = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uamp.id,
      strategicAssessmentId: strategicAssessment.id,
      propertyId: undefined,
      district: strategicAssessment.district,
      town: undefined,
      localMunicipality: undefined,
      currentStreetAddress: undefined,
      assetType: undefined,
      propertyDescription: undefined,
      allocatedLettableSpace: undefined,
      extentofLand: undefined,
      surrenderRationale: undefined,
      proposedHandOverDate: undefined,
      contractualObligations: undefined,
      relinquish: undefined
    };
    return surrenderPlan;
  }

  relinquishSurrenderPlan(surrenderPlan:SurrenderPlan , $event){
    if ($event.checked){
      this.confirmationService.confirm({
        message: 'Are you sure that you want to relinquish this proterty?',
        accept: () => {
          surrenderPlan.relinquish = true;
        },
        reject:() =>{
          surrenderPlan.relinquish = false;
        }
    });
    }
  }

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

  addSurrenderPlan(){
    const surrenderPlan: SurrenderPlan = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uamp.id,
      district: this.newSurrenderPlanForm.controls["district"].value.name,
      town: this.newSurrenderPlanForm.controls["town"].value,
      localMunicipality: this.newSurrenderPlanForm.controls["localMunicipality"].value.name,
      currentStreetAddress: this.newSurrenderPlanForm.controls["currentStreetAddress"].value,
      assetType: this.newSurrenderPlanForm.controls["assetType"].value.name,
      propertyDescription: this.newSurrenderPlanForm.controls["propertyDescription"].value,
      allocatedLettableSpace: this.newSurrenderPlanForm.controls["allocatedLettableSpace"].value,
      extentofLand: this.newSurrenderPlanForm.controls["extentofLand"].value,
      surrenderRationale: this.newSurrenderPlanForm.controls["surrenderRationale"].value,
      proposedHandOverDate: this.newSurrenderPlanForm.controls["proposedHandOverDate"].value,
      contractualObligations: this.newSurrenderPlanForm.controls["contractualObligations"].value,
      relinquish: true
    }

    this.surrenderPlans.push(surrenderPlan);
    if(this.uamp.templeteSix != null)
    {
      this.uamp.templeteSix.surrenderPlans = this.surrenderPlans
    }else{
      this.uamp.templeteSix = {
        id: 0,
        surrenderPlans: this.surrenderPlans
      };
    }
    this.uampService.assignUamp(this.uamp);
    this.resetForm();
  }

  resetForm(){
    this.newSurrenderPlanForm.reset();
  }

  
}
