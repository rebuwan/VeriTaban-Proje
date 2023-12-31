import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MainRoleUpdateComponent } from './main-role-update/main-role-update.component';
import { MainRoleCreateComponent } from './main-role-create/main-role-create.component';
import { RolesComponent } from './roles/roles.component';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { MainRoleModel } from './models/main-role.model';
import { RoleService } from 'src/app/commons/services/role.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { SwalService } from 'src/app/commons/services/swal.service';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { MainRoleFilterModel } from './models/main-role-filter.model';
import { MainRoleDeleteModel } from './models/main-role-delete.model';
import { MainRoleUpdateModel } from './models/main-role-update.model';
import { SettingRolesModel } from 'src/app/commons/models/all-role-models/setting-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-main-role-settings',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MainRoleUpdateComponent,
    MainRoleCreateComponent,
    RolesComponent,
    RouterModule
  ],
  templateUrl: './main-role-settings.component.html',
  styleUrls: ['./main-role-settings.component.css'],
})
export class MainRoleSettingsComponent implements OnInit {
  
  searchNameText: string;

  pageNumber: number = 1;
  pageSize: number = 5;
  pageNumbers: number [] = [];

  resultFilter: PaginationResultModel<MainRoleModel[]> = new PaginationResultModel<MainRoleModel[]>();
  searchUserName: boolean = false;

  settingRoles: SettingRolesModel = new SettingRolesModel();

  constructor(
    private _service: RoleService,
    private _dialog: MatDialog,
    private _swal: SwalService,
    private _toastr: ToastrService,
    private _roleService: AllRoleChecksService

  ){}
  
  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getSettingRole(this.settingRoles);
  }

  getAllByFilter(pageNumber: number = 1){
    this.pageNumber = pageNumber;

    let model: MainRoleFilterModel = new MainRoleFilterModel();
    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;

    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null;

    this._service.getAllByFilterMainRoles(model, res => {
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

  removeById(id: string){
    this._swal.callSwal("Sil", "Sil?", "Ana Rol Silinsin mi?", () => {
			let model = new MainRoleDeleteModel();
			model.id = id;
			this._service.removeByIdMainRole(model, (res) => {
				this.getAllByFilter();
				this._toastr.toast(ToastrType.Info, " Ana Rol Silme Işlemi Başarılı", res.message)
			});
		});
  }


  updateState(id: string, title: string){
    const model: MainRoleUpdateModel = new MainRoleUpdateModel();
    model.id = id;
    model.title = title;

    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.maxWidth = '100%';
    dialogConfig.panelClass = 'custom-modalbox';
    dialogConfig.data = { model: { ...model } };

    this._dialog.open(MainRoleUpdateComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      })
  }

  roles(id: string, title:string){
    const model: MainRoleUpdateModel = new MainRoleUpdateModel();
    model.id = id;
    model.title = title;

    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '600px';
    dialogConfig.maxWidth = '100%';
    dialogConfig.panelClass = 'custom-modelbox';
    dialogConfig.data = { model: { ...model } };

    this._dialog.open(RolesComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      })
  }

  showAddForm(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.maxWidth = '100%'
    dialogConfig.panelClass = 'custom-modalbox';

    this._dialog.open(MainRoleCreateComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      })
  }
}
