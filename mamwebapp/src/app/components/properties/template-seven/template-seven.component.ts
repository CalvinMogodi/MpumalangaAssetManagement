import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { element } from 'protractor';
import { Facility } from 'src/app/models/facility.model';
import { FacilityService } from 'src/app/services/facility/facility.service';

@Component({
  selector: 'app-template-seven',
  templateUrl: './template-seven.component.html',
  styleUrls: ['./template-seven.component.css'],
  providers: [MessageService]
})
export class TemplateSevenComponent implements OnInit {
  @Input() properties: Facility[];
  umap: any = {
    templeteSeven:{}
  };

  constructor(private facilityService: FacilityService) { 
    this.facilityService.umapTempleteChange.subscribe((value) => {
      if(value)
      {
        this.umap = value;
        this.umap.templeteSeven = {};
      }           
      
    });
  }

  ngOnInit() {
  } 

  umapTempleteValidate(){
    let isValid: boolean = true;
      
    return isValid;
  }

  newCapitalWorksT41RequiredBudget(){
    let amount: number = 0;
    if(this.umap.templeteFourPointOne){
      this.umap.templeteFourPointOne.forEach(acquisitionPlan=> {
        amount = amount + acquisitionPlan.totalAmountRequired;
      }); 
    }       
    return amount;
  }

  mtefAllocatoion (year: number, mtefAllocatoion: string, previousYearMtefAllocatoion: string, templete : string){
    let amount: number = 0;

    if(this.umap[templete]){
      this.umap[templete].forEach(element=> {
        if(element[previousYearMtefAllocatoion]){
          if(year === 1){
            amount = amount + element[previousYearMtefAllocatoion];
          }         
        }        
      }); 
      if(year !== 1){
        amount = (6 / 100 * this.umap.templeteSeven[previousYearMtefAllocatoion]) + this.umap.templeteSeven[previousYearMtefAllocatoion];
      } 
    }
    this.umap.templeteSeven[mtefAllocatoion] = amount;
    return amount;
  }

  amountRequired(year: number, mtefAllocatoion: string, amountRequired: string, templete : string){
    let amount: number = 0;

    if(this.umap[templete]){ 
      amount = (4 / 100 * this.umap.templeteSeven[mtefAllocatoion]) + this.umap.templeteSeven[mtefAllocatoion];
    }
    this.umap.templeteSeven[amountRequired] = amount;
    return amount;
  }

  shortfall(year: number, mtefAllocatoion: string, amountRequired: string, templete : string){
    let amount: number = 0;
    let name = "shortfall"+ mtefAllocatoion + year;

    if(this.umap[templete]){   
        amount = this.umap.templeteSeven[mtefAllocatoion] - this.umap.templeteSeven[amountRequired];
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }

  totalCurrentCosts(year: number, startWith: string, containStr: string){
    let amount: number = 0;

    for(var propertyName in this.umap.templeteSeven) {
      if(propertyName && propertyName != 'undefined' ){
        let _property = propertyName.startsWith(startWith);
        if(_property && containStr){
          var splitted = containStr.split(" ");
          _property = propertyName.includes(splitted[0]) || propertyName.includes(splitted[1]) ? true : false;        
        }          

        let property = propertyName.endsWith(year.toString());
        if(_property && property)
        {
          if(_property && containStr){
            amount = amount + this.umap.templeteSeven[propertyName];
          }
          else{
            amount = amount + this.umap.templeteSeven[propertyName];
          }
        }
      }    
    }; 

    if(containStr){
      const colName = 'totalCapitalCosts' + startWith + year
      this.umap.templeteSeven[colName] = amount;
    }
    else{
      const colName = 'totalCurrentCosts' + startWith + year
      const totalCurrentCosts = 'totalCapitalCosts' + startWith + year;
      if(this.umap.templeteSeven[totalCurrentCosts] != 0)
        amount = amount - this.umap.templeteSeven[totalCurrentCosts];
      this.umap.templeteSeven[colName] = amount;
    }
   
    return amount;
  }

  totalCapitalWorksAndRecurrentCosts(year: number, startWith: string){
    let amount: number = 0;

    for(var propertyName in this.umap.templeteSeven) {
      if(propertyName && propertyName != 'undefined' ){
        let _property = propertyName.startsWith(startWith); 
        let property = propertyName.endsWith(year.toString());
        if(_property && property)
          amount = amount + this.umap.templeteSeven[propertyName];         
      }    

    };
    const colName = 'totalCapitalCostsAndRecurrentCosts' + startWith + year
    this.umap.templeteSeven[colName] = amount;
   
    return amount;
  }
}
