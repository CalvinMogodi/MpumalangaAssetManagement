import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UAMP } from '../../../models/uamp.model'
import { Programme } from 'src/app/models/programme.model';
import { OptimalSupportingAccommodation } from 'src/app/models/optimal-supporting-accommodation.model';
import { UampService } from 'src/app/services/uamp/uamp.service';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css'],
  providers: [MessageService]
})
export class TemplateOneComponent implements OnInit {
  programmes: Programme[] = [];
  selectedProgramme: Programme;
  userDepartment: string = "Public works, roads & transport";
  optimalSupportingAccommodation: OptimalSupportingAccommodation = {
    id: 0,
    supportingAccommodation: undefined,
    mission: undefined
  };
  programmeForm: FormGroup;
  submitted: boolean = false;
  buttonItems: MenuItem[];
  showComfirmationDelete = false;
  isEdit = false;
  @Input() uamp: UAMP;
  @Output() updatedUamp = new EventEmitter();

  constructor(private formBuilder: FormBuilder, private messageService: MessageService,private uampService: UampService) {
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
        this.programmes = this.uamp.templeteOne.programmes;
      }  
    });
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
    this.optimalSupportingAccommodation.supportingAccommodation = this.uamp.templeteOne.optimalSupportingAccommodation.supportingAccommodation;

    this.programmes = this.uamp.templeteOne.programmes;
  }

  update() {
    this.programmeForm = this.formBuilder.group({
      corporateObjective: [this.selectedProgramme.corporateObjective],
      outcomes: [this.selectedProgramme.outcomes],
      optimalSupportingAccommodationSolution: [this.selectedProgramme.optimalSupportingAccommodationSolution],
      rationaleChosenSolution: [this.selectedProgramme.rationaleChosenSolution],
    });
    this.isEdit = true;
  }

  onUpdate() {
    const programme: Programme = {
      id: this.selectedProgramme.id,
      userImmovableAssetManagementPlanId: this.uamp.id,
      corporateObjective: this.programmeForm.controls["corporateObjective"].value,
      outcomes: this.programmeForm.controls["outcomes"].value,
      optimalSupportingAccommodationSolution: this.programmeForm.controls["optimalSupportingAccommodationSolution"].value,
      rationaleChosenSolution: this.programmeForm.controls["rationaleChosenSolution"].value,
    };

    var index = this.programmes.indexOf(this.selectedProgramme); 
    this.programmes[index] = programme;
    this.isEdit = false;
    this.updatedUamp.emit(this.uamp);
    this.resetForm();
  }
  
  updateUamp() {
    this.updatedUamp.emit(this.uamp);
  }

  confirmDelete() {
    this.showComfirmationDelete = true;
  }

  deleteProgramme(){
    if(this.selectedProgramme.id == 0){
      var index = this.programmes.indexOf(this.selectedProgramme);    
      this.programmes.splice(index, 1);
    }else{
      this.uampService.deleteProgramme(this.selectedProgramme).pipe(first()).subscribe(isDeleted => {
        if (isDeleted) {
          this.messageService.add({ severity: 'warn', summary: 'Delete Programme', detail: 'Programme has been deleted successful.' });   
          var index = this.programmes.indexOf(this.selectedProgramme);    
          this.programmes.splice(index, 1);
        } else {
          this.messageService.add({ severity: 'error', summary: 'Delete Programme', detail: 'Programme is not deleted successful.' });
        }
      }, error => {
        this.messageService.add({ severity: 'error', summary: 'Error Occurred', detail: 'An error occurred while processing your request. please try again!' });
      });
    }    
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
    this.selectedProgramme = programme;
  }
}