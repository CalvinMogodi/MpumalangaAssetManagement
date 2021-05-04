import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';

import { AssetFunctionalPerformance } from '../../../models/asset-functional-performance.model';

@Component({
  selector: 'app-template-three',
  templateUrl: './template-three.component.html',
  styleUrls: ['./template-three.component.css']
})
export class TemplateThreeComponent implements OnInit {
  assetsFunctionalPerformances: AssetFunctionalPerformance[] = [];

  constructor(public uampService: UAMPService) {
    //this.assetsFunctionalPerformances.push(new AssetFunctionalPerformance());
   }

  ngOnInit() {
    this.getFunctionalPerformances();
  }

  addAssetFunctionalPerformance() {
    this.assetsFunctionalPerformances.push(new AssetFunctionalPerformance());
  }

  saveFunctionalPerformances() {
    this.uampService.addFunctionalPerformances(this.assetsFunctionalPerformances).pipe(first()).subscribe(result => {
              var tes = "";
    });
  }

  getFunctionalPerformances() {
    this.uampService.getFunctionalPerformances().pipe(first()).subscribe(assetsFunctionalPerformances => {
      this.assetsFunctionalPerformances = assetsFunctionalPerformances;
    });
  }

}
