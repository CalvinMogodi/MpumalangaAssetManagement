export class OperationPlans {
    id: Number;
    userImmovableAssetManagementPlanId: Number;
    templeteNumber: Number;
    district: String;
    town: String;
    serviceDescription: String;
    budgetType: String;
    localMunicipality: String;
    assetDescription: String;
    repairDescription: String;
    prioityServiceReanking: String;
    streetDescription: String;
    propertyDescription: String;
    leaseType: String;
    noofParkingBays: String;
    usableSpace?: Number;
    constructionArea?: Number;
    extentofLand?: Number;
    leaseStartDate? : Date;
    leaseStartEnd?: Date
    rentalPM?: Number;
    rentalPA?: Number;
    initialNeedYear: String;
    status: String;
    totalAmountRequired: String;
    cashFlowYear1?: Number;
    cashFlowYear2?: Number;
    cashFlowYear3?: Number;
    cashFlowYear4?: Number;
    cashFlowYear5?: Number;
}