import { Component,Input, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { Facility } from 'src/app/models/facility.model';
import { MessageService } from 'primeng/api';
import { AssetFunctionalPerformance } from '../../../models/asset-functional-performance.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { StrategicNeedsAssessment } from 'src/app/models/strategic-needs-assessment';

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

  constructor(public uampService: UAMPService, private formBuilder: FormBuilder, private messageService: MessageService) {
    
   }

  ngOnInit() {
    this.assessmentStrategicForm = this.formBuilder.group({
      postDescriptionTitle:['']
      
    });   
  }

  addStrategicNeedsAssessment() {
    this.strategicNeedsAssessments.push(new StrategicNeedsAssessment());
  }
  
}
