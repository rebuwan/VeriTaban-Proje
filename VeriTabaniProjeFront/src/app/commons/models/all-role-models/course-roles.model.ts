export class CourseRolesModel{
    hasReadPermission: boolean = false;
    hasCreatePermission: boolean = false;
    hasUpdatePermission: boolean = false;
    hasDeletePermission: boolean = false;
    hasDetailBtnPermission: boolean = false;
    hasIsActiveBtnPermission: boolean = false;
}

export class CourseRoleCodesAndNamesModel{
    CourseReadCode = "Course.Get";
    CourseReadName = "Ders Okuma";

    CourseCreateCode = "Course.Create";
    CourseCreateName = "Ders Kayıt";

    CourseDeleteCode = "Course.Delete";
    CourseDeleteName = "Ders Silme";

    CourseUpdateCode = "Course.Update";
    CourseUpdateName = "Ders Güncelleme";

    CourseDetailCode = "Course.Detail";
    CourseDetailName = "Ders Detay";

    CourseIsActiveCode = "Course.IsActive";
    CourseIsActiveName = "Ders Aktiflik Durumunu Değiştirme";
}