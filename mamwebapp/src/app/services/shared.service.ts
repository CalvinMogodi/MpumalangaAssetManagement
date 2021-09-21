import { Injectable } from '@angular/core';
import { currentId } from 'async_hooks';
import { MtefBudgetPeriod } from '../models/mtef-budget-period.model';
import { UAMP } from '../models/uamp.model';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  getDepartmentCode(department: string): string {
    let code = '';
    switch (department) {
      case "Agriculture, rural development, land & environmental affairs":
        code = 'ARALEA';
        break;
      case "Economic development & tourism":
        code = 'EDT';
        break;
      case "Co-operative governance & traditional affairs":
        code = 'EDT';
        break;
      case "Co-operative governance & traditional affairs":
        code = 'CGTA';
        break;
      case "Community safety, security & liason":
        code = 'CSSL';
        break;
      case "Culture, sport & recreation":
        code = 'CSR';
        break;
      case "Education":
        code = 'E';
        break;
      case "Provincial treasury":
        code = 'PT';
        break;
      case "Health":
        code = 'H';
        break;
      case "Human settlements":
        code = 'HS';
        break;
      case "Social development":
        code = 'SD';
        break;
      case "Public works, roads & transport":
        code = 'PWRT';
        break;
    }
    return code;
  }

  getRandomString(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  getRandomNumber(length): number {
    var result;
    var characters = '0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  getLocalMunicipalities(value) {
    let localMunicipalities = [];
    switch (value) {
      case 1: localMunicipalities = [
        { name: 'Bushbuckridge', code: 'B', factor: 1 },
        { name: 'Mbombela', code: 'M', factor: 2 },
        { name: 'Nkomazi', code: 'N', factor: 3 },
        { name: 'Thaba Chweu', code: 'TC', factor: 4 },
      ];
        break;
      case 2: localMunicipalities = [
        { name: 'Albert Luthuli', code: 'AL', factor: 1 },
        { name: 'Dipaleseng', code: 'D', factor: 2 },
        { name: 'Govan Mbeki', code: 'GM', factor: 3 },
        { name: 'Lekwa', code: 'L', factor: 7 },
        { name: 'Mkhondo', code: 'M', factor: 4 },
        { name: 'Msukaligwa', code: 'MS', factor: 5 },
        { name: 'Mkhondo', code: 'MK', factor: 6 },
        { name: 'Pixley Ka Seme', code: 'PKS', factor: 8 },
      ];
        break;
      case 3: localMunicipalities = [
        { name: 'Dr. J.S. Moroka', code: 'JSM', factor: 1 },
        { name: 'eMalahleni', code: 'M', factor: 2 },
        { name: 'eMakhazeni', code: 'MK', factor: 3 },
        { name: 'Msukaligwa', code: 'MS', factor: 4 },
        { name: 'Steve Tshwete', code: 'ST', factor: 5 },
        { name: 'Thembisile Hani', code: 'TH', factor: 6 },
        { name: 'Victor Khanye', code: 'VK', factor: 7 },
      ];
        break;
      default:
        localMunicipalities = [
          { name: 'Bushbuckridge', code: 'B', factor: 1 },
          { name: 'Thaba Chweu', code: 'TC', factor: 2 },
        ];
    }
    return localMunicipalities;
  }

  getInitialNeedYears() {
    let initialNeedYears = [
      { name: '2005', code: '5', factor: 1 },
      { name: '2006', code: '6', factor: 2 },
      { name: '2007', code: '7', factor: 3 },
      { name: '2008', code: '8', factor: 4 },
      { name: '2009', code: '9', factor: 5 },
      { name: '2010', code: '10', factor: 6 },
      { name: '2011', code: '11', factor: 7 },
      { name: '2012', code: '12', factor: 8 },
      { name: '2013', code: '13', factor: 9 },
      { name: '2014', code: '14', factor: 10 },
      { name: '2015', code: '15', factor: 11 },
      { name: '2016', code: '16', factor: 12 },
      { name: '2017', code: '17', factor: 13 },
      { name: '2018', code: '18', factor: 14 },
      { name: '2019', code: '19', factor: 15 },
      { name: '2020', code: '20', factor: 16 },
      { name: '2021', code: '21', factor: 17 },
    ];
    return initialNeedYears
  }

  getRegions() {
    let regions = [
      { name: 'Ehlanzeni ', code: 'U', factor: 1 },
      { name: 'Gert Sibande', code: 'R', factor: 2 },
      { name: 'Nkangala', code: 'U', factor: 3 }
    ];
    return regions;
  }

  getPrioities() {
    let prioities = [
      { name: 'Extremely Critical 1', code: 'C1', factor: 1 },
      { name: '2', code: 'C2', factor: 2 },
      { name: '3', code: 'C3', factor: 3 },
      { name: '4', code: 'C4', factor: 4 },
      { name: '5', code: 'C5', factor: 5 },
      { name: '6', code: 'C2', factor: 6 },
      { name: '7', code: 'C3', factor: 7 },
      { name: '8', code: 'C4', factor: 8 },
      { name: '9', code: 'C5', factor: 9 },
      { name: 'Defer 10', code: 'C5', factor: 10 },
    ];

    return prioities;
  }

  getLeaseTypes() {
    const leaseTypes = [
      { name: 'Land', code: 'L', factor: 1 },
      { name: 'Office', code: 'O', factor: 2 },
      { name: 'Residential', code: 'R', factor: 3 },
      { name: 'Packing', code: 'P', factor: 4 },
    ];

    return leaseTypes;
  }

  getAssetTypes() {
    const assetTypes = [
      { name: 'Erf', code: 'E', factor: 1 },
      { name: 'Farm', code: 'F', factor: 2 },
      { name: 'Agricultural Holding', code: 'A', factor: 3 },
      { name: 'Sectional Title', code: 'S', factor: 4 }
    ];
    return assetTypes;
  }

  getOperationTypes() {
    const operationTypes = [
      { name: 'Purchase ', code: 'P', factor: 1 },
      { name: 'Construction', code: 'C', factor: 2 }
    ];
    return operationTypes;
  }

  getStatuses() {
    const statuses = [
      { name: 'Planning ', code: 'PL', factor: 1 },
      { name: 'Procurement', code: 'PR', factor: 2 },
      { name: 'Construction', code: 'CO', factor: 3 }
    ];
    return statuses;
  }

  getAcquisitionTypes() {
    const acquisitionTypes = [
      { name: 'Construction', code: 'C', factor: 1 },
      { name: 'Donation', code: 'D', factor: 2 },
      {
        name: 'Purchase ', code: 'P', factor: 3
      }
    ];
    return acquisitionTypes;
  }

  getMunicipalUtilityServices() {
    const municipalUtilityServices = [
      { name: 'Electricity', code: 'E', factor: 1 },
      { name: 'Water', code: 'W', factor: 2 },
      { name: 'Sewer & Refuse', code: 'SR', factor: 3 }];
    return municipalUtilityServices;
  }

  getOperationalCosts() {
    const operationalCosts = [
      { name: 'Security', code: 'S', factor: 1 },
      { name: 'Telephone', code: 'T', factor: 2 },
      { name: 'Gardening', code: 'G', factor: 3 },
      { name: 'Cleaning', code: 'C', factor: 4 }
    ];
    return operationalCosts;
  }

  getConditionRatings() {
    const conditionRatings = [
      { name: 'C1 (Excellent)', code: 'C1', factor: 1 },
      { name: 'C2 (Good)', code: 'C2', factor: 2 },
      { name: 'C3 (Fair)', code: 'C3', factor: 3 },
      { name: 'C4 (Poor)', code: 'C4', factor: 4 },
      { name: 'C5 (Very Poor)', code: 'C5', factor: 5 },
    ];

    return conditionRatings;
  }

  getFunctionalPerformanceIndexs() {
    const functionalPerformanceIndexs = [
      { name: 'B1', code: 'B1', factor: 1 },
      { name: 'B2', code: 'B2', factor: 2 },
      { name: 'B3', code: 'B3', factor: 3 }
    ];
    return functionalPerformanceIndexs;
  }

  getOperatingPerformanceIndexs() {
    const operatingPerformanceIndexs = [
      { name: '1', code: '1', factor: 1 },
      { name: '2', code: '2', factor: 2 },
      { name: '3', code: '3', factor: 3 }
    ];
    return operatingPerformanceIndexs;
  }

  getsuitabilityIndexs() {
    const suitabilityIndexs = [
      { name: 'A', code: 'A', factor: 1 },
      { name: 'B', code: 'B', factor: 2 },
      { name: 'C', code: 'C', factor: 3 }
    ];

    return suitabilityIndexs;
  }

  getAccessibilities() {
    const accessibilities = [
      { name: 'A1', code: 'A1', factor: 1 },
      { name: 'A2', code: 'A2', factor: 2 },
      { name: 'A3', code: 'A3', factor: 3 }
    ];
    return accessibilities;
  }

  getRequiredPerformanceStandards() {
    const requiredPerformanceStandards = [
      { name: 'P1', code: 'P1', factor: 1 },
      { name: 'P2', code: 'P2', factor: 2 },
      { name: 'P3', code: 'P3', factor: 3 }
    ];
    return requiredPerformanceStandards;
  }

  calculateBudgetPeriods(uamp: UAMP): UAMP{ 
    uamp.templeteSeven.mtefBudgetPeriods.forEach(element => {
      switch(element.title){
        case "New Capital Works T4.1":
          const acquisitionPlansT41 = uamp.templeteFourPointOne.acquisitionPlans.filter(r => r.totalAmountRequired != undefined
            || r.totalAmountRequired != null);
          const year1RequiredBudgetT41 = acquisitionPlansT41.length > 0 ? acquisitionPlansT41.map(r => r.totalAmountRequired).reduce(function( a, b)
          {
            return a + b;
          }) : 0;
          element = this.calculateMtefBudgetPeriod(year1RequiredBudgetT41, element);
          const index = uamp.templeteSeven.mtefBudgetPeriods.findIndex(b => b.title == element.title);
          uamp.templeteSeven.mtefBudgetPeriods[index] = element;
          break;
        case "Refurb., Re-config.& Additions) T5.1" :
          const acquisitionPlansT51 = uamp.templeteFivePointOne.operationPlans.filter(r => r.totalAmountRequired != undefined
            || r.totalAmountRequired != null);
          const year1RequiredBudgetT51 = acquisitionPlansT51.length > 0 ? acquisitionPlansT51.map(r => r.totalAmountRequired).reduce(function( a, b)
          {
            return a + b;
          }) : 0;
          element = this.calculateMtefBudgetPeriod(year1RequiredBudgetT51, element);
          const indexT5 = uamp.templeteSeven.mtefBudgetPeriods.findIndex(b => b.title == element.title);
          uamp.templeteSeven.mtefBudgetPeriods[indexT5] = element;
          break;
        case "Total Capital Costs" :          
          element = this.calculateTotalCapitalCosts(uamp.templeteSeven.mtefBudgetPeriods, element);
          const indexTT = uamp.templeteSeven.mtefBudgetPeriods.findIndex(b => b.title == element.title);
          uamp.templeteSeven.mtefBudgetPeriods[indexTT] = element;
          break;
        case "% Shortfall" :  
        if(element.group == 'Capital Projects') { 
          element = this.calculateShortfallCapitalCosts(uamp.templeteSeven.mtefBudgetPeriods, element);
          const indexs = uamp.templeteSeven.mtefBudgetPeriods.findIndex(b => b.title == element.title);
          uamp.templeteSeven.mtefBudgetPeriods[indexs] = element;
        }
          break;
      }
    });

    return uamp;
  }

  calculateMtefBudgetPeriod(year1RequiredBudget: number, mtefBudgetPeriod: MtefBudgetPeriod): MtefBudgetPeriod{
    
    const year2Allocation = (6 / 100 * year1RequiredBudget) + year1RequiredBudget;
    const year2RequiredBudget = (4 / 100 * year2Allocation) + year2Allocation;

    const year3Allocation = (6 / 100 * year2RequiredBudget) + year2RequiredBudget;
    const year3RequiredBudget = (4 / 100 * year2Allocation) + year2Allocation;

    const year4Allocation = (6 / 100 * year3RequiredBudget) + year3RequiredBudget;
    const year4RequiredBudget = (4 / 100 * year3Allocation) + year3Allocation;

    const year5Allocation = (6 / 100 * year4RequiredBudget) + year4RequiredBudget;
    const year5RequiredBudget = (4 / 100 * year4Allocation) + year4Allocation;

    var _mtefBudgetPeriod: MtefBudgetPeriod = {
      id: mtefBudgetPeriod.id,
      userImmovableAssetManagementPlanId: mtefBudgetPeriod.userImmovableAssetManagementPlanId,
      order: mtefBudgetPeriod.order,
      isHeader: mtefBudgetPeriod.isHeader,
      isPercentage: mtefBudgetPeriod.isPercentage,
      title: mtefBudgetPeriod.title,
      group: mtefBudgetPeriod.group,
      year1Allocation: mtefBudgetPeriod.year1Allocation == undefined ? 0 : mtefBudgetPeriod.year1Allocation,
      year1RequiredBudget: year1RequiredBudget,
      year1Shortfall: mtefBudgetPeriod.year1Allocation - year1RequiredBudget,
      year2Allocation: year2Allocation,
      year2RequiredBudget: year2RequiredBudget,
      year2Shortfall: year2Allocation - year2RequiredBudget,
      year3Allocation: year3Allocation,
      year3RequiredBudget: year3RequiredBudget,
      year3Shortfall: year3Allocation - year3RequiredBudget,
      year4Allocation: year4Allocation,
      year4RequiredBudget: year4RequiredBudget,
      year4Shortfall: year4Allocation - year4RequiredBudget,
      year5Allocation: year5Allocation,
      year5RequiredBudget: year5RequiredBudget,
      year5Shortfall: year5Allocation - year5RequiredBudget,
    }
    return _mtefBudgetPeriod;
  }  

  calculateTotalCapitalCosts(mtefBudgetPeriods: MtefBudgetPeriod[], mtefBudgetPeriod: MtefBudgetPeriod): MtefBudgetPeriod{
    const _mtefBudgetPeriods =  mtefBudgetPeriods.filter(m => m.group == 'Capital Projects' 
                                && !m.title.includes('Total') 
                                && !m.title.includes('Shortfall') );  
    var _mtefBudgetPeriod: MtefBudgetPeriod = {
      id: mtefBudgetPeriod.id,
      userImmovableAssetManagementPlanId: mtefBudgetPeriod.userImmovableAssetManagementPlanId,
      order: mtefBudgetPeriod.order,
      isHeader: mtefBudgetPeriod.isHeader,
      isPercentage: mtefBudgetPeriod.isPercentage,
      title: mtefBudgetPeriod.title,
      group: mtefBudgetPeriod.group,
      year1Allocation: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year1Allocation).reduce(function( a, b) {return a + b;}) : 0,
      year1RequiredBudget: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year1RequiredBudget).reduce(function( a, b) {return a + b;}) : 0,
      year1Shortfall: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year1Shortfall).reduce(function( a, b) {return a + b;}) : 0,
      year2Allocation: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year2Allocation).reduce(function( a, b) {return a + b;}) : 0,
      year2RequiredBudget: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year2RequiredBudget).reduce(function( a, b) {return a + b;}) : 0,
      year2Shortfall: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year2Shortfall).reduce(function( a, b) {return a + b;}) : 0,
      year3Allocation: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year3Allocation).reduce(function( a, b) {return a + b;}) : 0,
      year3RequiredBudget: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year3RequiredBudget).reduce(function( a, b) {return a + b;}) : 0,
      year3Shortfall: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year3Shortfall).reduce(function( a, b) {return a + b;}) : 0,
      year4Allocation: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year4Allocation).reduce(function( a, b) {return a + b;}) : 0,
      year4RequiredBudget: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year4RequiredBudget).reduce(function( a, b) {return a + b;}) : 0,
      year4Shortfall: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year4Shortfall).reduce(function( a, b) {return a + b;}) : 0,
      year5Allocation: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year5Allocation).reduce(function( a, b) {return a + b;}) : 0,
      year5RequiredBudget: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year5RequiredBudget).reduce(function( a, b) {return a + b;}) : 0,
      year5Shortfall: _mtefBudgetPeriods.length > 0 ? _mtefBudgetPeriods.map(r => r.year5Shortfall).reduce(function( a, b) {return a + b;}) : 0,
    }
    return _mtefBudgetPeriod;
  }

  calculateShortfallCapitalCosts(mtefBudgetPeriods: MtefBudgetPeriod[], mtefBudgetPeriod: MtefBudgetPeriod): MtefBudgetPeriod{
    const _totalMtefBudgetPeriod =  mtefBudgetPeriods.filter(m => m.group == 'Capital Projects' 
                                && m.title.includes('Shortfall'))[0];  
    var _mtefBudgetPeriod: MtefBudgetPeriod = {
      id: mtefBudgetPeriod.id,
      userImmovableAssetManagementPlanId: mtefBudgetPeriod.userImmovableAssetManagementPlanId,
      order: mtefBudgetPeriod.order,
      isHeader: mtefBudgetPeriod.isHeader,
      isPercentage: mtefBudgetPeriod.isPercentage,
      title: mtefBudgetPeriod.title,
      group: mtefBudgetPeriod.group,
      year1Allocation: 0,
      year1RequiredBudget: 0,
      year1Shortfall: Number(_totalMtefBudgetPeriod.year1Shortfall / _totalMtefBudgetPeriod.year1Allocation),
      year2Allocation:0,
      year2RequiredBudget: 0,
      year2Shortfall: Number(_totalMtefBudgetPeriod.year2Shortfall / _totalMtefBudgetPeriod.year2Allocation),
      year3Allocation: 0,
      year3RequiredBudget: 0,
      year3Shortfall: Number(_totalMtefBudgetPeriod.year3Shortfall / _totalMtefBudgetPeriod.year3Allocation),
      year4Allocation: 0,
      year4RequiredBudget: 0,
      year4Shortfall: Number(_totalMtefBudgetPeriod.year4Shortfall / _totalMtefBudgetPeriod.year4Allocation),
      year5Allocation: 0,
      year5RequiredBudget: 0,
      year5Shortfall: Number(_totalMtefBudgetPeriod.year5Shortfall / _totalMtefBudgetPeriod.year5Allocation),
    }
    return _mtefBudgetPeriod;
  }
}