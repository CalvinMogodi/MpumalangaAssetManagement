import { User } from "./user.model";

export class HiredProperty {
    id: number
    type: string;
    district: string;
    propertyCode: string;
    buildingCondition: string;
    startingDate: Date;
    terminationDate: Date;
    monthlyRental: number;   
    town: string;
    status: string;
    userDepartment: string;
    landlandAgentName: string;
    numberofStuff: number;
    escalationRate: number;
    area: number;
    address: string;
    createdByUser: User;
    createdUserId: number;
    createdDate: Date;
    modifiedByUser?: User;
    modifiedUserId?: number;
    modifiedDate?: Date;
}