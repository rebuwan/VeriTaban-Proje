import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';
import { CourseService } from '../services/course.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CreateCourseModel } from '../models/create-course.model';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { ValidInputDirective } from 'src/app/commons/directives/valid-input.directive';

@Component({
  selector: 'app-create-course',
  standalone: true,
  imports: [CommonModule,ValidInputDirective,FormsModule],
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.css']
})
export class CreateCourseComponent {
  departmentTypes: any[];
  selectedDepartmentType: number = -1;

  constructor(
    public _dialogRef: MatDialogRef<CreateCourseComponent>,
    private _service: CourseService,
    private _toastr: ToastrService
  ){}

  ngOnInit(): void {
    this.getAllDepartmanTypes();
  }

  getAllDepartmanTypes() {
    this._service.getAllDepartment('', (res) => {
      this.handleDepartmentTypes(res);
    });
  }

  handleDepartmentTypes(response: any) {
    this.departmentTypes = response.departments.map(
      (item: { id: any; departmentName: any }) => ({
        id: item.id,
        name: item.departmentName,
      })
    );
  }

  create(form: NgForm) {	
    let model = new CreateCourseModel();
    
    model.courseCode = form.controls['courseCode'].value;
    model.courseName= form.controls['courseName'].value;
    model.credit= form.controls['credit'].value;
    model.departmentId= form.controls['departmentId'].value;
    
		if (form.valid) {
      this._service.create(model, res => {
        this._toastr.toast(ToastrType.Success, 'Ekleme Başarılı', res);
        form.reset();
        this.closeDetail();
      })
		}
	}

	closeDetail() {
		this._dialogRef.close();
	}

	OnlyLettersAllowed(event: any): boolean {
		const charCode = event.which ? event.which : event.ketCode;
	  
		if (charCode > 64 && charCode < 91) return true;
		if (charCode > 96 && charCode < 123) return true;
		
		return false;
	    }
}
