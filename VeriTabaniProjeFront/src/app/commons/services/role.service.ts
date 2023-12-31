import { Injectable } from '@angular/core';
import { GenericHttpService } from './generic-http.service';
import { LoginResponseService } from './login-response.service';
import { MainRoleFilterModel } from 'src/app/ui/components/settings/main-role-settings/models/main-role-filter.model';
import { PaginationResultModel } from '../models/paginationResult.model';
import { MainRoleModel } from 'src/app/ui/components/settings/main-role-settings/models/main-role.model';
import { MainRoleCreateModel } from 'src/app/ui/components/settings/main-role-settings/models/main-role-create.model';
import { MessageResponseModel } from '../models/messageResponse.model';
import { MainRoleUpdateModel } from 'src/app/ui/components/settings/main-role-settings/models/main-role-update.model';
import { MainRoleDeleteModel } from 'src/app/ui/components/settings/main-role-settings/models/main-role-delete.model';
import { RoleFilterModel } from 'src/app/ui/components/settings/main-role-settings/roles/models/role-filter.model';
import { RoleModel } from 'src/app/ui/components/settings/main-role-settings/roles/models/role.model';
import { RoleIsHaveModel } from 'src/app/ui/components/settings/main-role-settings/roles/models/role-is-have.model';
import { MainRoleAndUserRLFilterModel } from 'src/app/ui/components/settings/user-settings/main-role-and-user-rl/models/main-role-and-user-filter.model';
import { MainRoleAndUserRLModel } from 'src/app/ui/components/settings/user-settings/main-role-and-user-rl/models/main-role-and-user-rl.model';
import { IsHaveMainRoleInUserModel } from 'src/app/ui/components/settings/user-settings/main-role-and-user-rl/models/is-have-main-role-in-user.model';
import { RoleQueryModel } from '../models/role-query.model';
import { RolesModel } from '../models/roles.model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(
    private _http: GenericHttpService,
    private _loginResponse: LoginResponseService
  ) { }

  //#region Auth User Role
  getUserRoles(model: RoleQueryModel, callBack: (res: RolesModel) => void){
    model.userNameOrEmail = this._loginResponse.getLoginResponseModel().userCode;

    this._http.post<RolesModel>("Auth/GetUserRolesByUserNameOrEmail", model, res => {
      callBack(res);
    });
  }
  //#endregion

  //#region Main Role Service
  getAllByFilterMainRoles(model: MainRoleFilterModel, callBack: (res: PaginationResultModel<MainRoleModel[]>) => void){
    this._http.post<PaginationResultModel<MainRoleModel[]>>("MainRole/GelAllByFilterMainRoles", model, res => {
      callBack(res);
    });
  }

  createMainRole(model: MainRoleCreateModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("MainRole/Create", model, res => {
      callBack(res);
    });
  }

  updateMainRole(model: MainRoleUpdateModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("MainRole/Update", model, res => {
      callBack(res);
    });
  }

  removeByIdMainRole(model: MainRoleDeleteModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("MainRole/Remove", model, res => {
      callBack(res);
    });
  }

  getAllByFilterMainRoleAndUserRL(model: MainRoleAndUserRLFilterModel, callBack: (res: PaginationResultModel<MainRoleAndUserRLModel[]>) => void){
    this._http.post<PaginationResultModel<MainRoleAndUserRLModel[]>>("MainRoleAndUserRelationship/GetAllByFilterMainRoleAndUserRL", model, res => {
      callBack(res);
    });
  }

  mainRoleIsHave(model: IsHaveMainRoleInUserModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("MainRoleAndUserRelationship/IsHaveMainRoleInUser", model, res => {
      callBack(res);
    });
  }
  //#endregion Main Role Service

  //#region Roles Service
  getAllByFilterRoles(model: RoleFilterModel, callBack: (res: PaginationResultModel<RoleModel[]>) => void){
    this._http.post<PaginationResultModel<RoleModel[]>>("Roles/GetAllByFilterRoles", model, res => {
      callBack(res);
    });
  }

  roleIsHave(model: RoleIsHaveModel, callBack: (res: MessageResponseModel) => void){
    this._http.post<MessageResponseModel>("MainRoleAndRoleRelationship/IsHaveRoleInMainRole", model, res => {
      callBack(res);
    });
  }
  //#endregion
}
