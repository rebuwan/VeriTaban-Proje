
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Roles;
public sealed class RoleList
{
    public static List<Role> GetStaticRoles()
    {
        List<Role> roles = new List<Role>();

        #region StudentRoles
        roles.Add(new Role(
            title: Students,
            code: StudentReadCode,
            name: StudentReadName));

        roles.Add(new Role(
            title: Students,
            code: StudentCreateCode,
            name: StudentCreateName));

        roles.Add(new Role(
            title: Students,
            code: StudentDeleteCode,
            name: StudentDeleteName));

        roles.Add(new Role(
            title: Students,
            code: StudentUpdateCode,
            name: StudentUpdateName));

        roles.Add(new Role(
            title: Students,
            code: StudentDetailCode,
            name: StudentDetailName));

        roles.Add(new Role(
            title: Students,
            code: StudentIsActiveCode,
            name: StudentIsActiveName));
        #endregion

        #region StaffRoles
        roles.Add(new Role(
            title: Staffs,
            code: StaffReadCode,
            name: StaffReadName));

        roles.Add(new Role(
            title: Staffs,
            code: StaffCreateCode,
            name: StaffCreateName));

        roles.Add(new Role(
            title: Staffs,
            code: StaffDeleteCode,
            name: StaffDeleteName));

        roles.Add(new Role(
            title: Staffs,
            code: StaffUpdateCode,
            name: StaffUpdateName));

        roles.Add(new Role(
            title: Staffs,
            code: StaffDetailCode,
            name: StaffDetailName));

        roles.Add(new Role(
            title: Staffs,
            code: StaffIsActiveCode,
            name: StaffIsActiveName));
        #endregion

        #region DepartmentRoles
        roles.Add(new Role(
            title: Departments,
            code: DepartmentReadCode,
            name: DepartmentReadName));

        roles.Add(new Role(
            title: Departments,
            code: DepartmentCreateCode,
            name: DepartmentCreateName));

        roles.Add(new Role(
            title: Departments,
            code: DepartmentDeleteCode,
            name: DepartmentDeleteName));

        roles.Add(new Role(
            title: Departments,
            code: DepartmentUpdateCode,
            name: DepartmentUpdateName));
        #endregion

        #region SettingRoles
        roles.Add(new Role(
            title: Settings,
            code: SettingRoleReadCode,
            name: SettingRoleReadName));

        roles.Add(new Role(
            title: Settings,
            code: SettingUserReadCode,
            name: SettingUserReadName));

        roles.Add(new Role(
            title: Settings,
            code: SettingMainRoleCreateCode,
            name: SettingMainRoleCreateName));

        roles.Add(new Role(
            title: Settings,
            code: SettingMainRoleDeleteCode,
            name: SettingMainRoleDeleteName));

        roles.Add(new Role(
            title: Settings,
            code: SettingMainRoleUpdateCode,
            name: SettingMainRoleUpdateName));

        roles.Add(new Role(
            title: Settings,
            code: SettingUserAssignRoleCode,
            name: SettingUserAssignRoleName));

        roles.Add(new Role(
            title: Settings,
            code: SettingMainRoleAssignRoleCode,
            name: SettingMainRoleAssignRoleName));
        #endregion

        #region CourseRoles
        roles.Add(new Role(
            title: Courses,
            code: CourseReadCode,
            name: CourseReadName));

        roles.Add(new Role(
            title: Courses,
            code: CourseCreateCode,
            name: CourseCreateName));

        roles.Add(new Role(
            title: Courses,
            code: CourseDeleteCode,
            name: CourseDeleteName));

        roles.Add(new Role(
            title: Courses,
            code: CourseUpdateCode,
            name: CourseUpdateName));

        roles.Add(new Role(
            title: Courses,
            code: CourseDetailCode,
            name: CourseDetailName));

        roles.Add(new Role(
            title: Courses,
            code: CourseIsActiveCode,
            name: CourseIsActiveName));
        #endregion

        #region StudentCourseRLRoles
        roles.Add(new Role(
            title: StudentCourseRL,
            code: StudentCourseReadCode,
            name: StudentCourseReadName));
        #endregion

        #region StaffCourseRLRoles
        roles.Add(new Role(
            title: StaffCourseRL,
            code: StaffCourseReadCode,
            name: StaffCourseReadName));
        #endregion

        return roles;
    }

    public static List<MainRole> GetStaticMainRoles()
    {
        List<MainRole> mainRoles = new List<MainRole>
        {
            new MainRole( title: "Bölüm Başkanı" ),
            new MainRole( title: "Öğretim Üyesi" ),
            new MainRole( title: "Öğrenci" ),
            new MainRole( title: "Danışman" ),
            new MainRole( title: "Developer" )
        };

        return mainRoles;
    }

    #region StudentFeatures
    #region RoleTitleName
    public static string Students = "Öğrenciler";
    #endregion

    #region RoleCodesAndNames
    public static string StudentReadCode = "Student.Get";
    public static string StudentReadName = "Öğrenci Okuma";

