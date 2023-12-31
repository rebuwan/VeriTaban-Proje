import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginResponseService } from 'src/app/commons/services/login-response.service';
import { LoginResponseModel } from '../../../auth/models/login-response.model';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  @Input() durum: boolean;
  @Output() sideBar = new EventEmitter<boolean>();

  loginResponse: LoginResponseModel = new LoginResponseModel();

  constructor(
    private _loginResponse: LoginResponseService,
    private _route: Router
  ){
    this.loginResponse = _loginResponse.getLoginResponseModel();
  }

  degis(){
    this.durum = !this.durum;
    this.sideBar.emit(this.durum)
  }

  cikisYap(){
    localStorage.removeItem("accessToken");
    this._route.navigate(['/login']);
  }
}
