import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { element } from 'protractor';
import { Facility } from 'src/app/models/facility.model';
import { UampService } from 'src/app/services/uamp/uamp.service';

@Component({
  selector: 'app-template-seven',
  templateUrl: './template-seven.component.html',
  styleUrls: ['./template-seven.component.css'],
  providers: [MessageService]
})
export class TemplateSevenComponent implements OnInit {
  @Input() properties: Facility[];
  uamp: any = {
    templeteSeven:{}
  };
  municipalUtilityServices: any;

  constructor(private uampService: UampService) { 
    this.uampService.uampChange.subscribe((value) => {
      if(value)
      {
        this.uamp = value;
        this.uamp.templeteSeven = {};
        if(this.uamp.templeteTwoPointOne){
          if(this.uamp.templeteTwoPointOne)
            this.municipalUtilityServices = this.getMunicipalUtilityServices(this.uamp.templeteTwoPointOne);
        }
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
    if(this.uamp.templeteFourPointOne){
      this.uamp.templeteFourPointOne.forEach(acquisitionPlan=> {
        amount = amount + acquisitionPlan.totalAmountRequired;
      }); 
    }       
    return amount;
  }

  mtefAllocatoion (year: number, mtefAllocatoion: string, previousYearMtefAllocatoion: string, templete : string){
    let amount: number = 0;

    if(this.uamp[templete]){
      this.uamp[templete].forEach(element=> {
        if(element[previousYearMtefAllocatoion]){
          if(year === 1){
            amount = amount + element[previousYearMtefAllocatoion];
          }         
        }        
      }); 
      if(year !== 1){
        amount = (6 / 100 * this.uamp.templeteSeven[previousYearMtefAllocatoion]) + this.uamp.templeteSeven[previousYearMtefAllocatoion];
      } 
    }
    this.uamp.templeteSeven[mtefAllocatoion] = amount;
    return amount;
  }

  amountRequired(year: number, mtefAllocatoion: string, amountRequired: string, templete : string){
    let amount: number = 0;

    if(this.uamp[templete]){ 
      amount = (4 / 100 * this.uamp.templeteSeven[mtefAllocatoion]) + this.uamp.templeteSeven[mtefAllocatoion];
    }
    this.uamp.templeteSeven[amountRequired] = amount;
    return amount;
  }

  shortfall(year: number, mtefAllocatoion: string, amountRequired: string, templete : string){
    let amount: number = 0;
    let name = "shortfall"+ mtefAllocatoion + year;

    if(this.uamp[templete]){   
        amount = this.uamp.templeteSeven[mtefAllocatoion] - this.uamp.templeteSeven[amountRequired];
    }
    this.uamp.templeteSeven[name] = amount;
    return amount;
  }

  totalCurrentCosts(year: number, startWith: string, containStr: string){
    let amount: number = 0;

    for(var propertyName in this.uamp.templeteSeven) {
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
            amount = amount + this.uamp.templeteSeven[propertyName];
          }
          else{
            amount = amount + this.uamp.templeteSeven[propertyName];
          }
        }
      }    
    }; 

    if(containStr){
      const colName = 'totalCapitalCosts' + startWith + year
      this.uamp.templeteSeven[colName] = amount;
    }
    else{
      const colName = 'totalCurrentCosts' + startWith + year
      const totalCurrentCosts = 'totalCapitalCosts' + startWith + year;
      if(this.uamp.templeteSeven[totalCurrentCosts] != 0)
        amount = amount - this.uamp.templeteSeven[totalCurrentCosts];
      this.uamp.templeteSeven[colName] = amount;
    }
   
    return amount;
  }

  totalCapitalWorksAndRecurrentCosts(year: number, startWith: string){
    let amount: number = 0;

    for(var propertyName in this.uamp.templeteSeven) {
      if(propertyName && propertyName != 'undefined' ){
        let _property = propertyName.startsWith(startWith); 
        let property = propertyName.endsWith(year.toString());
        if(_property && property)
          amount = amount + this.uamp.templeteSeven[propertyName];         
      }    

    };
    const colName = 'totalCapitalCostsAndRecurrentCosts' + startWith + year
    this.uamp.templeteSeven[colName] = amount;
   
    return amount;
  }

  mtefAllocatoionMUS (year: number, mtefAllocatoion: string, previousYearMtefAllocatoion: string, value : number){
    let amount: number = 0;
    if(year === 1){
      amount = amount + value;
    }   
    if(year !== 1){
      amount = (6 / 100 * this.uamp.templeteSeven[previousYearMtefAllocatoion]) + this.uamp.templeteSeven[previousYearMtefAllocatoion];
    } 

    this.uamp.templeteSeven[mtefAllocatoion] = amount;
    return amount;
  }

  amountRequiredMUS(year: number, mtefAllocatoion: string, amountRequired: string){
    let amount: number = 0;

    if(mtefAllocatoion){ 
      amount = (4 / 100 * this.uamp.templeteSeven[mtefAllocatoion]) + this.uamp.templeteSeven[mtefAllocatoion];
    }
    this.uamp.templeteSeven[amountRequired] = amount;
    return amount;
  }

  shortfallMUS(year: number, mtefAllocatoion: string, amountRequired: string){
    let amount: number = 0;
    let name = "shortfall"+ mtefAllocatoion + year;

    if(mtefAllocatoion && amountRequired){   
        amount = this.uamp.templeteSeven[mtefAllocatoion] - this.uamp.templeteSeven[amountRequired];
    }
    this.uamp.templeteSeven[name] = amount;
    return amount;
  }

  getMunicipalUtilityServices(properties:any[]){
    
    const municipalUtilityServices: any[] = [];

    properties.forEach(property => {
      if(property.municipalUtilityServices){
      property.municipalUtilityServices.forEach(ele => {  
        let _municipalUtilityServices = municipalUtilityServices.filter(m => m.name == ele.name);
        if(_municipalUtilityServices.length > 0){
          _municipalUtilityServices[0].totalCost = _municipalUtilityServices[0].totalCost + ele.cost;
        }else{
          let municipalUtilityService = {
            name: ele.name,
            totalCost: ele.cost
          };
          municipalUtilityServices.push(municipalUtilityService);
        }        
       });      
      }
    });

    return municipalUtilityServices;
  }
}
