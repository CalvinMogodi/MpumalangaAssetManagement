import { Component, OnInit } from '@angular/core';

import { AssetFunctionalPerformance } from '../../../models/asset-functional-performance.model';

@Component({
  selector: 'app-template-three',
  templateUrl: './template-three.component.html',
  styleUrls: ['./template-three.component.css']
})
export class TemplateThreeComponent implements OnInit {
  assetsFunctionalPerformances: AssetFunctionalPerformance[] = [];

  constructor() {
    this.assetsFunctionalPerformances.push(new AssetFunctionalPerformance());
   }

  ngOnInit() {
  }

  addAssetFunctionalPerformance() {
    this.assetsFunctionalPerformances.push(new AssetFunctionalPerformance());
  }

}
