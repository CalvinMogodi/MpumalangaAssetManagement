export class AcquisitionPlan {
    Id: Number;
    userImmovableAssetManagementPlanId: Number;
    templeteNumber: Number;
    region: String;
    town: String;
    serviceDescription: String;
    budgetType: String;
    extent?: Number;
    initialNeedYear: Number;
    acquisitionType: String;
    status: String;
    totalAmountRequired: Number;
    cashFlowYear1?: Number;
    cashFlowYear2?: Number;
    cashFlowYear3?: Number;
    cashFlowYear4?: Number;
}