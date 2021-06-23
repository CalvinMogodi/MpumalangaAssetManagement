export class SurrenderPlan{
    id: number;
    userImmovableAssetManagementPlanId: Number;
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
}