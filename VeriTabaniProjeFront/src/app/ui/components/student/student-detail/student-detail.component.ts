import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PaginationResultModel } from 'src/app/commons/models/paginationResult.model';
import { StudentCourseByStudentModel } from '../models/student-course-by-student.model';
import { CourseByStudentModel } from '../models/courser-by-student.model';
import { StudentService } from '../service/student.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-detail',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.css']
})
export class StudentDetailComponent implements OnInit{

  pageNumber: number = 1;
  pageSize: number = 5;
  pageNumbers: number[] = [];

  detailModel: any;

  resultFilter: PaginationResultModel<StudentCourseByStudentModel[]> = new PaginationResultModel<StudentCourseByStudentModel[]>();

  age: number;
  birthday: Date;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<StudentDetailComponent>,
    private _service: StudentService
  ){
    this.detailModel = data.model;

    this.birthday = new Date(this.detailModel.birthdate);
    this.age = this.ageCalculator(this.birthday.getDay(), this.birthday.getMonth(), this.birthday.getFullYear());
  }

  ngOnInit(): void {
    this.getAllByFilter();
  }

  closeDetail(){
    this._dialogRef.close();
  }

  ageCalculator(day: number, month: number, year: number){
    var ageCalculate: number;
    const today: Date = new Date();

    if(today.getMonth() - month == 0){
      if(today.getDay() - day >= 0)
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

  getAllByFilter(pageNubmer: number = 1){
    this.pageNumber = pageNubmer;

    let model: CourseByStudentModel = new CourseByStudentModel();

    model.pageNumber = this.pageNumber;
    model.pageSize = this.pageSize;
    model.studentId = this.detailModel.id;

    this._service.getAllByStudent(model, res => {
      this.resultFilter = res;

      this.pageNumbers = [];
      for (let i = 1; i <= res.totalPages; i++)
        this.pageNumbers.push(i);
    });
  }

}
