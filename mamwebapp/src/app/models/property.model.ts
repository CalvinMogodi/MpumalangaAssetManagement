import { MunicipalUtilityService } from "./municipal-utility-service.model";

export class Property{
    id: number;
    userImmovableAssetManagementPlanId: number;
    fileReferenceNo: string;
    serialNo: string;
    districts: string;
    town: string;
    localMunicipality: string;
    localAuthority: string;
    assetDescription: string;
    oldStreetAddress: string;
    currentStreetAddress: string;
    propertyDescription: string;
    assetType: string;
    noofParkingBays?: number;
    noofParkingBaysAllocated?: number;
    usableAllocatedSpace?: number;
    lettableSpace?: number;
    extentofLand?: number;
    rentalPM?: number;
    rentalPA?: number;
    municipalUtilityServices: Array<MunicipalUtilityService>
    MunicipalUtilityServiceTotal?: Number;
    propertyRatesTaxes?: Number;
    operationalCosts?: Number;
    requiredPerformanceStandard: string;
    accessibility: string;
    conditionRating: string;
    suitabilityIndex: string;
    operatingPerformanceIndex: string;
    functionalPerformanceIndex: string;
    leaseStartDate?: Date;
    leaseEndDate?: Date;
    leaseTerm: string;
    comment: string;
}