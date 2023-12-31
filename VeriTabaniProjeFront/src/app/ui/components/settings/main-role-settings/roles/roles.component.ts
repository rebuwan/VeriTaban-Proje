import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { RoleService } from 'src/app/commons/services/role.service';

import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { RoleModel } from './models/role.model';
import { RoleFilterModel } from './models/role-filter.model';
import { RoleIsHaveModel } from './models/role-is-have.model';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {

  searchNameText: string;
  selectedMenuItem: string = '';

  pageNumber: number = 1;
  pageSize: number = 5;
  pageNumbers: number [] = [];

  resultFilter: PaginationResultModel<RoleModel[]> = new PaginationResultModel<RoleModel[]>();
  searchUserName: boolean = false;

  mainRoleData: any;

  //model: any = {};

  active: boolean = null;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<RolesComponent>,
    private _service: RoleService,
    private _toastr: ToastrService
  ){
    this.mainRoleData = data.model;
  }

  ngOnInit(): void {
    this.getAllByFilter();
  }

  onSelectionChange(entry: any) {
    if (entry == 'false'){
      this.active = false;
    }

    else if (entry == 'true') {
      this.active = true;
    }

    else 
      this.active = null;
  }

  getAllByFilter(pageNumber: number = 1, name: string = 'Öğrenciler'){
    this.pageNumber = pageNumber;

    let model: RoleFilterModel = new RoleFilterModel();
    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.mainRoleId = this.mainRoleData.id;

    if (name != null) {
      this.searchNameText = name;
      this.selectedMenuItem = name;
    }

    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null;

    this._service.getAllByFilterRoles(model, res => {
      this.resultFilter = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

  search(){
    this.searchUserName = true;

    if(this.searchUserName == true)
      this.getAllByFilter();
  }

  closeDetail(){
    this._dialogRef.close();
  }

  roleIsHaveChange(appRoleId: string, mainRoleId: string){
    const model: RoleIsHaveModel = new RoleIsHaveModel();
    model.roleId = appRoleId;
    model.mainRoleId = mainRoleId;

    this._service.roleIsHave(model, res => {
      this.getAllByFilter(1, this.searchNameText);
      this._toastr.toast(ToastrType.Success, "Role Güncelleme Başarılı", res.message);
    });
  }

}
