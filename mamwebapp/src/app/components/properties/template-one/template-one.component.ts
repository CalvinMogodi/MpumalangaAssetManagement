import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Programme } from '../../../models/programme.model';

@Component({
  selector: 'app-template-one',
  templateUrl: './template-one.component.html',
  styleUrls: ['./template-one.component.css'],
  providers: [MessageService]
})
export class TemplateOneComponent implements OnInit {
  programmes: Programme[];
  userDepartment:string = "Public works, roads & transport";
  optimalSupportingAccommodationForm: FormGroup;
  programmeForm: FormGroup;
  submitted: boolean = false;

  constructor(public uampService: UAMPService, private formBuilder: FormBuilder, private messageService: MessageService) { 
    this.programmes = [];
    //this.programmes.push(new Programme());
  }

  ngOnInit() {
    this.getProgrammes();
    this.optimalSupportingAccommodationForm = this.formBuilder.group({
      mission:[''],
      optimalSupportingAccommodation:[''],
    });

    this.programmeForm = this.formBuilder.group({
      corporateObjective:[''],
      outcomes:[''],
      optimalSupportingAccommodationSolution:[''],
      rationaleChosenSolution:[''],
    });
  }

  get o() { return this.optimalSupportingAccommodationForm.controls; }
  get p() { return this.programmeForm.controls; }

  addProgram() {
    this.programmes.push(new Programme());
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
