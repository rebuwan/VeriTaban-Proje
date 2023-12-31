import { StaffDtoModel } from "./staff-dto.model";

export class CourseForStaffModel{
    id: string;
    code: string;
    name: string;

    credit: number;

    isActive: boolean;

    staffs: StaffDtoModel[] = [];

    totalCount: number;
}