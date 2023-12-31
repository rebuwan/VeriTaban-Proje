import { Injectable } from '@angular/core';
import { GenericHttpService } from 'src/app/commons/services/generic-http.service';
import { StudentModel } from '../models/student.model';
import { StudentFilterModel } from '../models/student-filter.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { StudentCreateModel } from '../models/student-create.model';
import { MessageResponseModel } from 'src/app/commons/models/messageResponse.model';
import { DepartmentDropdownModel } from '../models/department-dropdown.model';
import { CourseByStudentModel } from '../models/courser-by-student.model';
import { StudentCourseByStudentModel } from '../models/student-course-by-student.model';
import { LoginResponseService } from 'src/app/commons/services/login-response.service';
import { ChangeActivityModel } from 'src/app/commons/models/change-activity.model';
import { StudentDeleteModel } from '../models/student-delete.model';
import { StudentUpdateModel } from '../models/student-update.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) { }

  getAllByFilter(model: StudentFilterModel, callBack: (res: PaginationResultModel<StudentModel[]>) => void){
    model.departmentId = this._loginResponse.getLoginResponseModel().department.id;

    this._http.post<PaginationResultModel<StudentModel[]>>("Student/GetAll", model, res => {
      callBack(res);
    });
  }

  create(model: FormData, callBack: (res: 'MessageResponseModel') => void){
    
    this._http.post<'MessageResponseModel'>("Student/Create", model, res => {
      callBack(res);
    });
  }

  getAllDepartment(model: '', callBack: (res: DepartmentDropdownModel[]) => void){

    this._http.post<DepartmentDropdownModel[]>("Department/GetAll", model, res => {
      callBack(res);
    });
  }

  // Course 
  getAllByStudent(model: CourseByStudentModel, callBack: (res: PaginationResultModel<StudentCourseByStudentModel[]>) => void){

    this._http.post<PaginationResultModel<StudentCourseByStudentModel[]>>("StudentCourseRelationship/GetAllByStudent", model, res =>{
      callBack(res);
    });
  }

  changeActivity( model: ChangeActivityModel, callback:(res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Student/ChangeActivity",model,res =>{
      callback(res);
    });
  }

  removeById(model: StudentDeleteModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Student/RemoveById", model, res => {
      callBack(res);
    });
  }

  update(model: StudentUpdateModel, callBack: (res: MessageResponseModel) => void) {
    this._http.post<MessageResponseModel>("Student/Update", model, res => {
      callBack(res);
    });
  }
}
