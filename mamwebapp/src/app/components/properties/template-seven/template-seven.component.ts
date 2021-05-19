import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Facility } from 'src/app/models/facility.model';

@Component({
  selector: 'app-template-seven',
  templateUrl: './template-seven.component.html',
  styleUrls: ['./template-seven.component.css'],
  providers: [MessageService]
})
export class TemplateSevenComponent implements OnInit {
  @Input() properties: Facility[];


  constructor() { 
    
  }

  ngOnInit() {
  }

}
