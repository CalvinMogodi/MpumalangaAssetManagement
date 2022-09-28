export class Fault {
    id: number;
    facilityId: number;
    propertyDescription: string;
    incidentDescription: string;
    contactName: string;
    contactNumber: string;
    createdDate: Date;
    modifiedDate?: Date;
    referenceNo: string;
    hasCompletionCertificate: boolean;
    hasContractInvoice: boolean;
    supplierId?: number;
    projectId?: number;
    notes: string;
    status: string;
    isDeleted: boolean;
}
