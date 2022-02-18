import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { first } from 'rxjs/operators';
import { LeasedProperty } from 'src/app/models/leased-property.model';
import { LeasedPropertiesService } from 'src/app/services/leased-property/leased-property.service';

@Component({
  selector: 'app-leased-property',
  templateUrl: './leased-property.component.html',
  styleUrls: ['./leased-property.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class LeasedPropertyComponent implements OnInit {
    activeIndex: number = 0;
    @Input() selectedLeasedProperty: any;
    constructor(private leasedPropertiesService: LeasedPropertiesService) { }

    ngOnInit() {

    }

    onLandRemoveFile(e){
        
    }

    onLandSelectFile(e){

    }
}