import { Component, Input, OnInit } from '@angular/core';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { Facility } from 'src/app/models/facility.model';
import { MenuItem, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { UAMP } from 'src/app/models/uamp.model';
import { StrategicAssessment } from 'src/app/models/strategic-assessment.model';

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

  update() {

  }

  confirmDelete() {

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
