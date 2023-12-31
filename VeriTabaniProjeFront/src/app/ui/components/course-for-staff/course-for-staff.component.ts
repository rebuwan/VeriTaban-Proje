import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseForStaffService } from './services/course-for-staff.service';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { CourseForStaffModel } from './models/course-for-staff.model';
import { CourseGetAllByFilterModel } from './models/course-get-all-by-filter.model';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { FormsModule } from '@angular/forms';
import { StaffCourseRLCreateModel } from './models/staff-course-rl-create.model';
import { StaffCourseRolesModel } from 'src/app/commons/models/all-role-models/staff-course-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-course-for-staff',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './course-for-staff.component.html',
  styleUrls: ['./course-for-staff.component.css']
})
export class CourseForStaffComponent implements OnInit{

  pageSize: number = 5;
  pageNumber: number = 1;
  pageNumbers: number[] = [];

  searchNameText: string = '';

  resultFilter: PaginationResultModel<CourseForStaffModel[]> = new PaginationResultModel<CourseForStaffModel[]>();

  staffCourseRLRoles: StaffCourseRolesModel = new StaffCourseRolesModel();

  constructor(
    private _service: CourseForStaffService,
    private _toastr: ToastrService,
    private _roleService: AllRoleChecksService
  ){}

  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getStaffCourseRLRole(this.staffCourseRLRoles);
  }

  getAllByFilter(pageNumber: number = 1){
    this.pageNumber = pageNumber;

    let model: CourseGetAllByFilterModel = new CourseGetAllByFilterModel();

    model.pageSize = this.pageSize;
    model.pageNumber = this.pageNumber;
    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null;

    this._service.getAllByFilterCourse(model, res => {
      this.resultFilter = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

  courseRegistration(id: string){
    let model: StaffCourseRLCreateModel = new StaffCourseRLCreateModel();
    model.courseId = id;

    this._service.staffCourseRLCreate(model, res => {
      this.getAllByFilter(this.pageNumber);
      this._toastr.toast(ToastrType.Success, "Ekleme Başarılı", res.message);
    });
  }

}
