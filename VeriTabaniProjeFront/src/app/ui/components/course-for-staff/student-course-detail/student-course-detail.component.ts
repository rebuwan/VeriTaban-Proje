import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { GetAllStudentCourseFilterModel } from '../models/get-all-student-course-filter.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GetAllStudentCourseModel } from '../models/get-all-student-course.model';
import { CourseForStaffService } from '../services/course-for-staff.service';

@Component({
  selector: 'app-student-course-detail',
  standalone: true,
  imports: [CommonModule, StudentCourseDetailComponent],
  templateUrl: './student-course-detail.component.html',
  styleUrls: ['./student-course-detail.component.css']
})
export class StudentCourseDetailComponent implements OnInit {

  pageNumber: number = 1;
  pageSize: number = 5;
  pageNumbers: number[] = [];

  resultFilter: PaginationResultModel<GetAllStudentCourseModel[]> = new PaginationResultModel<GetAllStudentCourseModel[]>();

  detailModel: any;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<StudentCourseDetailComponent>,
    private _service: CourseForStaffService
  ){
    this.detailModel = data.model;
    console.log(this.detailModel);
  }

  ngOnInit(): void {
    this.getAllByFilter();
  }

  closeDetail(){
    this._dialogRef.close();
  }

  getAllByFilter(pageNubmer: number = 1){
    this.pageNumber = pageNubmer;

    let model: GetAllStudentCourseFilterModel  = new GetAllStudentCourseFilterModel();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.courseId = this.detailModel.staffCourseId;

    console.log(model);

    this._service.coursesByStudent(model, res => {
      this.resultFilter = res;

      console.log(res);

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }
}
