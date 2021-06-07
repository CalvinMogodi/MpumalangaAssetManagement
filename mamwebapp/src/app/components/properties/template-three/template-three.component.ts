import { Component, Input, OnInit } from '@angular/core';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { Facility } from 'src/app/models/facility.model';
import { MenuItem, MessageService } from 'primeng/api';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FacilityService } from 'src/app/services/facility/facility.service';

@Component({
  selector: 'app-template-three',
  templateUrl: './template-three.component.html',
  styleUrls: ['./template-three.component.css'],
  providers: [MessageService]
})
export class TemplateThreeComponent implements OnInit {
  strategicNeedsAssessments: any[] = [];
  @Input() properties: Facility[];
  assessmentStrategicForm: FormGroup;
  buttonItems: MenuItem[];
  umap: any = {};

  constructor(private facilityService: FacilityService, public uampService: UAMPService, private formBuilder: FormBuilder, private messageService: MessageService) {
    this.facilityService.umapTempleteChange.subscribe((value) => {
      if(value)
      {
        this.umap = value;
      }    
      this.umap.templeteThree = this.properties;
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
    const strategicNeedsAssessment = {
      id: this.strategicNeedsAssessments.length + 1,
      postDescriptionTitle: this.assessmentStrategicForm.controls["postDescriptionTitle"].value,
      allocatedSpace: allocatedSpace,
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
    this.strategicNeedsAssessments.push(strategicNeedsAssessment);
    this.resetForm();
  }

  resetForm() {
    this.assessmentStrategicForm.reset();
  }
}
