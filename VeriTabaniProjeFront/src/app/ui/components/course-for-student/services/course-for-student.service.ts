import { Injectable } from '@angular/core';
import { GenericHttpService } from 'src/app/commons/services/generic-http.service';
import { LoginResponseService } from 'src/app/commons/services/login-response.service';
import { StafCourseRLFilterModel } from '../models/staff-course-rl-fılter.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { StaffCourseRLModel } from '../models/staff-course-rl.model';
import { StudenCourseRLCreateModel } from '../models/student-course-rl-create.model';
import { MessageResponseModel } from 'src/app/commons/models/messageResponse.model';
import { CourseByStudentModel } from '../../student/models/courser-by-student.model';
import { StudentCourseByStudentModel } from '../../student/models/student-course-by-student.model';

@Injectable({
  providedIn: 'root'
})
export class CourseForStudentService {

  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) { }

  getAllStaffCurserByDepartment(model: StafCourseRLFilterModel, callBack: (res: PaginationResultModel<StaffCourseRLModel[]>) => void){
    model.departmentId = this._loginResponse.getLoginResponseModel().department.id;

    this._http.post<PaginationResultModel<StaffCourseRLModel[]>>("StaffCourseRelationship/GetAllByDepartment", model, res => {
      callBack(res);
    });
  }

  studentCourseRLCreate(model: StudenCourseRLCreateModel, callBack: (res: MessageResponseModel) => void){
    model.studentId = this._loginResponse.getLoginResponseModel().staffId_StudentId;
    this._http.post<MessageResponseModel>("StudentCourseRelationship/Create", model, res => {
      callBack(res);
    });
  }

  getAllByStudent(model: CourseByStudentModel, callBack: (res: PaginationResultModel<StudentCourseByStudentModel[]>) => void){

    model.studentId = this._loginResponse.getLoginResponseModel().staffId_StudentId;

    this._http.post<PaginationResultModel<StudentCourseByStudentModel[]>>("StudentCourseRelationship/GetAllByStudent", model, res =>{
      callBack(res);
    });
  }
}
