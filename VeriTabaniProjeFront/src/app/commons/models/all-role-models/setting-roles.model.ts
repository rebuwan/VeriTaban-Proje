export class SettingRolesModel{
    hasRoleReadPermision: boolean = false;
    hasUserReadPermission: boolean = false;

    hasRoleCreatePermission: boolean = false;
    hasRoleUpdatePermission: boolean = false;
    hasRoleDeletePermission: boolean = false;
    
    hasUserAssignRolePermission: boolean = false;
    hasMainRoleAssignRolePermission: boolean = false;
}

export class SettingRoleCodesAndNamesModel{
    SettingRoleReadCode = "Setting.RoleGet";
    SettingRoleReadName = "Ana Rolleri Görme";

    SettingUserReadCode = "Setting.UserGet";
    SettingUserReadName = "Kullanıcıları Görme";

    SettingMainRoleCreateCode = "Setting.Create";
    SettingMainRoleCreateName = "Ana Rol Kayıt";

    SettingMainRoleDeleteCode = "Setting.Delete";
    SettingMainRoleDeleteName = "Ana Rol Silme";

    SettingMainRoleUpdateCode = "Setting.Update";
    SettingMainRoleUpdateName = "Ana Rol Güncelleme";

    SettingUserAssignRoleCode = "Setting.UserAssingRole";
    SettingUserAssignRoleName = "Kullanıcıya Ana Rol Ata";

    SettingMainRoleAssignRoleCode = "Setting.MainRoleAssingRole";
    SettingMainRoleAssignRoleName = "Ana Role Rol Ata";
}