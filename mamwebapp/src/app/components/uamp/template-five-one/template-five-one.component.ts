import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { MenuItem, MessageService } from 'primeng/api';
import { CurrentUtlisation } from '../../../models/current-utilisation.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { UAMP } from 'src/app/models/uamp.model';
import { OperationPlan } from 'src/app/models/operation-plan.model';

@Component({
  selector: 'app-template-five-one',
  templateUrl: './template-five-one.component.html',
  styleUrls: ['./template-five-one.component.css'],
  providers: [MessageService]
})
export class TemplateFiveOneComponent implements OnInit {
  scheduleCurrentUtilisation: CurrentUtlisation[] = [];
  operationPlanForm: FormGroup;
  submitted: boolean = false;
  regions: any[];
  initialNeedYears: any[];
  statuses: any[];
  operationTypes: any[];
  operationPlans: Array<OperationPlan> = [];
  buttonItems: MenuItem[];
  uamp: UAMP;

  constructor(private facilityService: FacilityService, public uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) {
    
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
        this.operationPlans = this.uamp.templeteFivePointOne.operationPlans;
      }          
    });

    this.operationPlanForm = this.formBuilder.group({
      districtRegion: [''],
      town: [''],
      serviceDescription: [''],
      budgetType: [''],
      initialNeedYear: [''],
      status:[''],
      totalAmountRequired: [''],
      cashFlowYear1: [''],
      cashFlowYear2: [''],
      cashFlowYear3: [''],
      cashFlowYear4: [''],
      cashFlowYear5: [''],
    });
   }

  ngOnInit() {
    this.buttonItems = [     
      {label: 'Update', icon: 'pi pi-pencil', command: () => 
          this.update()
      },
      {separator: true},
      {label: 'Delete', icon: 'pi pi-trash', command: () => 
          this.confirmDelete()
      }
    ]; 
    this.regions = [
      { name: 'Ehlanzeni ', code: 'U', factor: 1 },
      { name: 'Gert Sibande', code: 'R', factor: 2 },
      { name: 'Nkangala', code: 'U', factor: 3 }
    ];
    this.initialNeedYears = [
      { name: '2005', code: '5', factor: 1 },
      { name: '2006', code: '6', factor: 2 },
      { name: '2007', code: '7', factor: 3 },
      { name: '2008', code: '8', factor: 4 },
      { name: '2009', code: '9', factor: 5 },
      { name: '2010', code: '10', factor: 6 },
      { name: '2011', code: '11', factor: 7 },
      { name: '2012', code: '12', factor: 8 },
      { name: '2013', code: '13', factor: 9 },
      { name: '2014', code: '14', factor: 10 },
      { name: '2015', code: '15', factor: 11 },
      { name: '2016', code: '16', factor: 12 },
      { name: '2017', code: '17', factor: 13 },
      { name: '2018', code: '18', factor: 14 },
      { name: '2019', code: '19', factor: 15 },
      { name: '2020', code: '20', factor: 16 },
      { name: '2021', code: '21', factor: 17 },
    ];

    this.operationTypes = [
      { name: 'Purchase ', code: 'P', factor: 1 },
      { name: 'Construction', code: 'C', factor: 2 }
    ];

    this.statuses = [
      { name: 'Planning ', code: 'PL', factor: 1 },
      { name: 'Procurement', code: 'PR', factor: 2 },
      { name: 'Construction', code: 'CO', factor: 3 }
    ];
  }

  update(){

  }

  confirmDelete(){

  }

  addOperationPlan() {
    const operationPlan: OperationPlan = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uamp.id,
      templeteNumber: 5.1,
      districtRegion: this.operationPlanForm.controls["districtRegion"].value.name,
      town: this.operationPlanForm.controls["town"].value,
      serviceDescription: this.operationPlanForm.controls["serviceDescription"].value,
      budgetType: this.operationPlanForm.controls["budgetType"].value,
      initialNeedYear: Number(this.operationPlanForm.controls["initialNeedYear"].value.name),
      status: this.operationPlanForm.controls["status"].value.name,
      totalAmountRequired: this.operationPlanForm.controls["totalAmountRequired"].value,
      cashFlowYear1: this.operationPlanForm.controls["cashFlowYear1"].value,
      cashFlowYear2: this.operationPlanForm.controls["cashFlowYear2"].value,
      cashFlowYear3: this.operationPlanForm.controls["cashFlowYear3"].value,
      cashFlowYear4: this.operationPlanForm.controls["cashFlowYear4"].value,
      cashFlowYear5: this.operationPlanForm.controls["cashFlowYear5"].value,
      localMunicipality: null,
      assetDescription:null,
      repairDescription: null,
      prioityServiceReanking: null,
      streetDescription: null,
      propertyDescription: null,
      leaseType: null,
      noofParkingBays: null,
      usableSpace: null,
      constructionArea: null,
      extentofLand: null,
      leaseStartDate : null,
      leaseStartEnd: null,
      rentalPM: null,
      rentalPA: null
    };
    this.operationPlans.push(operationPlan);
    if(this.uamp.templeteFivePointOne != null)
    {
      this.uamp.templeteFivePointOne.operationPlans = this.operationPlans
    }else{
      this.uamp.templeteFivePointOne = {
        id: 0,
        operationPlans: this.operationPlans
      };
    }
    this.uampService.assignUamp(this.uamp);
    this.resetForm();
  }

  resetForm(){
    this.operationPlanForm.reset();
  }
}
