import { Component, Input, OnInit } from '@angular/core';
import { UAMP } from 'src/app/models/uamp.model';

@Component({
  selector: 'app-view-uamp',
  templateUrl: './view-uamp.component.html',
  styleUrls: ['./view-uamp.component.css']
})
export class ViewUampComponent implements OnInit {
  activeIndex: number = 0;
  @Input() uamp: UAMP;

  constructor() { }

  ngOnInit() {
  }

}
