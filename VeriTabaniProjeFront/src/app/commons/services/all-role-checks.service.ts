import { Injectable } from '@angular/core';
import { RoleService } from './role.service';
import { RoleQueryModel } from '../models/role-query.model';
import { StudentRoleCodesAndNamesModel, StudentRolesModel } from '../models/all-role-models/student-roles.model';
import { StaffRoleCodesAndNamesModel, StaffRolesModel } from '../models/all-role-models/staff-roles.model';
import { DepartmentRoleCodesAndNamesModel, DepartmentRolesModel } from '../models/all-role-models/department-roles.model';
import { SettingRoleCodesAndNamesModel, SettingRolesModel } from '../models/all-role-models/setting-roles.model';
import { SidebarRolesModel } from '../models/all-role-models/sidebar-roles.model';
import { StudentCourseRoleCodesAndNamesModel, StudentCourseRolesModel } from '../models/all-role-models/student-course-roles.model';
import { StaffCourseRoleCodesAndNamesModel, StaffCourseRolesModel } from '../models/all-role-models/staff-course-roles.model';
import { CourseRoleCodesAndNamesModel, CourseRolesModel } from '../models/all-role-models/course-roles.model';

@Injectable({
  providedIn: 'root'
})
export class AllRoleChecksService {
  model: RoleQueryModel = new RoleQueryModel();

  constructor(
    private _roleService: RoleService
  ) { }

  checkAuthorize(data: any, code: string, name: string){
    return data.userRoles.roles.findIndex(
      (p: any) => p.code === code && p.name === name
      ) > -1
      ? true
      : false;
  }

  checkRoleTitle(data: any, roleTitle: string): boolean {
    return data.userRoles.roles.findIndex(
      (p: any) => p.title === roleTitle
    ) > -1
    ? true 
    : false;
  }

