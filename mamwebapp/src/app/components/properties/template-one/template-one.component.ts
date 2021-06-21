import { Component, OnInit } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Programme } from '../../../models/programme.model';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css'],
  providers: [MessageService]
})
export class TemplateOneComponent implements OnInit {
  programmes: any[];
  userDepartment: string = "Public works, roads & transport";
  optimalSupportingAccommodationForm: FormGroup;
  programmeForm: FormGroup;
  submitted: boolean = false;
  buttonItems: MenuItem[];
  uamp: any = {};

  constructor(public facilityService: FacilityService,public uampService: UAMPService, private formBuilder: FormBuilder, private messageService: MessageService) {
    this.programmes = [];
    //this.programmes.push(new Programme());
    this.facilityService.uampTempleteChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
      }
    
      this.uamp.templeteOne = this.programmes;
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
    const programme = {
      id: this.programmes.length + 1,
      corporateObjective: this.programmeForm.controls["corporateObjective"].value,
      outcomes: this.programmeForm.controls["outcomes"].value,
      optimalSupportingAccommodationSolution: this.programmeForm.controls["optimalSupportingAccommodationSolution"].value,
      rationaleChosenSolution: this.programmeForm.controls["rationaleChosenSolution"].value,
    };
    this.programmes.push(programme);
    this.resetForm();
  }

  resetForm() {
    this.programmeForm.reset();
  }

  saveProgrammes() {
    this.uampService.addProgrammes(this.programmes).pipe(first()).subscribe(result => {
      this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Programmes are saved successful.' });
    });
  }

  getProgrammes() {
    this.uampService.getProgrammes().pipe(first()).subscribe(programmes => {
      this.programmes = programmes;
    });
  }

}
