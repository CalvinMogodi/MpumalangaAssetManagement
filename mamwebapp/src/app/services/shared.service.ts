import { Injectable } from '@angular/core';

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

  getRandomNumber(length) {
    var result = '';
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
}