export class SurrenderPlan{
    id: number;
    userImmovableAssetManagementPlanId: Number;
    strategicAssessmentId?: number;
    propertyId?: number;
    district: String;
    town: String;
    localMunicipality: String;
    currentStreetAddress: String;
    assetType: String;      
    propertyDescription: String;
    allocatedLettableSpace?: Number;
    extentofLand?: Number;
    surrenderRationale: String;
    proposedHandOverDate?: Date;
    contractualObligations: String;
    relinquish: boolean;
}