export class OperationPlan {
    id: Number;
    userImmovableAssetManagementPlanId: Number;
    templeteNumber: Number;
    districtRegion: String;
    town: String;
    serviceDescription: String;
    budgetType: String;
    localMunicipality: String;
    assetDescription: String;
    repairDescription: String;
    prioityServiceReanking: String;
    initialNeedYearObj: any;
    prioityServiceReankingObj: any;
    streetDescription: String;
    propertyDescription: String;
    leaseType: String;
    noofParkingBays?: Number;
    usableSpace?: Number;
    constructionArea?: Number;
    extentofLand?: Number;
    leaseStartDate? : Date;
    leaseEndDate?: Date
    rentalPM?: Number;
    rentalPA?: Number;
    initialNeedYear?: Number;
    status: String;
    totalAmountRequired?: Number;
    cashFlowYear1?: Number;
    cashFlowYear2?: Number;
    cashFlowYear3?: Number;
    cashFlowYear4?: Number;
    cashFlowYear5?: Number;
    comment: String;
}