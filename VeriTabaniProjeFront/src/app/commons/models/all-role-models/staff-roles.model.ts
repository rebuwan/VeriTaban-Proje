export class StaffRolesModel{
    hasReadPermission: boolean = false;
    hasCreatePermission: boolean = false;
    hasUpdatePermission: boolean = false;
    hasDeletePermission: boolean = false;
    hasDetailBtnPermission: boolean = false;
    hasIsActiveBtnPermission: boolean = false;
}

export class StaffRoleCodesAndNamesModel{
    StaffReadCode = "Staff.Get";
    StaffReadName = "Personel Okuma";

    StaffCreateCode = "Staff.Create";
    StaffCreateName = "Personel Kayıt";

    StaffDeleteCode = "Staff.Delete";
    StaffDeleteName = "Personel Silme";

    StaffUpdateCode = "Staff.Update";
    StaffUpdateName = "Personel Güncelleme";

    StaffDetailCode = "Staff.Detail";
    StaffDetailName = "Personel Detay";

    StaffIsActiveCode = "Staff.IsActive";
    StaffIsActiveName = "Personel Aktiflik Durumunu Değiştirme";
}