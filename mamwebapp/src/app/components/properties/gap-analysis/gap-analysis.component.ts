import { Component, OnInit } from '@angular/core';

import { GapAnalysis } from '../../../models/gap-analysis.model';

@Component({
  selector: 'app-gap-analysis',
  templateUrl: './gap-analysis.component.html',
  styleUrls: ['./gap-analysis.component.css']
})
export class GapAnalysisComponent implements OnInit {
  
  gapAnalyses: GapAnalysis[] = [];

  constructor() { 
    this.gapAnalyses.push(new GapAnalysis());
  }

  ngOnInit() {
  }

  addGapAnalysis() {
    this.gapAnalyses.push(new GapAnalysis());
  }

}
