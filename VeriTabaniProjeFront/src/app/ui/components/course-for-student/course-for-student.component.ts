import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseForStudentService } from './services/course-for-student.service';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { StaffCourseRLModel } from './models/staff-course-rl.model';
import { StafCourseRLFilterModel } from './models/staff-course-rl-fılter.model';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { StudenCourseRLCreateModel } from './models/student-course-rl-create.model';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { StudentCourseRolesModel } from 'src/app/commons/models/all-role-models/student-course-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';


@Component({
  selector: 'app-course-for-student',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './course-for-student.component.html',
  styleUrls: ['./course-for-student.component.css']
})
export class CourseForStudentComponent implements OnInit{

  pageSize: number = 5;
  pageNumber: number = 1;
  pageNumbers: number[] = [];

  searchNameText: string = '';

  resultFilter: PaginationResultModel<StaffCourseRLModel[]> = new PaginationResultModel<StaffCourseRLModel[]>();

  studentCourseRLRoles: StudentCourseRolesModel = new StudentCourseRolesModel();
  
  constructor(
    private _service: CourseForStudentService,
    private _toastr: ToastrService,
    private _roleService: AllRoleChecksService
  ){}

  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getStudentCourseRLRole(this.studentCourseRLRoles);
    console.log(this.studentCourseRLRoles);
  }

  getAllByFilter(pageNumber: number = 1){
    this.pageNumber = pageNumber

    let model: StafCourseRLFilterModel = new StafCourseRLFilterModel();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null;

    this._service.getAllStaffCurserByDepartment(model, res => {
      this.resultFilter = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

  courseRegistration(id: string){
    let model: StudenCourseRLCreateModel = new StudenCourseRLCreateModel();
    model.courseId = id;

    this._service.studentCourseRLCreate(model, res => {
      console.log(res);
      this._toastr.toast(ToastrType.Success, "Ekleme Başarılı", res.message);
    });
  }

}
