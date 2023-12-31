import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GetAllCoursesByStaff } from '../models/staff-course/get-all-courses-by-staff.model';
import { CourseForStaffService } from '../services/course-for-staff.service';
import { CoursesByStaffModel } from '../models/staff-course/staff-course.model';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { FormsModule } from '@angular/forms';
import { RolesComponent } from '../../settings/main-role-settings/roles/roles.component';
import { StaffCourseRolesModel } from 'src/app/commons/models/all-role-models/staff-course-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { StudentCourseDetailComponent } from '../student-course-detail/student-course-detail.component';

@Component({
  selector: 'app-staff-course',
  standalone: true,
  imports: [CommonModule,FormsModule, RolesComponent],
  templateUrl: './staff-course.component.html',
  styleUrls: ['./staff-course.component.css']
})
export class StaffCourseComponent {
  
  pageNumbers: number[];
  searchNameText: string;
  pageSize: number = 10;
  pageNumber: number;
  Courses: PaginationResultModel<CoursesByStaffModel[]> = new  PaginationResultModel<CoursesByStaffModel[]>();

  staffCourseRLRoles: StaffCourseRolesModel = new StaffCourseRolesModel();

  constructor(
    private _service: CourseForStaffService,
    private _roleService: AllRoleChecksService,
    private _dialog: MatDialog
  ){}
  
  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getStaffCourseRLRole(this.staffCourseRLRoles);
  }

  getAllByFilter(pageNubmer: number = 1){
    this.pageNumber = pageNubmer;

    let model: GetAllCoursesByStaff = new GetAllCoursesByStaff();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null

    this._service.coursesByStaff(model, res => {
      this.Courses = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

  detail(model: any){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '850px';
    dialogConfig.maxWidth = '100%';
    dialogConfig.panelClass = 'custom-modalbox';
    dialogConfig.data = {model: {...model}};

    this._dialog.open(StudentCourseDetailComponent, dialogConfig)
    .afterClosed().
    subscribe((shouldReload: boolean) => {
      this.getAllByFilter();
    });
  }

}