  getStudentRole(studentRoles: StudentRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setStudentRole(studentRoles, res);
    });
  }

  setStudentRole(studentRoles: StudentRolesModel, data: any){
    let query: StudentRoleCodesAndNamesModel = new StudentRoleCodesAndNamesModel();

    studentRoles.hasReadPermission = this.checkAuthorize(
      data,
      query.StudentReadCode,
      query.StudentReadName
    );
    
    studentRoles.hasCreatePermission = this.checkAuthorize(
      data,
      query.StudentCreateCode,
      query.StudentCreateName
    );

    studentRoles.hasUpdatePermission = this.checkAuthorize(
      data,
      query.StudentUpdateCode,
      query.StudentUpdateName
    );

    studentRoles.hasDeletePermission = this.checkAuthorize(
      data,
      query.StudentDeleteCode,
      query.StudentDeleteName
    );

    studentRoles.hasDetailBtnPermission = this.checkAuthorize(
      data,
      query.StudentDetailCode,
      query.StudentDetailName
    );

    studentRoles.hasIsActiveBtnPermission = this.checkAuthorize(
      data,
      query.StudentIsActiveCode,
      query.StudentIsActiveName
    );
  }

  getStaffRole(staffRoles: StaffRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setStaffRole(staffRoles, res);
    });
  }

  setStaffRole(staffRoles: StaffRolesModel, data: any){
    let query: StaffRoleCodesAndNamesModel = new StaffRoleCodesAndNamesModel();

    staffRoles.hasReadPermission = this.checkAuthorize(
      data,
      query.StaffReadCode,
      query.StaffReadName
    );
    
    staffRoles.hasCreatePermission = this.checkAuthorize(
      data,
      query.StaffCreateCode,
      query.StaffCreateName
    );

    staffRoles.hasUpdatePermission = this.checkAuthorize(
      data,
      query.StaffUpdateCode,
      query.StaffUpdateName
    );

    staffRoles.hasDeletePermission = this.checkAuthorize(
      data,
      query.StaffDeleteCode,
      query.StaffDeleteName
    );

    staffRoles.hasDetailBtnPermission = this.checkAuthorize(
      data,
      query.StaffDetailCode,
      query.StaffDetailName
    );

    staffRoles.hasIsActiveBtnPermission = this.checkAuthorize(
      data,
      query.StaffIsActiveCode,
      query.StaffIsActiveName
    );
  }

  getCourseRole(courseRoles: CourseRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setCourseRole(courseRoles, res);
    });
  }

  setCourseRole(courseRoles: CourseRolesModel, data: any){
    let query: CourseRoleCodesAndNamesModel = new CourseRoleCodesAndNamesModel();

    courseRoles.hasReadPermission = this.checkAuthorize(
      data,
      query.CourseReadCode,
      query.CourseReadName
    );
    
    courseRoles.hasCreatePermission = this.checkAuthorize(
      data,
      query.CourseCreateCode,
      query.CourseCreateName
    );

    courseRoles.hasUpdatePermission = this.checkAuthorize(
      data,
      query.CourseUpdateCode,
      query.CourseUpdateName
    );

    courseRoles.hasDeletePermission = this.checkAuthorize(
      data,
      query.CourseDeleteCode,
      query.CourseDeleteName
    );

    courseRoles.hasDetailBtnPermission = this.checkAuthorize(
      data,
      query.CourseDetailCode,
      query.CourseDetailName
    );

    courseRoles.hasIsActiveBtnPermission = this.checkAuthorize(
      data,
      query.CourseIsActiveCode,
      query.CourseIsActiveName
    );
  }

  getDepartmentRole(departmentRoles: DepartmentRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setDepartmentRole(departmentRoles, res);
    });
  }

  setDepartmentRole(departmentRoles: DepartmentRolesModel, data: any){
    let query: DepartmentRoleCodesAndNamesModel = new DepartmentRoleCodesAndNamesModel();

    departmentRoles.hasReadPermission = this.checkAuthorize(
      data,
      query.DepartmentReadCode,
      query.DepartmentReadName
    );
    
    departmentRoles.hasCreatePermission = this.checkAuthorize(
      data,
      query.DepartmentCreateCode,
      query.DepartmentCreateName
    );

    departmentRoles.hasUpdatePermission = this.checkAuthorize(
      data,
      query.DepartmentUpdateCode,
      query.DepartmentUpdateName
    );

    departmentRoles.hasDeletePermission = this.checkAuthorize(
      data,
      query.DepartmentDeleteCode,
      query.DepartmentDeleteName
    );
  }

  getSettingRole(settingRoles: SettingRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setSettingRole(settingRoles, res);
    })
  }

  setSettingRole(settingRoles: SettingRolesModel, data: any){
    let query: SettingRoleCodesAndNamesModel = new SettingRoleCodesAndNamesModel();

    settingRoles.hasRoleReadPermision = this.checkAuthorize(
      data,
      query.SettingRoleReadCode,
      query.SettingRoleReadName
    );

    settingRoles.hasUserReadPermission = this.checkAuthorize(
      data,
      query.SettingUserReadCode,
      query.SettingUserReadName
    );

    settingRoles.hasRoleCreatePermission = this.checkAuthorize(
      data,
      query.SettingMainRoleCreateCode,
      query.SettingMainRoleCreateName
    );

    settingRoles.hasRoleUpdatePermission = this.checkAuthorize(
      data,
      query.SettingMainRoleUpdateCode,
      query.SettingMainRoleUpdateName
    );

    settingRoles.hasRoleDeletePermission = this.checkAuthorize(
      data,
      query.SettingMainRoleDeleteCode,
      query.SettingMainRoleDeleteName
    );

    settingRoles.hasUserAssignRolePermission = this.checkAuthorize(
      data,
      query.SettingUserAssignRoleCode,
      query.SettingUserAssignRoleName
    );

    settingRoles.hasMainRoleAssignRolePermission = this.checkAuthorize(
      data,
      query.SettingMainRoleAssignRoleCode,
      query.SettingMainRoleAssignRoleName
    );
  }

  getStudentCourseRLRole(studentCourseRLRoles: StudentCourseRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setStudentCourseRLRole(studentCourseRLRoles, res);
    });
  }

  setStudentCourseRLRole(studentCourseRLRoles: StudentCourseRolesModel, data: any){
    let query: StudentCourseRoleCodesAndNamesModel = new StudentCourseRoleCodesAndNamesModel();

    studentCourseRLRoles.hasStudentCourseRL = this.checkAuthorize(
      data,
      query.StudentCourseReadCode,
      query.StudentCourseReadName
    );
  }

  getStaffCourseRLRole(staffCourseRLRoles: StaffCourseRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setStaffCourseRLRole(staffCourseRLRoles, res);
    });
  }

  setStaffCourseRLRole(staffCourseRLRoles: StaffCourseRolesModel, data: any){
    let query: StaffCourseRoleCodesAndNamesModel = new StaffCourseRoleCodesAndNamesModel();

    staffCourseRLRoles.hasStaffCourseRL = this.checkAuthorize(
      data,
      query.StaffCourseReadCode,
      query.StaffCourseReadName
    );

    console.log(staffCourseRLRoles);
  }

  getSidebarRole(sidebarRoles: SidebarRolesModel){
    this._roleService.getUserRoles(this.model, (res) => {
      this.setSidebarRole(sidebarRoles, res);
    });
  }

  setSidebarRole(sidebarRoles: SidebarRolesModel, data: any){
    
    sidebarRoles.hasStudentPageAuthority = this.checkRoleTitle(
      data,
      "Öğrenciler"
    );

    sidebarRoles.hasStaffCoursePageAuthority = this.checkRoleTitle(
      data,
      "Öğretmen - Ders İlişkisi"
    );

    sidebarRoles.hasStudentCoursePageAuthority = this.checkRoleTitle(
      data,
      "Öğrenci - Ders İlişkisi"
    );

    sidebarRoles.hasSettingPageAuthority = this.checkRoleTitle(
      data,
      "Ayarlar"
    );

    sidebarRoles.hasCoursePageAuthority = this.checkRoleTitle(
      data,
      "Dersler"
    );

    sidebarRoles.hasStaffPageAuthority = this.checkRoleTitle(
      data,
      "Personeller"
    );
  }
}
