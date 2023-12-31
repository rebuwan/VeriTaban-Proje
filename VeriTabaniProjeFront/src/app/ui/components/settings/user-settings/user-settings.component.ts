import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from './services/user.service';
import { UserFilterModel } from './models/user-filter.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { UserModel } from './models/user.model';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UserCreateComponent } from './user-create/user-create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { LoginResponseService } from 'src/app/commons/services/login-response.service';
import { MainRoleAndUserRLModel } from './main-role-and-user-rl/models/main-role-and-user-rl.model';
import { MainRoleAndUserRlComponent } from './main-role-and-user-rl/main-role-and-user-rl.component';
import { AssignTheMainRoleModel } from './models/assign-the-main-role.model';
import { SwalService } from 'src/app/commons/services/swal.service';
import { RemoveUserModel } from './models/remove-user.model';
import { UpdateUserComponent } from './update-user/update-user.component';
import { ChangeActivityModel } from 'src/app/commons/models/change-activity.model';
import { SettingRolesModel } from 'src/app/commons/models/all-role-models/setting-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { StaffRolesModel } from 'src/app/commons/models/all-role-models/staff-roles.model';

@Component({
  selector: 'app-user-settings',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    UserCreateComponent,
    MatFormFieldModule,
    MatSelectModule,
    MainRoleAndUserRlComponent
  ],
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.css'],
})
export class UserSettingsComponent implements OnInit {
  pageSize: number = 5;
  pageNumber: number = 1;
  pageNumbers: number[] = [];

  searchNameText: string = '';

  resultFilter: PaginationResultModel<UserModel[]> = new PaginationResultModel<
    UserModel[]
  >();

  settingRoles: SettingRolesModel = new SettingRolesModel();
  staffRoles: StaffRolesModel = new StaffRolesModel();

  constructor(
    private _userService: UserService,
    private _dialog: MatDialog,
    private _swal : SwalService,
    private _toastr: ToastrService,
    private _roleService: AllRoleChecksService
  ) {}

  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getSettingRole(this.settingRoles);
    this._roleService.getStaffRole(this.staffRoles);
  }

  getAllByFilter(pageNumber: number = 1) {
    this.pageNumber = pageNumber;

    let model: UserFilterModel = new UserFilterModel();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;

    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null;

    this._userService.getAllByFilter(model, (res) => {
      this.resultFilter = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++) this.pageNumbers.push(i);
    });
  }
  
  changeActiveState(id: string, state: boolean) {
    let model = new ChangeActivityModel();
     model.id = id;
     model.state = state;
     this._userService.changeActivity(model, (res) => {
       this.getAllByFilter();
       this._toastr.toast(ToastrType.Info, "Durum Güncelleme Başarılı", res.message);
     });
  }

  userCreateState() {
    const dialogConfig = new MatDialogConfig();
		dialogConfig.panelClass = 'custom-modalbox';
		dialogConfig.width = '850px';
		dialogConfig.maxWidth = '100%';

    this._dialog.open(UserCreateComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      });
  }

  removeById(staff: UserModel){
     this._swal.callSwal("Sil", "Sil?", "Personer Kaydı Silinsin Mi?", () => {
       let model = new RemoveUserModel();
        model.id = staff.id;
        model.userId = staff.userId
       this._userService.remove(model, (res) => {
         this.getAllByFilter();
         this._toastr.toast(ToastrType.Info, "Personel Kaydı Silme İşlemi Başarılı", res.message);
       });
     });
  }

  updateState(model: any){
     const dialogConfig = new MatDialogConfig();
     dialogConfig.width = '850px';
     dialogConfig.maxWidth = '100%';
     dialogConfig.panelClass = 'custom-modalbox';
     dialogConfig.data = {model: { ...model } };
    
     this._dialog.open(UpdateUserComponent, dialogConfig)
     .afterClosed().
     subscribe((shouldReload: boolean) => {
       this.getAllByFilter();
     });
  }

  detailState(model: any){
    // const dialogConfig = new MatDialogConfig();
    // dialogConfig.width = '100%';
    // dialogConfig.maxWidth = '100%';
    // dialogConfig.panelClass = 'custom-modalbox';
    // dialogConfig.data = {model: { ...model } };

    // this.getAllByFilter();

    // this._dialog.open(StudentDetailComponent, dialogConfig);
  }

  assignTheMainRole(userId: string, userName: string, userLastName: string, mainRoleTitle: string){
    const model: AssignTheMainRoleModel = new AssignTheMainRoleModel();
    model.userId = userId;
    model.userName = userName;
    model.userLastName = userLastName;
    model.mainRoleTitle = mainRoleTitle == null ? "Ana Rolü Yok" : mainRoleTitle;

    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.maxWidth = '100%';
    dialogConfig.panelClass = 'custom-modelbox';
    dialogConfig.data = { model: { ...model } };

    this._dialog.open(MainRoleAndUserRlComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      })
  }
}
