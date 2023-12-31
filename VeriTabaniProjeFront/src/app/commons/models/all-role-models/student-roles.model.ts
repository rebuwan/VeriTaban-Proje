export class StudentRolesModel{
    hasReadPermission: boolean = false;
    hasCreatePermission: boolean = false;
    hasUpdatePermission: boolean = false;
    hasDeletePermission: boolean = false;
    hasDetailBtnPermission: boolean = false;
    hasIsActiveBtnPermission: boolean = false;
}

export class StudentRoleCodesAndNamesModel{
    StudentReadCode = "Student.Get";
    StudentReadName = "Öğrenci Okuma";

    StudentCreateCode = "Student.Create";
    StudentCreateName = "Öğrenci Kayıt";

    StudentDeleteCode = "Student.Delete";
    StudentDeleteName = "Öğrenci Silme";

    StudentUpdateCode = "Student.Update";
    StudentUpdateName = "Öğrenci Güncelleme";

    StudentDetailCode = "Student.Detail";
    StudentDetailName = "Öğrenci Detay";

    StudentIsActiveCode = "Student.IsActive";
    StudentIsActiveName = "Öğrenci Aktiflik Durumunu Değiştirme";
}