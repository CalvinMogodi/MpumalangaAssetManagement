import { Component, OnInit } from '@angular/core';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { MenuItem, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FacilityService } from 'src/app/services/facility/facility.service';

@Component({
  selector: 'app-template-four-one',
  templateUrl: './template-four-one.component.html',
  styleUrls: ['./template-four-one.component.css'],
  providers: [MessageService]
})
export class TemplateFourOneComponent implements OnInit { 
  scheduleCurrentUtilisation: any[] = [];
  acquisitionPlanForm: FormGroup;
  submitted: boolean = false;
  regions: any[];
  initialNeedYears: any[];
  statuses: any[];
  acquisitionTypes: any[];
  acquisitionPlans: any[] = [];
  buttonItems: MenuItem[];
  umap: any = {};

  constructor(private facilityService: FacilityService, public uampService: UAMPService, private formBuilder: FormBuilder, private messageService: MessageService) {
    this.facilityService.umapTempleteChange.subscribe((value) => {
      if(value)
      {
        this.umap = value;
      }    
      this.umap.templeteFourPointOne = this.acquisitionPlans;
    });
    this.acquisitionPlanForm = this.formBuilder.group({
      region: [''],
      town: [''],
      serviceDescription: [''],
      budgetType: [''],
      extent: [''],
      initialNeedYear: [''],
      acquisitionType:[''],
      status:[''],
      totalAmountRequired: [''],
      cashFlowYear1: [''],
      cashFlowYear2: [''],
      cashFlowYear3: [''],
      cashFlowYear4: [''],
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

    this.acquisitionTypes = [
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

  addAcquisitionPlan() {
    const acquisitionPlan = {
      id: this.acquisitionPlans.length + 1,
      region: this.acquisitionPlanForm.controls["region"].value.name,
      town: this.acquisitionPlanForm.controls["town"].value,
      serviceDescription: this.acquisitionPlanForm.controls["serviceDescription"].value,
      budgetType: this.acquisitionPlanForm.controls["budgetType"].value,
      extent: this.acquisitionPlanForm.controls["extent"].value,
      initialNeedYear: this.acquisitionPlanForm.controls["initialNeedYear"].value.name,
      acquisitionType: this.acquisitionPlanForm.controls["acquisitionType"].value.name,
      status: this.acquisitionPlanForm.controls["status"].value.name,
      totalAmountRequired: this.acquisitionPlanForm.controls["totalAmountRequired"].value,
      cashFlowYear1: this.acquisitionPlanForm.controls["cashFlowYear1"].value,
      cashFlowYear2: this.acquisitionPlanForm.controls["cashFlowYear2"].value,
      cashFlowYear3: this.acquisitionPlanForm.controls["cashFlowYear3"].value,
      cashFlowYear4: this.acquisitionPlanForm.controls["cashFlowYear4"].value,
    };
    this.acquisitionPlans.push(acquisitionPlan);
    this.resetForm();
  }

  resetForm() {
    this.acquisitionPlanForm.reset();
  }
}