    public static string StudentCreateCode = "Student.Create";
    public static string StudentCreateName = "Öğrenci Kayıt";

    public static string StudentDeleteCode = "Student.Delete";
    public static string StudentDeleteName = "Öğrenci Silme";

    public static string StudentUpdateCode = "Student.Update";
    public static string StudentUpdateName = "Öğrenci Güncelleme";

    public static string StudentDetailCode = "Student.Detail";
    public static string StudentDetailName = "Öğrenci Detay";

    public static string StudentIsActiveCode = "Student.IsActive";
    public static string StudentIsActiveName = "Öğrenci Aktiflik Durumunu Değiştirme";

    #endregion
    #endregion

    #region StaffFeatures
    #region RoleTitleName
    public static string Staffs = "Personeller";
    #endregion

    #region RoleCodesAndNames
    public static string StaffReadCode = "Staff.Get";
    public static string StaffReadName = "Personel Okuma";

    public static string StaffCreateCode = "Staff.Create";
    public static string StaffCreateName = "Personel Kayıt";

    public static string StaffDeleteCode = "Staff.Delete";
    public static string StaffDeleteName = "Personel Silme";

    public static string StaffUpdateCode = "Staff.Update";
    public static string StaffUpdateName = "Personel Güncelleme";

    public static string StaffDetailCode = "Staff.Detail";
    public static string StaffDetailName = "Personel Detay";

    public static string StaffIsActiveCode = "Staff.IsActive";
    public static string StaffIsActiveName = "Personel Aktiflik Durumunu Değiştirme";
    #endregion
    #endregion

    #region DepartmentFeatures
    #region RoleTitleName
    public static string Departments = "Bölümler";
    #endregion

    #region RoleCodesAndNames
    public static string DepartmentReadCode = "Department.Get";
    public static string DepartmentReadName = "Departman Okuma";

    public static string DepartmentCreateCode = "Department.Create";
    public static string DepartmentCreateName = "Departman Kayıt";

    public static string DepartmentDeleteCode = "Department.Delete";
    public static string DepartmentDeleteName = "Departman Silme";

    public static string DepartmentUpdateCode = "Department.Update";
    public static string DepartmentUpdateName = "Departman Güncelleme";
    #endregion
    #endregion

    #region SettingFeatures
    #region RoleTitleName
    public static string Settings = "Ayarlar";
    #endregion

    #region RoleCodesAndNames
    public static string SettingRoleReadCode = "Setting.RoleGet";
    public static string SettingRoleReadName = "Ana Rolleri Görme";

    public static string SettingUserReadCode = "Setting.UserGet";
    public static string SettingUserReadName = "Kullanıcıları Görme";

    public static string SettingMainRoleCreateCode = "Setting.Create";
    public static string SettingMainRoleCreateName = "Ana Rol Kayıt";

    public static string SettingMainRoleDeleteCode = "Setting.Delete";
    public static string SettingMainRoleDeleteName = "Ana Rol Silme";

    public static string SettingMainRoleUpdateCode = "Setting.Update";
    public static string SettingMainRoleUpdateName = "Ana Rol Güncelleme";

    public static string SettingUserAssignRoleCode = "Setting.UserAssingRole";
    public static string SettingUserAssignRoleName = "Kullanıcıya Ana Rol Ata";

    public static string SettingMainRoleAssignRoleCode = "Setting.MainRoleAssingRole";
    public static string SettingMainRoleAssignRoleName = "Ana Role Rol Ata";
    #endregion
    #endregion

    #region CourseFeatures
    #region RoleTitleName
    public static string Courses = "Dersler";
    #endregion

    #region RoleCodesAndNames
    public static string CourseReadCode = "Course.Get";
    public static string CourseReadName = "Ders Okuma";

    public static string CourseCreateCode = "Course.Create";
    public static string CourseCreateName = "Ders Kayıt";

    public static string CourseDeleteCode = "Course.Delete";
    public static string CourseDeleteName = "Ders Silme";

    public static string CourseUpdateCode = "Course.Update";
    public static string CourseUpdateName = "Ders Güncelleme";

    public static string CourseDetailCode = "Course.Detail";
    public static string CourseDetailName = "Ders Detay";

    public static string CourseIsActiveCode = "Course.IsActive";
    public static string CourseIsActiveName = "Ders Aktiflik Durumunu Değiştirme";
    #endregion
    #endregion

    #region StudentCourseRLFeatures
    #region RoleTitleName
    public static string StudentCourseRL = "Öğrenci - Ders İlişkisi";
    #endregion

    #region RoleCodesAndNames
    public static string StudentCourseReadCode = "Student_Course.Get";
    public static string StudentCourseReadName = "Öğrenci - Ders Sayfası";
    #endregion
    #endregion

    #region StaffCourseRLFeatures
    #region RoleTitleName
    public static string StaffCourseRL = "Öğretmen - Ders İlişkisi";
    #endregion

    #region RoleCodesAndNames
    public static string StaffCourseReadCode = "Staff_Course.Get";
    public static string StaffCourseReadName = "Öğretmen - Ders Sayfası";
    #endregion
    #endregion
}