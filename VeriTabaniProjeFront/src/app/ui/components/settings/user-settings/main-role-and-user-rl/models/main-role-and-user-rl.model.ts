import { DepartmentDtoModel } from "src/app/ui/components/auth/models/department-dto.model";

export class MainRoleAndUserRLModel{
    mainRoleId: string;
    mainRoleTitle: string;
    mainRoleDepartmentId: string;

    mainRoleDepartment: DepartmentDtoModel = new DepartmentDtoModel();

    isActive: boolean;
}