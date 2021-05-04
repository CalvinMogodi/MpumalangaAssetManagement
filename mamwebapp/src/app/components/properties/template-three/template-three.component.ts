import { Component,Input, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { UAMPService } from 'src/app/services/uamp/uamp.service';
import { Facility } from 'src/app/models/facility.model';
import { MessageService } from 'primeng/api';
import { AssetFunctionalPerformance } from '../../../models/asset-functional-performance.model';

@Component({
  selector: 'app-template-three',
  templateUrl: './template-three.component.html',
  styleUrls: ['./template-three.component.css'],
  providers: [MessageService]
})
export class TemplateThreeComponent implements OnInit {
  assetsFunctionalPerformances: AssetFunctionalPerformance[] = [];
  @Input() facilities: Facility[];
  constructor(public uampService: UAMPService, private messageService: MessageService) {
    
   }

  ngOnInit() {
    //this.getFunctionalPerformances();
    this.facilities.forEach( (element) => {
      let assetFunctionalPerformance: AssetFunctionalPerformance = {
        province: element.land.geographicalLocation.province,
        town: element.land.geographicalLocation.province,
        uniqueIdentifyingCode: element.clientCode,
        possibleNonAssetSolutions: undefined,
        commonAssetDescription: element.name,
        currentUser: undefined,
        requiredPerformanceStandard: undefined,
        accessabilityRating: undefined,
        suitabilityIndex: undefined,
        conditionRating: undefined,
        operatingPerformanceIndex:undefined,
        functionalPerformanceRating: undefined,
      };
      this.assetsFunctionalPerformances.push(assetFunctionalPerformance);
    });
  }

  addAssetFunctionalPerformance() {
    this.assetsFunctionalPerformances.push(new AssetFunctionalPerformance());
  }

  saveFunctionalPerformances() {
    this.uampService.addFunctionalPerformances(this.assetsFunctionalPerformances).pipe(first()).subscribe(result => {
      this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Functional performances are saved successful.' });
    });
  }

  getFunctionalPerformances() {
    this.uampService.getFunctionalPerformances().pipe(first()).subscribe(assetsFunctionalPerformances => {
      this.assetsFunctionalPerformances = assetsFunctionalPerformances;
    });
  }

}
