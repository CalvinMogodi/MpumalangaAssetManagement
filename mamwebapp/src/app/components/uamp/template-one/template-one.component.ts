import { Component, OnInit } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { UampService } from 'src/app/services/uamp/uamp.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UAMP } from '../../../models/uamp.model'
import { Programme } from 'src/app/models/programme.model';
import { OptimalSupportingAccommodation } from 'src/app/models/optimal-supporting-accommodation.model';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css'],
  providers: [MessageService]
})
export class TemplateOneComponent implements OnInit {
  programmes: Array<Programme> = [];
  userDepartment: string = "Public works, roads & transport";
  optimalSupportingAccommodation: OptimalSupportingAccommodation = {id: 0,
    supportingAccommodation: undefined,
    mission: undefined};
  optimalSupportingAccommodationForm: FormGroup;
  programmeForm: FormGroup;
  submitted: boolean = false;
  buttonItems: MenuItem[];
  uamp: UAMP;

  constructor(public uampService: UampService, private formBuilder: FormBuilder, private messageService: MessageService) {
   
    //this.programmes.push(new Programme());
    this.uampService.uampChange.subscribe((value) => {
      if (value) {
        this.uamp = Object.assign(new UAMP(), value); 
        this.uamp.templeteOne = {
          id: 0,
          optimalSupportingAccommodation: this.optimalSupportingAccommodation,
          programmes: this.programmes
        };
      }
    })
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
    this.optimalSupportingAccommodationForm = this.formBuilder.group({
      mission: [''],
      optimalSupportingAccommodation: [''],
    });

    this.programmeForm = this.formBuilder.group({
      corporateObjective: [''],
      outcomes: [''],
      optimalSupportingAccommodationSolution: [''],
      rationaleChosenSolution: [''],
    });
  }

  get o() { return this.optimalSupportingAccommodationForm.controls; }
  get p() { return this.programmeForm.controls; }

  update() {

  }

  confirmDelete() {

  }

  addProgram() {
    this.optimalSupportingAccommodation = {
      id: 0,
      mission: this.optimalSupportingAccommodationForm.controls["mission"].value,
      supportingAccommodation: this.optimalSupportingAccommodationForm.controls["optimalSupportingAccommodation"].value
    }
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
    this.uampService.assignUamp(this.uampService.uamp);
    this.resetForm();    
  }

  resetForm() {
    this.programmeForm.reset();
  }
}
