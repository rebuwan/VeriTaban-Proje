import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { RoleService } from 'src/app/commons/services/role.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/commons/services/swal.service';

@Component({
  selector: 'app-main-role-update',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './main-role-update.component.html',
  styleUrls: ['./main-role-update.component.css']
})
export class MainRoleUpdateComponent {

  updateModel: any;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<MainRoleUpdateComponent>,
    private _service: RoleService,
    private _swal: SwalService,
    private _toastr: ToastrService

  ){
    this.updateModel = data.model;
  }

  update(form: NgForm){
    this.updateModel.title = form.controls['title'].value;

    this._swal.callSwal(
      'Güncelle',
      'Güncelle?',
      'Güncellemek İstediğinizden Emin misiniz?',
      () => {
        this._service.updateMainRole(this.updateModel, (res) => {
          this._toastr.toast(
            ToastrType.Success,
            res.message,
            'Güncelleme Başarılı'
          );
        });
        form.reset();
        this.closePopup();
      }
    );
  }

  closePopup() {
    this._dialogRef.close();
  }
  
}
