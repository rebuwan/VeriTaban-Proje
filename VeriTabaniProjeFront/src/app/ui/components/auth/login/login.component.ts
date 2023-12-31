import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { ValidInputDirective } from 'src/app/commons/directives/valid-input.directive';
import { AuthService } from '../services/auth.service';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, ValidInputDirective],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {

  constructor(
    private _auth: AuthService,
    private _toastr: ToastrService
  ) {}

  login(form: NgForm) {
    if (form.valid) {
      this._auth.login(form.value);
    }
  }

  addTestDatas(){
    this._auth.addTestData(res=>{
      this._toastr.toast(ToastrType.Success,res.message,"Başarılı");
    })
  }
}
