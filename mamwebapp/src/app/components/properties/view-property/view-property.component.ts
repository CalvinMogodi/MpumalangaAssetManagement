import { Component, Input, OnInit } from '@angular/core';
import { Facility } from 'src/app/models/facility.model';

@Component({
  selector: 'app-view-property',
  templateUrl: './view-property.component.html',
  styleUrls: ['./view-property.component.css']
})
export class ViewPropertyComponent implements OnInit {
  activeIndex: number = 0;
  @Input() selectedFacility: Facility;

  constructor() { }

  ngOnInit() {
  }

}
