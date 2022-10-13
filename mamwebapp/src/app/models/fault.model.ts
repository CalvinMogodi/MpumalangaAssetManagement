import { FaultNote } from "./fault-note.model";

export class Fault {
    id: number;
    facilityId: number;
    facilityName: string;
    propertyDescription: string;
    incidentDescription: string;
    contactName: string;
    contactNumber: string;
    createdDate: Date;
    modifiedDate?: Date;
    referenceNo: string;
    hasCompletionCertificate: boolean;
    hasContractInvoice: boolean;
    completionCertificateUrl?: string;
    contractInvoiceUrl?: string;
    supplierId?: number;
    projectId?: number;
    faultNotes: Array<FaultNote>;
    status: string;
    isDeleted: boolean;
}
