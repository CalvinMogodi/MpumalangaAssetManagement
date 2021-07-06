import { Component, Input, OnInit } from '@angular/core';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { Facility } from 'src/app/models/facility.model';
import { MenuItem, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { UAMP } from 'src/app/models/uamp.model';
import { StrategicAssessment } from 'src/app/models/strategic-assessment.model';
import { StrategicNeedsAssessment } from 'src/app/models/strategic-needs-assessment';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-template-three',
  templateUrl: './template-three.component.html',
  styleUrls: ['./template-three.component.css'],
  providers: [MessageService]
})
export class TemplateThreeComponent implements OnInit {
  strategicAssessments: Array<StrategicAssessment> = [];
  @Input() properties: Facility[];
  assessmentStrategicForm: FormGroup;
  buttonItems: MenuItem[];
  uamp: UAMP;
  showComfirmationDelete: boolean = false;
  isEdit: boolean = false;
  selectedStrategicAssessment:StrategicAssessment;

  constructor(public uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) {
    
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }    
      
      this.strategicAssessments = this.uamp.templeteThree.strategicAssessments;
  });
  }

  ngOnInit() {
    this.assessmentStrategicForm = this.formBuilder.group({
      postDescriptionTitle: [''],
      allocatedSpace: [''],
      fbpLevel: [''],
      fbpQuantity: [''],
      fbpNorm: [''],
      aoLevel: [''],
      aoQuantity: [''],
      aoNorm: [''],
    });
    this.buttonItems = [
      {
        label: 'Update', icon: 'pi pi-pencil', command: () =>
          this.update()
      },
      { separator: true },
      {
        label: 'Delete', icon: 'pi pi-trash', command: () =>
          this.confirmDelete()
      }
    ];
  }

  onUpdate() {
    const allocatedSpace = this.assessmentStrategicForm.controls["allocatedSpace"].value;
    const aoRequirement = (this.assessmentStrategicForm.controls["aoNorm"].value * this.assessmentStrategicForm.controls["aoQuantity"].value);
    const strategicAssessment: StrategicAssessment = {
      id: this.selectedStrategicAssessment.id,
      postDescriptionTitle: this.assessmentStrategicForm.controls["postDescriptionTitle"].value,
      allocatedSpace: allocatedSpace,
      userImmovableAssetManagementPlanId: this.uamp.id,
      surplusShortageAccommodation: (allocatedSpace - aoRequirement),
      percentageUtilised: (allocatedSpace / aoRequirement),
      fbpLevel: this.assessmentStrategicForm.controls["fbpLevel"].value,
      fbpQuantity: this.assessmentStrategicForm.controls["fbpQuantity"].value,
      fbpNorm: this.assessmentStrategicForm.controls["fbpNorm"].value,
      fbpRequirement: (this.assessmentStrategicForm.controls["fbpLevel"].value + this.assessmentStrategicForm.controls["fbpQuantity"].value),
      aoLevel: this.assessmentStrategicForm.controls["aoLevel"].value,
      aoQuantity: this.assessmentStrategicForm.controls["aoQuantity"].value,
      aoNorm: this.assessmentStrategicForm.controls["aoNorm"].value,
      aoRequirement: aoRequirement,
    };

    var index = this.strategicAssessments.indexOf(this.selectedStrategicAssessment); 
    this.strategicAssessments[index] = strategicAssessment;
    this.isEdit = false;
    this.uampService.assignUamp(this.uamp);
    this.resetForm();
  }

  update() {
    this.assessmentStrategicForm = this.formBuilder.group({
      postDescriptionTitle: [this.selectedStrategicAssessment.postDescriptionTitle],
      allocatedSpace: [this.selectedStrategicAssessment.allocatedSpace],
      fbpLevel: [this.selectedStrategicAssessment.fbpLevel],
      fbpQuantity: [this.selectedStrategicAssessment.fbpQuantity],
      fbpNorm: [this.selectedStrategicAssessment.fbpNorm],
      aoLevel: [this.selectedStrategicAssessment.aoLevel],
      aoQuantity: [this.selectedStrategicAssessment.aoQuantity],
      aoNorm: [this.selectedStrategicAssessment.aoNorm],
    });
    this.isEdit = true;
  }

  confirmDelete() {
    this.showComfirmationDelete = true;
  }

  selectStrategicNeedsAssessment(strategicNeedsAssessment: StrategicAssessment){
    this.selectedStrategicAssessment = strategicNeedsAssessment;
  }

  deleteStrategicAssessment(){
    if(this.selectedStrategicAssessment.id == 0){
      var index = this.strategicAssessments.indexOf(this.selectedStrategicAssessment);    
      this.strategicAssessments.splice(index, 1);
    }else{
      this.uampService.deleteStrategicAssessment(this.selectedStrategicAssessment).pipe(first()).subscribe(isDeleted => {
        if (isDeleted) {
          this.messageService.add({ severity: 'warn', summary: 'Delete Strategic Assessment', detail: 'Strategic Assessment has been deleted successful.' });   
          var index = this.strategicAssessments.indexOf(this.selectedStrategicAssessment);    
          this.strategicAssessments.splice(index, 1);
        } else {
          this.messageService.add({ severity: 'error', summary: 'Delete Strategic Assessment', detail: 'Strategic Assessment is not deleted successful.' });
        }
      }, error => {
        this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
      });
    }    
  }

  addStrategicNeedsAssessment() {
    const allocatedSpace = this.assessmentStrategicForm.controls["allocatedSpace"].value;
    const aoRequirement = (this.assessmentStrategicForm.controls["aoNorm"].value * this.assessmentStrategicForm.controls["aoQuantity"].value);
    const strategicAssessment: StrategicAssessment = {
      id: 0,
      postDescriptionTitle: this.assessmentStrategicForm.controls["postDescriptionTitle"].value,
      allocatedSpace: allocatedSpace,
      userImmovableAssetManagementPlanId: this.uamp.id,
      surplusShortageAccommodation: (allocatedSpace - aoRequirement),
      percentageUtilised: (allocatedSpace / aoRequirement),
      fbpLevel: this.assessmentStrategicForm.controls["fbpLevel"].value,
      fbpQuantity: this.assessmentStrategicForm.controls["fbpQuantity"].value,
      fbpNorm: this.assessmentStrategicForm.controls["fbpNorm"].value,
      fbpRequirement: (this.assessmentStrategicForm.controls["fbpLevel"].value + this.assessmentStrategicForm.controls["fbpQuantity"].value),
      aoLevel: this.assessmentStrategicForm.controls["aoLevel"].value,
      aoQuantity: this.assessmentStrategicForm.controls["aoQuantity"].value,
      aoNorm: this.assessmentStrategicForm.controls["aoNorm"].value,
      aoRequirement: aoRequirement,
    };
    this.strategicAssessments.push(strategicAssessment);
    if(this.uamp.templeteThree != null)
    {
      this.uamp.templeteThree.strategicAssessments = this.strategicAssessments
    }else{
      this.uamp.templeteThree = {
        id: 0,
        strategicAssessments: this.strategicAssessments
      };
    }
    this.uampService.assignUamp(this.uamp);
    this.resetForm();
  }

  resetForm() {
    this.assessmentStrategicForm.reset();
  }
}