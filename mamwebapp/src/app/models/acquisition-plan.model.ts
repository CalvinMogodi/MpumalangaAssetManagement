export class AcquisitionPlan {
    id: Number;
    userImmovableAssetManagementPlanId: Number;
    templeteNumber: Number;
    districtRegion: String;
    town: String;
    serviceDescription: String;
    budgetType: String;
    extent?: Number;
    initialNeedYear?: Number;
    acquisitionType: String;
    status: String;
    totalAmountRequired: Number;
    cashFlowYear1?: Number;
    cashFlowYear2?: Number;
    cashFlowYear3?: Number;
    cashFlowYear4?: Number;
}