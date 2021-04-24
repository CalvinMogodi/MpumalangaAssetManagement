import { Component, OnInit } from '@angular/core';

import { RepairRequirement } from '../../../models/repair-requirements.model';

@Component({
  selector: 'app-repair-requirements',
  templateUrl: './repair-requirements.component.html',
  styleUrls: ['./repair-requirements.component.css']
})
export class RepairRequirementsComponent implements OnInit {
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
