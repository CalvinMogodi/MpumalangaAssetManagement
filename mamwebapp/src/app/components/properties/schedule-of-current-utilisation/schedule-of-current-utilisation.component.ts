import { Component, OnInit } from '@angular/core';

import { CurrentUtlisation } from '../../../models/current-utilisation.model';

@Component({
  selector: 'app-schedule-of-current-utilisation',
  templateUrl: './schedule-of-current-utilisation.component.html',
  styleUrls: ['./schedule-of-current-utilisation.component.css']
})
export class ScheduleOfCurrentUtilisationComponent implements OnInit {
  scheduleCurrentUtilisation: CurrentUtlisation[] = [];

  constructor() {
    this.scheduleCurrentUtilisation.push(new CurrentUtlisation());
   }

  ngOnInit() {
  }

  addUtilisation() {
    this.scheduleCurrentUtilisation.push(new CurrentUtlisation());
  }

}
