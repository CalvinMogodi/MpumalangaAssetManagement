import { Component, OnInit } from '@angular/core';

import { RepairRequirement } from '../../../models/repair-requirements.model';

@Component({
  selector: 'app-template-seven',
  templateUrl: './template-seven.component.html',
  styleUrls: ['./template-seven.component.css']
})
export class TemplateSevenComponent implements OnInit {
  repairRequirments: RepairRequirement[] = [];

  constructor() { 
    this.repairRequirments.push(new RepairRequirement());
  }

  ngOnInit() {
  }

  addRepairRequirement() {
    this.repairRequirments.push(new RepairRequirement());
  }

}
