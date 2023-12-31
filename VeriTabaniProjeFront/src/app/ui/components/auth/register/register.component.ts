import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { ValidInputDirective } from 'src/app/commons/directives/valid-input.directive';
import { AuthService } from '../services/auth.service';
import { LoginFirstTimeModel } from '../models/login-first-time.model';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, ValidInputDirective],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  constructor(
    private _auth: AuthService,
    private _toastr: ToastrService,
    private _router: Router

  ){}

  loginFirstTime(form: NgForm){
    let model: LoginFirstTimeModel = new LoginFirstTimeModel();

    model.birthdate = form.controls['birthdate'].value;
    model.userId = form.controls["userId"].value;
    model.password = form.controls["password"].value;

    console.log(model);

    if (form.valid){
      this._auth.loginForAFirstTime(model, res => {
        this._toastr.toast(ToastrType.Success, "Hesap Oluşturuldu !", res.message);
        this._router.navigateByUrl("/login");
      });
    }
  }

}
