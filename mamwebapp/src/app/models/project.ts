import { Supplier } from "./supplier";

export class Project {
    id: number;
    orderNumber: string;
    districtId: number;
    propertyId: number;
    name: string;
    plannedDuration: string;
    startDate: Date;
    practicalCompletionDate: Date;
    scopeofWork: string;
    hasFinancials: boolean;
    hasParentProject: boolean;
    parentProjectId?: number;
    amount: number;
    account: string;
    managedBy: string;
    employeeName: string;
    employeeNumber: string;
    contactName: string;
    contactNumber: string;
    businessName: string;
    businessRegNumber: string;
    createdDate: Date;
    modifiedDate?: Date;
    suppliers: Array<Supplier>;
    isDeleted: boolean;
}
