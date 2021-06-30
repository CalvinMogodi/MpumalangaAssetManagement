import { Component, OnInit, Input, Output,EventEmitter } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UAMP } from '../../../models/uamp.model'
import { Programme } from 'src/app/models/programme.model';
import { OptimalSupportingAccommodation } from 'src/app/models/optimal-supporting-accommodation.model';
import { Observable } from 'rxjs';
import { NgZone } from '@angular/core';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css'],
  providers: [MessageService]
})
export class TemplateOneComponent implements OnInit {
  programmes: Programme[] = [];
  userDepartment: string = "Public works, roads & transport";
  optimalSupportingAccommodation: OptimalSupportingAccommodation = {
    id: 0,
    supportingAccommodation: undefined,
    mission: undefined
  };
  programmeForm: FormGroup;
  submitted: boolean = false;
  buttonItems: MenuItem[];
  @Input() uamp: UAMP;

  constructor(_ngZone: NgZone, public uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) {
   
  }

  ngOnInit() {
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

    this.programmeForm = this.formBuilder.group({
      corporateObjective: [''],
      outcomes: [''],
      optimalSupportingAccommodationSolution: [''],
      rationaleChosenSolution: [''],
    });

    this.optimalSupportingAccommodation.mission = this.uamp.templeteOne.optimalSupportingAccommodation.mission;
    this.optimalSupportingAccommodation.supportingAccommodation =this.uamp.templeteOne.optimalSupportingAccommodation.supportingAccommodation;

    this.programmes = this.uamp.templeteOne.programmes;
  }

  update() {

  }

  confirmDelete() {

  }

  addProgram() {
    
    const programme: Programme = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uampService.uamp.id,
      corporateObjective: this.programmeForm.controls["corporateObjective"].value,
      outcomes: this.programmeForm.controls["outcomes"].value,
      optimalSupportingAccommodationSolution: this.programmeForm.controls["optimalSupportingAccommodationSolution"].value,
      rationaleChosenSolution: this.programmeForm.controls["rationaleChosenSolution"].value,
    };
    this.programmes.push(programme);
    this.uampService.uamp.templeteOne = {
      id: 0,
      optimalSupportingAccommodation: this.optimalSupportingAccommodation,
      programmes: this.programmes
    };
    //this.updatedUamp.emit(this.uamp);
    this.resetForm();
  }

  resetForm() {
    this.programmeForm.reset();
  }
}
