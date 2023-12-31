import { Injectable } from '@angular/core';
import { GenericHttpService } from 'src/app/commons/services/generic-http.service';
import { LoginResponseService } from 'src/app/commons/services/login-response.service';
import { CourseGetAllByFilterModel } from '../models/course-get-all-by-filter.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { CourseForStaffModel } from '../models/course-for-staff.model';
import { StaffCourseRLCreateModel } from '../models/staff-course-rl-create.model';
import { MessageResponseModel } from 'src/app/commons/models/messageResponse.model';
import { GetAllCoursesByStaff } from '../models/staff-course/get-all-courses-by-staff.model';
import { CoursesByStaffModel } from '../models/staff-course/staff-course.model';
import { GetAllStudentCourseFilterModel } from '../models/get-all-student-course-filter.model';
import { GetAllStudentCourseModel } from '../models/get-all-student-course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseForStaffService {

  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) { }

  getAllByFilterCourse(model: CourseGetAllByFilterModel, callBack: (res: PaginationResultModel<CourseForStaffModel[]>) => void){
    model.departmentId = this._loginResponse.getLoginResponseModel().department.id;

    this._http.post<PaginationResultModel<CourseForStaffModel[]>>("Course/GetAllByFilter", model, res => {
      callBack(res);
    });
  }

  staffCourseRLCreate(model: StaffCourseRLCreateModel, callBack: (res: MessageResponseModel) => void){
    model.staffUserId = this._loginResponse.getLoginResponseModel().staffId_StudentId;
    this._http.post<MessageResponseModel>("StaffCourseRelationship/Create", model, res => {
      callBack(res);
    });
  }

  coursesByStaff(model: GetAllCoursesByStaff,  callBack: (res: PaginationResultModel<CoursesByStaffModel[]>) => void){
    model.staffId = this._loginResponse.getLoginResponseModel().staffId_StudentId;
    this._http.post< PaginationResultModel<CoursesByStaffModel[]>>("StaffCourseRelationship/GetAllByStaff", model, res => {
      callBack(res);
    });
  }

  coursesByStudent(model: GetAllStudentCourseFilterModel, callBack: (res: PaginationResultModel<GetAllStudentCourseModel[]>) => void){
    this._http.post<PaginationResultModel<GetAllStudentCourseModel[]>>("StudentCourseRelationship/GetAllByCourse", model, res => {
      callBack(res);
    });
  }
}