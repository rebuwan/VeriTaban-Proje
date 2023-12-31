import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CourseService } from './services/course.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { GetAllCoursesByFilter } from './models/get-all-courses.model';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { CourseModel } from './models/course.model';
import { SwalService } from 'src/app/commons/services/swal.service';
import { CreateCourseComponent } from './create-course/create-course.component';
import { ChangeActivityModel } from 'src/app/commons/models/change-activity.model';
import { CourseRolesModel } from 'src/app/commons/models/all-role-models/course-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-course',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent {
  pageNumbers: number[] = [];

  pageNumber: number;
  pageSize: number = 10;
  searchNameText: any;

  Courses: PaginationResultModel<CourseModel[]> = new PaginationResultModel<CourseModel[]>();

  courseRoles: CourseRolesModel = new CourseRolesModel();

  constructor(
    private _service: CourseService,
    private _dialog: MatDialog,
    private _toastr: ToastrService,
    private _swal: SwalService,
    private _roleService: AllRoleChecksService
  ) {

  }

  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getCourseRole(this.courseRoles);
  }



  getAllByFilter(pageNumber: number = 1) {
    this.pageNumber = pageNumber;

    let model: GetAllCoursesByFilter = new GetAllCoursesByFilter();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null

    this._service.getAllByFilter(model, res => {
      this.Courses = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });

  }

  courseCreateState() {
    const dialogConfig = new MatDialogConfig();
		dialogConfig.panelClass = 'custom-modalbox';
		dialogConfig.width = '850px';
		dialogConfig.maxWidth = '100%';

    this._dialog.open(CreateCourseComponent, dialogConfig)
      .afterClosed()
      .subscribe((shouldReload: boolean) => {
        this.getAllByFilter();
      });
  }

  detailState(_t29: any) {
    throw new Error('Method not implemented.');
  }
  updateState(_t29: any) {
    throw new Error('Method not implemented.');
  }
  removeById(id: string) {
    this._swal.callSwal("Sil", "Sil?", "Personer Kaydı Silinsin Mi?", () => {    
      this._service.remove(id, (res) => {
        this.getAllByFilter();
        this._toastr.toast(ToastrType.Info, "Personel Kaydı Silme İşlemi Başarılı", res);
      });
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
}
