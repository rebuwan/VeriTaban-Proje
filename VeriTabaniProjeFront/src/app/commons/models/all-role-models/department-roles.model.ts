export class DepartmentRolesModel{
    hasReadPermission: boolean = false;
    hasCreatePermission: boolean = false;
    hasUpdatePermission: boolean = false;
    hasDeletePermission: boolean = false;
}

export class DepartmentRoleCodesAndNamesModel{
    DepartmentReadCode = "Department.Get";
    DepartmentReadName = "Ders Okuma";

    DepartmentCreateCode = "Department.Create";
    DepartmentCreateName = "Ders Kayıt";

    DepartmentDeleteCode = "Department.Delete";
    DepartmentDeleteName = "Ders Silme";

    DepartmentUpdateCode = "Department.Update";
    DepartmentUpdateName = "Ders Güncelleme";
}