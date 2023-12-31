import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CryptoService } from 'src/app/commons/services/crypto.service';
import { GenericHttpService } from 'src/app/commons/services/generic-http.service';
import { LoginResponseModel } from '../models/login-response.model';
import { LoginFirstTimeModel } from '../models/login-first-time.model';
import { MessageResponseModel } from 'src/app/commons/models/messageResponse.model';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  api: string = 'Auth/Login';

  constructor(
    private _http: GenericHttpService,
    private _router: Router,
    private _crypto: CryptoService
  ) { }

  login(model: any) {
    this._http.post<LoginResponseModel>(this.api, model, (res) => {
      let cryptoValue = this._crypto.encrypto(JSON.stringify(res));
      localStorage.setItem('accessToken', cryptoValue);
      this._router.navigateByUrl('/');
    });
  }

  loginForAFirstTime(model: LoginFirstTimeModel, callBack: (res: MessageResponseModel) => void) {
    this._http.post<MessageResponseModel>("Auth/LoginForAFirstTime", model, res => {
      callBack(res);
    });
  }

  addTestData(callBack: (res: MessageResponseModel) => void) {
    this._http.post<MessageResponseModel>("A_GenericList/CreateDepartment", null, res => {
      callBack(res);
    });
    this._http.post<MessageResponseModel>("A_GenericList/CreateCourse", null, res => {
      callBack(res);
    });
    this._http.post<MessageResponseModel>("MainRole/CreateAllMainRoles", null, res => {
      callBack(res);
      this._http.post<MessageResponseModel>("Roles/CreateAllRoles", null, res => {
        callBack(res);
      });
      this._http.post<MessageResponseModel>("A_GenericList/CreateStudent", null, res => {
        callBack(res);
      });
      this._http.post<MessageResponseModel>("A_GenericList/CreateStaff", null, res => {
        callBack(res);
      });
    });
  }
}
