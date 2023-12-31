import { Injectable } from '@angular/core';
import { LoginResponseModel } from '../../auth/models/login-response.model';
import { LoginResponseService } from 'src/app/commons/services/login-response.service';
import { GenericHttpService } from 'src/app/commons/services/generic-http.service';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { CourseModel } from '../models/course.model';
import { CreateCourseModel } from '../models/create-course.model';
import { DepartmentDropdownModel } from '../../student/models/department-dropdown.model';
import { GetAllCoursesByFilter } from '../models/get-all-courses.model';
import { ChangeActivityModel } from 'src/app/commons/models/change-activity.model';
import { MessageResponseModel } from 'src/app/commons/models/messageResponse.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) { }

  getAllByFilter(model: GetAllCoursesByFilter, callBack: (res: PaginationResultModel<CourseModel[]>) => void){
    model.departmentId = this._loginResponse.getLoginResponseModel().department.id;

    this._http.post<PaginationResultModel<CourseModel[]>>("Course/GetAllByFilter", model, res => {
      callBack(res);
    });
  }

  create(model: CreateCourseModel, callBack: (res: 'MessageResponseModel') => void){
    //model.departmentId = this._loginResponse.getLoginResponseModel().department.id;

    this._http.post<'MessageResponseModel'>("Course/Create", model, res => {
      callBack(res);
    });
  }

  getAllDepartment(model: '', callBack: (res: DepartmentDropdownModel[]) => void){
    this._http.post<DepartmentDropdownModel[]>("Department/GetAll", model, res => {
      callBack(res);
    });
  }

  remove(id:string, callBack: (res: 'MessageResponseModel') => void){
    let model = {
      id:id
    };
    this._http.post<'MessageResponseModel'>("Course/RemoveById", model, res => {
      callBack(res);
    });
  }
  changeActivity( model: ChangeActivityModel, callback:(res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Course/ChangeActivity",model,res =>{
      callback(res);
    });
  }
}
