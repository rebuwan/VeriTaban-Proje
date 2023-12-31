import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { StudentCourseByStudentModel } from '../../student/models/student-course-by-student.model';
import { CourseByStudentModel } from '../../student/models/courser-by-student.model';
import { FormsModule } from '@angular/forms';
import { CourseForStudentService } from '../services/course-for-student.service';
import { StudentCourseRolesModel } from 'src/app/commons/models/all-role-models/student-course-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit{

  pageSize: number = 5;
  pageNumber: number = 1;
  pageNumbers: number[] = [];

  searchNameText: string = '';

  resultFilter: PaginationResultModel<StudentCourseByStudentModel[]> = new PaginationResultModel<StudentCourseByStudentModel[]>();

  studentCourseRLRoles: StudentCourseRolesModel = new StudentCourseRolesModel();

  constructor(
    private _service: CourseForStudentService,
    private _roleService: AllRoleChecksService
  ){}

  ngOnInit(): void {
    this.getAllByFilter();
    this._roleService.getStudentCourseRLRole(this.studentCourseRLRoles);
  }

  getAllByFilter(pageNubmer: number = 1){
    this.pageNumber = pageNubmer;

    let model: CourseByStudentModel = new CourseByStudentModel();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.search = this.searchNameText?.length > 0 ? this.searchNameText : null

    this._service.getAllByStudent(model, res => {
      this.resultFilter = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

}
