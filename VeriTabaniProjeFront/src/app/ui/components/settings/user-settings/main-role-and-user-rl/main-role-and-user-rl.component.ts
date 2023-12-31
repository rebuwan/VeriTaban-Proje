import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { RoleService } from 'src/app/commons/services/role.service';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { FormsModule } from '@angular/forms';
import { MainRoleAndUserRLFilterModel } from './models/main-role-and-user-filter.model';
import { MainRoleAndUserRLModel } from './models/main-role-and-user-rl.model';
import { IsHaveMainRoleInUserModel } from './models/is-have-main-role-in-user.model';

@Component({
  selector: 'app-main-role-and-user-rl',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './main-role-and-user-rl.component.html',
  styleUrls: ['./main-role-and-user-rl.component.css']
})
export class MainRoleAndUserRlComponent implements OnInit {

  searchNameText: string;

  pageNumber: number = 1;
  pageSize: number = 5;
  pageNumbers: number [] = [];

  resultFilter: PaginationResultModel<MainRoleAndUserRLModel[]> = new PaginationResultModel<MainRoleAndUserRLModel[]>();
  searchUserName: boolean = false;

  mainRoleAndUserRL: any;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<MainRoleAndUserRlComponent>,
    private _service: RoleService,
    private _toastr: ToastrService
  ){
    this.mainRoleAndUserRL = data.model;
    console.log(this.mainRoleAndUserRL);
  }

  ngOnInit(): void {
    this.getAllByFilter();
  }

  getAllByFilter(pageNumber: number = 1){
    this.pageNumber = pageNumber

    let model: MainRoleAndUserRLFilterModel = new MainRoleAndUserRLFilterModel();
    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.userId = this.mainRoleAndUserRL.userId;

    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null;

    this._service.getAllByFilterMainRoleAndUserRL(model, res => {
      this.resultFilter = res;

      this.pageNumbers = [];

      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

  roleIsHaveChange(mainRoleId: string){
    const model: IsHaveMainRoleInUserModel = new IsHaveMainRoleInUserModel();
    model.userId = this.mainRoleAndUserRL.userId;
    model.mainRoleId = mainRoleId;

    console.log(model);

    this._service.mainRoleIsHave(model, res => {
      this.getAllByFilter();
      this._toastr.toast(ToastrType.Success, "Role Güncelleme Başarılı", res.message);
    });
  }

  closeDetail(){
    this._dialogRef.close();
  }

}
