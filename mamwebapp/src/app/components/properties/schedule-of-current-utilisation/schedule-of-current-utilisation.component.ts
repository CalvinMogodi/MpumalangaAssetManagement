import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { MessageService } from 'primeng/api';
import { CurrentUtlisation } from '../../../models/current-utilisation.model';

@Component({
  selector: 'app-schedule-of-current-utilisation',
  templateUrl: './schedule-of-current-utilisation.component.html',
  styleUrls: ['./schedule-of-current-utilisation.component.css'],
  providers: [MessageService]
})
export class ScheduleOfCurrentUtilisationComponent implements OnInit {
  scheduleCurrentUtilisation: CurrentUtlisation[] = [];

  constructor(public uampService: UAMPService, private messageService: MessageService) {
    //this.scheduleCurrentUtilisation.push(new CurrentUtlisation());
   }

  ngOnInit() {
    this.getUtilisations();
  }

  addUtilisation() {
    this.scheduleCurrentUtilisation.push(new CurrentUtlisation());
  }

  saveUtilisations() {
    this.uampService.addUtilisations(this.scheduleCurrentUtilisation).pipe(first()).subscribe(result => {
      this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Schedule current utilisation is saved successful.' });
    });
  }

  getUtilisations() {
    this.uampService.getUtilisations().pipe(first()).subscribe(scheduleCurrentUtilisation => {
      this.scheduleCurrentUtilisation = scheduleCurrentUtilisation;
    });
  }

}
