import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from './service/student.service';
import { StudentModel } from './models/student.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { StudentFilterModel } from './models/student-filter.model';
import { StudentCreateComponent } from './student-create/student-create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { StudentDetailComponent } from './student-detail/student-detail.component';
import { RouterModule } from '@angular/router';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { ChangeActivityModel } from 'src/app/commons/models/change-activity.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { StudentRolesModel } from 'src/app/commons/models/all-role-models/student-roles.model';
import { SwalService } from 'src/app/commons/services/swal.service';
import { StudentDeleteModel } from './models/student-delete.model';
import { StudentUpdateComponent } from './student-update/student-update.component';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    StudentCreateComponent,
    StudentDetailComponent,
    MatFormFieldModule,
    MatSelectModule
  ],
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  pageNumber: number = 1;
  pageSize: number = 5;
  pageNumbers: number[] = [];

  searchNameText: string = '';
  resultFilter: PaginationResultModel<StudentModel[]> = new PaginationResultModel<StudentModel[]>();

  studentRoles: StudentRolesModel = new StudentRolesModel();

  constructor(
    private _service: StudentService,
    private _dialog: MatDialog,
    private _toastr: ToastrService,
    private _roleService: AllRoleChecksService,
    private _swal: SwalService
  ) { }

  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getStudentRole(this.studentRoles);
  }

  getAllByFilter(pageNubmer: number = 1) {
    this.pageNumber = pageNubmer;

    let model: StudentFilterModel = new StudentFilterModel();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null

    this._service.getAllByFilter(model, res => {
      this.resultFilter = res;

      for (let i = 0; i < this.resultFilter.datas.length; i++) {
        let count = new Date(this.resultFilter.datas[i].birthdate);
        this.resultFilter.datas[i].age = this.ageCalculator(count.getDay(), count.getMonth(), count.getFullYear());
      }

      console.log(this.resultFilter);

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

  search() { };

  studentCreateState() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.panelClass = 'custom-modalbox';
    dialogConfig.width = '850px';
    dialogConfig.maxWidth = '100%';

    this._dialog.open(StudentCreateComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      });
  }

  changeActiveState(id: string, state: boolean) {
    let model = new ChangeActivityModel();
    model.id = id;
    model.state = state;
    this._service.changeActivity(model, (res) => {
      this.getAllByFilter();
      this._toastr.toast(ToastrType.Info, "Durum Güncelleme Başarılı", res.message);
    });
  }

  removeById(id: string) {
    this._swal.callSwal("Sil", "Sil?", "Öğrenci Kaydı Silinsin Mi?", () => {
      let model = new StudentDeleteModel();
      model.id = id;

      this._service.removeById(model, (res) => {
        this.getAllByFilter();
        this._toastr.toast(ToastrType.Info, "Öğrenci Kaydı Silme İşlemi Başarılı", res.message);
      });
    });
  }

  updateState(model: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '850px';
    dialogConfig.maxWidth = '100%';
    dialogConfig.panelClass = 'custom-modalbox';
    dialogConfig.data = {model: { ...model } };

    this._dialog.open(StudentUpdateComponent, dialogConfig)
    .afterClosed().
    subscribe((shouldReload: boolean) => {
      this.getAllByFilter();
    });
  }

  detailState(model: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '850px';
    dialogConfig.maxWidth = '100%';
    dialogConfig.panelClass = 'custom-modalbox';
    dialogConfig.data = { model: { ...model } };

    this.getAllByFilter();

    this._dialog.open(StudentDetailComponent, dialogConfig);
  }

  ageCalculator(day: number, month: number, year: number) {
    var ageCalculate: number;
    const today: Date = new Date();

    if (today.getMonth() - month == 0) {
      if (today.getDay() - day >= 0)
        ageCalculate = today.getFullYear() - year;
      else
        ageCalculate = today.getFullYear() - year - 1;
    }

    else if (today.getMonth() - month > 0)
      ageCalculate = today.getFullYear() - year;


    else
      ageCalculate = today.getFullYear() - year - 1;

    return ageCalculate;
  }
}
