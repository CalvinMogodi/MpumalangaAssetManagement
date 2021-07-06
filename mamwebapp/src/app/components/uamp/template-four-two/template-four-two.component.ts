import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { MenuItem, MessageService } from 'primeng/api';
import { CurrentUtlisation } from '../../../models/current-utilisation.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { AcquisitionPlan } from 'src/app/models/acquisition-plan.model';
import { UAMP } from 'src/app/models/uamp.model';

@Component({
  selector: 'app-template-four-two',
  templateUrl: './template-four-two.component.html',
  styleUrls: ['./template-four-two.component.css'],
  providers: [MessageService]
})
export class TemplateFourTwoComponent implements OnInit {
  acquisitionPlanForm: FormGroup;
  submitted: boolean = false;
  regions: any[];
  initialNeedYears: any[];
  statuses: any[];
  acquisitionTypes: any[];
  acquisitionPlans: Array<AcquisitionPlan> = [];
  buttonItems: MenuItem[];
  uamp: UAMP;
  showComfirmationDelete:boolean = false;
  selectedAcquisitionPlan: AcquisitionPlan;
  isEdit: boolean = false;

  constructor(public uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) {
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
        this.acquisitionPlans = this.uamp.templeteFourPointTwo.acquisitionPlans;
      }  
    });
    this.acquisitionPlanForm = this.formBuilder.group({
      districtRegion: [''],
      town: [''],
      serviceDescription: [''],
      budgetType: [''],
      extent: [''],      
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

  update() {
    const districtRegion = this.regions.filter(r => r.name == this.selectedAcquisitionPlan.districtRegion)[0];
    const initialNeedYear = this.initialNeedYears.filter(r => r.name == this.selectedAcquisitionPlan.initialNeedYear)[0];
    const status = this.statuses.filter(r => r.name == this.selectedAcquisitionPlan.status)[0];
    const acquisitionType = this.acquisitionTypes.filter(r => r.name == this.selectedAcquisitionPlan.acquisitionType)[0];

    this.acquisitionPlanForm = this.formBuilder.group({
      districtRegion: [districtRegion],
      town: [this.selectedAcquisitionPlan.town],
      serviceDescription: [this.selectedAcquisitionPlan.serviceDescription],
      budgetType: [this.selectedAcquisitionPlan.budgetType],
      extent: [this.selectedAcquisitionPlan.extent],
      initialNeedYear: [initialNeedYear],
      acquisitionType:[acquisitionType],
      status:[status],
      totalAmountRequired: [this.selectedAcquisitionPlan.totalAmountRequired],
      cashFlowYear1: [this.selectedAcquisitionPlan.cashFlowYear1],
      cashFlowYear2: [this.selectedAcquisitionPlan.cashFlowYear2],
      cashFlowYear3: [this.selectedAcquisitionPlan.cashFlowYear3],
      cashFlowYear4: [this.selectedAcquisitionPlan.cashFlowYear4],
    });
    this.isEdit = true;
  }

  onUpdate() {
    const acquisitionPlan: AcquisitionPlan = {
      id: this.selectedAcquisitionPlan.id,
      userImmovableAssetManagementPlanId: this.uamp.id,
      templeteNumber: 4.1,
      districtRegion: this.acquisitionPlanForm.controls["districtRegion"].value.name,
      town: this.acquisitionPlanForm.controls["town"].value,
      serviceDescription: this.acquisitionPlanForm.controls["serviceDescription"].value,
      budgetType: this.acquisitionPlanForm.controls["budgetType"].value,
      extent: this.acquisitionPlanForm.controls["extent"].value,
      initialNeedYear: Number(this.acquisitionPlanForm.controls["initialNeedYear"].value.name),
      acquisitionType: this.acquisitionPlanForm.controls["acquisitionType"].value.name,
      status: this.acquisitionPlanForm.controls["status"].value.name,
      totalAmountRequired: this.acquisitionPlanForm.controls["totalAmountRequired"].value,
      cashFlowYear1: this.acquisitionPlanForm.controls["cashFlowYear1"].value,
      cashFlowYear2: this.acquisitionPlanForm.controls["cashFlowYear2"].value,
      cashFlowYear3: this.acquisitionPlanForm.controls["cashFlowYear3"].value,
    };

    var index = this.acquisitionPlans.indexOf(this.selectedAcquisitionPlan); 
    this.acquisitionPlans[index] = acquisitionPlan;
    this.isEdit = false;
    this.uampService.assignUamp(this.uamp);
    this.resetForm();
  }
  
  confirmDelete() {
    this.showComfirmationDelete = true;
  }

  selectAcquisitionPlan(acquisitionPlan: AcquisitionPlan){
    this.selectedAcquisitionPlan = acquisitionPlan;
  }

  deleteAcquisitionPlan(){
    if(this.selectedAcquisitionPlan.id == 0){
      var index = this.acquisitionPlans.indexOf(this.selectedAcquisitionPlan);    
      this.acquisitionPlans.splice(index, 1);
    }else{
      this.uampService.deleteAcquisitionPlan(this.selectedAcquisitionPlan).pipe(first()).subscribe(isDeleted => {
        if (isDeleted) {
          this.messageService.add({ severity: 'warn', summary: 'Delete Acquisition Plan', detail: 'Acquisition plan has been deleted successful.' });   
          var index = this.acquisitionPlans.indexOf(this.selectedAcquisitionPlan);    
          this.acquisitionPlans.splice(index, 1);
        } else {
          this.messageService.add({ severity: 'error', summary: 'Delete Acquisition Plan', detail: 'Acquisition plan is not deleted successful.' });
        }
      }, error => {
        this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
      });
    }    
  }

  addAcquisitionPlan() {
    const acquisitionPlan: AcquisitionPlan = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uamp.id,
      templeteNumber: 4.2,
      districtRegion: this.acquisitionPlanForm.controls["districtRegion"].value.name,
      town: this.acquisitionPlanForm.controls["town"].value,
      serviceDescription: this.acquisitionPlanForm.controls["serviceDescription"].value,
      budgetType: this.acquisitionPlanForm.controls["budgetType"].value,
      extent: this.acquisitionPlanForm.controls["extent"].value,
      acquisitionType: this.acquisitionPlanForm.controls["acquisitionType"].value.name,
      status: this.acquisitionPlanForm.controls["status"].value.name,
      totalAmountRequired: this.acquisitionPlanForm.controls["totalAmountRequired"].value,
      cashFlowYear1: this.acquisitionPlanForm.controls["cashFlowYear1"].value,
      cashFlowYear2: this.acquisitionPlanForm.controls["cashFlowYear2"].value,
      cashFlowYear3: this.acquisitionPlanForm.controls["cashFlowYear3"].value,
      cashFlowYear4: this.acquisitionPlanForm.controls["cashFlowYear4"].value,
    };
    this.acquisitionPlans.push(acquisitionPlan);
    if(this.uamp.templeteFourPointTwo != null)
    {
      this.uamp.templeteFourPointTwo.acquisitionPlans = this.acquisitionPlans
    }else{
      this.uamp.templeteFourPointTwo = {
        id: 0,
        acquisitionPlans: this.acquisitionPlans
      };
    }
    this.uampService.assignUamp(this.uamp);
    this.resetForm();
  }

  resetForm(){
    this.acquisitionPlanForm.reset();
  }

}
