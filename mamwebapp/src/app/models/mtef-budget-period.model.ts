import { MtefYear } from "./mtef-year.model";

export class MtefBudgetPeriod{
    id: Number;
    userImmovableAssetManagementPlanId: Number;
    name: String;
    mtefYearOne: MtefYear;
    mtefYearTwo: MtefYear;
    mtefYearThree: MtefYear;
    mtefYearFour: MtefYear;
    mtefYearFive: MtefYear;
}