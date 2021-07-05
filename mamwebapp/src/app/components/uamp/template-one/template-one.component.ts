import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
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
  programmes: Programme[] = [];
  selectedprogramme: Programme;
  userDepartment: string = "Public works, roads & transport";
  optimalSupportingAccommodation: OptimalSupportingAccommodation = {
    id: 0,
    supportingAccommodation: undefined,
    mission: undefined
  };
  programmeForm: FormGroup;
  submitted: boolean = false;
  buttonItems: MenuItem[];
  @Input() uamp: any;
  @Output() updatedUamp = new EventEmitter();

  constructor(private formBuilder: FormBuilder, private messageService: MessageService) {

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

    if (this.uamp.templeteOne.optimalSupportingAccommodation)

      this.optimalSupportingAccommodation.mission = this.uamp.templeteOne.optimalSupportingAccommodation.mission;
    this.optimalSupportingAccommodation.supportingAccommodation = this.uamp.templeteOne.optimalSupportingAccommodation.supportingAccommodation;


    this.programmes = this.uamp.templeteOne.programmes;
  }

  update() {

  }
  updateUamp() {
    this.updatedUamp.emit(this.uamp);
  }
  confirmDelete() {

  }

  addProgram() {

    const programme: Programme = {
      id: 0,
      userImmovableAssetManagementPlanId: this.uamp.id,
      corporateObjective: this.programmeForm.controls["corporateObjective"].value,
      outcomes: this.programmeForm.controls["outcomes"].value,
      optimalSupportingAccommodationSolution: this.programmeForm.controls["optimalSupportingAccommodationSolution"].value,
      rationaleChosenSolution: this.programmeForm.controls["rationaleChosenSolution"].value,
    };
    this.programmes.push(programme);  
    this.updatedUamp.emit(this.uamp);
    this.resetForm();
  }

  resetForm() {
    this.programmeForm.reset();
  }

  selectProgramme(programme: Programme){
    this.selectedprogramme = programme;
  }
}
