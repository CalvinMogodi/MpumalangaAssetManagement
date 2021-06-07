import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
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

  mtefAllocatoion(){
    let amount: number = 0;
     
    return amount;
  }

  mtefAllocatoionT51Y1(){
    let amount: number = 0;
    if(this.umap.templeteFivePointOne){
      this.umap.templeteFivePointOne.forEach(operationPlan=> {
        amount = amount + operationPlan.totalAmountRequired;
      }); 
    }
    this.umap.templeteSeven.mtefAllocatoionT51Y1 = amount;
    return amount;
  }

  amountRequiredT51Y1(){
    let amount: number = 0;
    if(this.umap.templeteFivePointOne){      
      amount = (this.umap.templeteSeven.mtefAllocatoionT51Y1 * 4) + this.umap.templeteSeven.mtefAllocatoionT51Y1;
    }
    this.umap.templeteSeven.amountRequiredT51Y1 = amount;
    return amount;
  }

  shortfallT51Y1(){
    let amount: number = 0;
    if(this.umap.templeteFivePointOne){
      amount = this.umap.templeteSeven.mtefAllocatoionT51Y1 - this.umap.templeteSeven.amountRequiredT51Y1;
    }
    this.umap.templeteSeven.shortfallT51Y1 = amount;
    return amount;
  }

  rraMtefAllocatoionT51(year : number){
    let amount: number = 0;
    let mtefAllocatoion = "mtefAllocatoionT51Y" + (year - 1);
    let _mtefAllocatoion = "mtefAllocatoionT51Y" + year;
    if(this.umap.templeteFivePointOne){
      amount = (this.umap.templeteSeven[mtefAllocatoion] * 6) + this.umap.templeteSeven[mtefAllocatoion];
    }
    this.umap.templeteSeven[_mtefAllocatoion] = amount;
    return amount;
  }

  amountRequiredT51(year : number){
    let amount: number = 0;
    let amountRequired = "amountRequiredT51Y" + (year - 1);
    let _amountRequired = "amountRequiredT51Y" + year;

    if(this.umap.templeteFivePointOne){            
      amount = (this.umap.templeteSeven[amountRequired] * 4) + this.umap.templeteSeven[amountRequired];
    }
    this.umap.templeteSeven[_amountRequired] = amount;
    return amount;
  }

  shortfallT51(year : number){
    let amount: number = 0;
    let name = "shortfallT51Y" + year;
    let amountRequired = "amountRequiredT51Y" + year;
    let mtefAllocatoion = "mtefAllocatoionT51Y" + year;

    if(this.umap.templeteFivePointOne){
      amount = this.umap.templeteSeven[mtefAllocatoion] - this.umap.templeteSeven[amountRequired];
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }

  rraMtefAllocatoionTotalCapitalCosts(year: number){
    let amount: number = 0;
   
    return amount;
  }

  amountRequiredTotalCapitalCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallTotalCapitalCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallTotalCapitalCostsPercentage(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionExistingLeasesT22(year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredExistingLeasesT22(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallExistingLeasesT22(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionNewleasesT42(year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredNewleasesT42(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallNewleasesT42(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionOperationalCostTelephoneServices (year: number){
    let amount: number = 0;
    let mtefAllocatoion = "mtefAllocatoionOctsY" + (year - 1);
    let _mtefAllocatoion = "mtefAllocatoionOctsY" + year;

    if(this.umap.templeteTwoPointOne){
      this.umap.templeteTwoPointOne.forEach(property=> {
        if(property.operationalCost){
          if(year === 1){
            amount = amount + property.operationalCost;
          }else{
            amount = (this.umap.templeteSeven[mtefAllocatoion] * 6) + this.umap.templeteSeven[mtefAllocatoion];
          }          
        }
        
      }); 
    }
    this.umap.templeteSeven[_mtefAllocatoion] = amount;
    return amount;
  }

  amountRequiredOperationalCostTelephoneServices(year: number){
    let amount: number = 0;
    let amountRequired = "amountRequiredOctsY" + (year - 1);
    let _amountRequired = "amountRequiredOctsY" + year;

    if(this.umap.templeteFivePointOne){  
      if(year === 1){
        amount = (this.umap.templeteSeven.mtefAllocatoionOctsY1 * 4) + this.umap.templeteSeven.mtefAllocatoionOctsY1;
      }else{
        amount = (this.umap.templeteSeven[amountRequired] * 4) + this.umap.templeteSeven[amountRequired];
      }
    }
    this.umap.templeteSeven[_amountRequired] = amount;
    return amount;
  }

  shortfallOperationalCostTelephoneServices(year: number){
    let amount: number = 0;
    let name = "shortfallOctsY" + year;
    let amountRequired = "amountRequiredOctsY" + year;
    let mtefAllocatoion = "mtefAllocatoionOctsY" + year;

    if(this.umap.templeteFivePointOne){      
      if(year === 1){
        amount = this.umap.templeteSeven.mtefAllocatoionOctsY1 - this.umap.templeteSeven.amountRequiredOctsY1;
      }else{
        amount = this.umap.templeteSeven[mtefAllocatoion] - this.umap.templeteSeven[amountRequired];
      }
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }

  mtefAllocatoionOperationalCostSecurity (year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredOperationalCostSecurity(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallOperationalCostSecurity(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionOperationalCostOthers (year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredOperationalCostOthers(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallOperationalCostOthers(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionMunicipalServicesStateOwnedT21(year: number){
    let amount: number = 0;
    let mtefAllocatoion = "mtefAllocatoionMssoT21Y" + (year - 1);
    let _mtefAllocatoion = "mtefAllocatoionMssoT21Y" + year;

    if(this.umap.templeteTwoPointOne){  
      this.umap.templeteTwoPointOne.forEach(property=> {
        if(property.municipalUtilityService){
          if(year === 1){
            amount = this.umap.templeteTwoPointOne.municipalUtilityService;
          }
        }
      });
      if(year !== 1){
        amount = (this.umap.templeteSeven[mtefAllocatoion] * 6) + this.umap.templeteSeven[mtefAllocatoion];
      }
    }
    this.umap.templeteSeven[_mtefAllocatoion] = amount;
    return amount;
  }

  amountRequiredMunicipalServicesStateOwnedT21(year: number){
    let amount: number = 0;
    let name = "amountRequiredMssoT21Y" + year;
    let amountRequired = "amountRequiredMssoT21Y" + (year - 1);

    if(this.umap.templeteFivePointOne){      
      if(year === 1){
        amount = (this.umap.templeteSeven.amountRequiredMssoT21Y1 * 6) + this.umap.templeteSeven.amountRequiredMssoT21Y1;
      }else{
        amount = (this.umap.templeteSeven[amountRequired] * 6) + this.umap.templeteSeven[amountRequired];
      }
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }


  shortfallMunicipalServicesStateOwnedT21 (year: number){
    let amount: number = 0;
    let name = "shortfallMssoT21Y" + year;
    let amountRequired = "amountRequiredMssoT21Y" + (year - 1);
    let mtefAllocatoion = "mtefAllocatoionMssoT21Y" + (year - 1);

    if(this.umap.templeteTwoPointOne){
      if(year === 1){
        amount = this.umap.templeteSeven.mtefAllocatoionMssoT21Y1 - this.umap.templeteSeven.amountRequiredMssoT21Y1;
      }else{
          amount = this.umap.templeteSeven[mtefAllocatoion] - this.umap.templeteSeven[amountRequired];
      }    
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }

  mtefAllocatoionMunicipalUtilityServicesLeasedInT22(year: number){
    let amount: number = 0;
    let mtefAllocatoion = "_mtefAllocatoionMuslT22Y" + (year - 1);
    let _mtefAllocatoion = "_mtefAllocatoionMuslT22Y" + year;

    if(this.umap.templeteFivePointOne){  
      if(year === 1){
        amount = (this.umap.templeteSeven.mtefAllocatoionMuslT22Y1 * 4) + this.umap.templeteSeven.mtefAllocatoionMuslT22Y1;
      }else{
        amount = (this.umap.templeteSeven[mtefAllocatoion] * 4) + this.umap.templeteSeven[mtefAllocatoion];
      }
    }
    this.umap.templeteSeven[_mtefAllocatoion] = amount;
    return amount;
  }

  amountRequiredMunicipalUtilityServicesLeasedInT22(year: number){
    let amount: number = 0;
    let name = "amountRequiredMssoT21Y" + year;
    let amountRequired = "amountRequiredMssoT21Y" + (year - 1);

    if(this.umap.templeteFivePointOne){      
      if(year === 1){
        amount = this.umap.templeteSeven.amountRequiredMssoT21Y1 - this.umap.templeteSeven.amountRequiredMssoT21Y1;
      }else{
        amount = this.umap.templeteSeven[amountRequired] - this.umap.templeteSeven[amountRequired];
      }
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }


  shortfallMunicipalUtilityServicesLeasedInT22 (year: number){
    let amount: number = 0;
    let name = "shortfallMuslT22Y" + year;
    let amountRequired = "amountRequiredMuslT22Y" + year;
    let mtefAllocatoion = "mtefAllocatoionMuslT22Y" + year;

    if(this.umap.templeteTwoPointOne){
      if(year === 1){
        amount = this.umap.templeteSeven.mtefAllocatoionMuslT22Y1 - this.umap.templeteSeven.amountRequiredMuslT22Y1;
      }else{
        amount = this.umap.templeteSeven[mtefAllocatoion] - this.umap.templeteSeven[amountRequired];
      }    
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }

  mtefAllocatoionPropertyRatesTaxesT21 (year: number){
    let amount: number = 0;
    let mtefAllocatoion = "mtefAllocatoionPrTT21Y" + (year - 1);
    let _mtefAllocatoion = "mtefAllocatoionPrTT21Y" + year;

    if(this.umap.templeteTwoPointOne){  
      this.umap.templeteTwoPointOne.forEach(property=> {
        if(property.propertyRatesTaxes){
          if(year === 1){
            amount = amount + property.propertyRatesTaxes;
          }
        }
      });
      if(year !== 1){
        amount = (this.umap.templeteSeven[mtefAllocatoion] * 6) + this.umap.templeteSeven[mtefAllocatoion];
      }
    }
    this.umap.templeteSeven[_mtefAllocatoion] = amount;
    return amount;
  }

  amountRequiredPropertyRatesTaxesT21(year: number){
    let amount: number = 0;
    let amountRequired = "amountRequiredPrTT21Y" + (year - 1);
    let _amountRequired = "amountRequiredPrTT21Y" + year;

    if(this.umap.templeteFivePointOne){  
      if(year === 1){
        amount = (this.umap.templeteSeven.mtefAllocatoionOctsY1 * 4) + this.umap.templeteSeven.mtefAllocatoionOctsY1;
      }else{
        amount = (this.umap.templeteSeven[amountRequired] * 4) + this.umap.templeteSeven[amountRequired];
      }
    }
    this.umap.templeteSeven[_amountRequired] = amount;
    return amount;
  }

  shortfallPropertyRatesTaxesT21(year: number){
    let amount: number = 0;
    let name = "shortfallPrTT21Y" + year;
    let amountRequired = "amountRequiredPrTT21Y" + year;
    let mtefAllocatoion = "mtefAllocatoionPrTT21Y" + year;

    if(this.umap.templeteFivePointOne){      
      if(year === 1){
        amount = this.umap.templeteSeven.mtefAllocatoionPrTT21Y1 - this.umap.templeteSeven.amountRequiredPrTT21Y1;
      }else{
        amount = this.umap.templeteSeven[mtefAllocatoion] - this.umap.templeteSeven[amountRequired];
      }
    }
    this.umap.templeteSeven[name] = amount;
    return amount;
  }

  mtefAllocatoionMaintenanceRequirementsRepairsT52(year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredMaintenanceRequirementsRepairsT52(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallMaintenanceRequirementsRepairsT52(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionTotalCurrentCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredTotalCurrentCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallTotalCurrentCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionTotalCapitalWorksRecurrentCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredTotalCapitalWorksRecurrentCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallTotalCapitalWorksRecurrentCosts(year: number){
    let amount: number = 0;
    return amount;
  }

  mtefAllocatoionTotalShortfall (year: number){
    let amount: number = 0;
    return amount;
  }

  amountRequiredTotalShortfall(year: number){
    let amount: number = 0;
    return amount;
  }

  shortfallTotalShortfall(year: number){
    let amount: number = 0;
    return amount;
  }


  
}
