import { Injectable } from '@angular/core';
import { GenericHttpService } from 'src/app/commons/services/generic-http.service';
import { UserFilterModel } from '../models/user-filter.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { UserModel } from '../models/user.model';
import { DepartmentDropdownModel } from '../../../student/models/department-dropdown.model';
import { UserCreateModel } from '../models/user-create.model';
import { MessageResponseModel } from 'src/app/commons/models/messageResponse.model';
import { RemoveUserModel } from '../models/remove-user.model';
import { ChangeActivityModel } from 'src/app/commons/models/change-activity.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private _http: GenericHttpService
  ) { }

  getAllByFilter(model: UserFilterModel, callBack: (res: PaginationResultModel<UserModel[]>) => void){
    this._http.post<PaginationResultModel<UserModel[]>>("Staff/GetAll", model, res => {
      callBack(res);
    });
  }

  getAllDepartment(model: '', callBack: (res: DepartmentDropdownModel[]) => void){
    this._http.post<DepartmentDropdownModel[]>("Department/GetAll", model, res => {
      callBack(res);
    });
  }

  create(model: FormData, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Staff/Create", model, res => {
      callBack(res);
    });
  }
  update(model: FormData, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Staff/Update", model, res => {
      callBack(res);
    });
  }
  remove(model: RemoveUserModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Staff/Remove", model, res => {
      callBack(res);
    });
  }
  changeActivity( model: ChangeActivityModel, callback:(res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("Staff/ChangeActivity",model,res =>{
      callback(res);
    });
  }
}
