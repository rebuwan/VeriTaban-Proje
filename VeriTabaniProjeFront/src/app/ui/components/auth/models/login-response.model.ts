import { DepartmentDtoModel } from "./department-dto.model";

export class LoginResponseModel{
    token: string = '';

    staffId_StudentId: string;
    userId: string;

    userCode: string;
    userPhoto: string;

    nameLastName: string;

    department: DepartmentDtoModel = new DepartmentDtoModel(); 
}
