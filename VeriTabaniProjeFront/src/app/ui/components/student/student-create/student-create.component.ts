import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { StudentService } from '../service/student.service';

import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { ValidInputDirective } from 'src/app/commons/directives/valid-input.directive';
import { MatDialogRef } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';

@Component({
  selector: 'app-student-create',
  standalone: true,
  imports: [CommonModule, FormsModule, ValidInputDirective, MatTabsModule],
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.css']
})
export class StudentCreateComponent implements OnInit{

  date: Date = new Date();

  selectedImage: string;

  departmentTypes: any[];
  selectedDepartmentType: number = -1;

  constructor(
    public _dialogRef: MatDialogRef<StudentCreateComponent>,
    private _service: StudentService,
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
    let model = new FormData();
    
    model.append('name', form.controls['name'].value);
    model.append('lastName', form.controls['lastName'].value);
    model.append('birthdate', form.controls['birthdate'].value);
    model.append('departmentId', form.controls['departmentId'].value);
    model.append('enrollmentDate', form.controls['enrollmentDate'].value ?
    form.controls['enrollmentDate'].value : this.date);
    model.append('photo', this.selectedImage);
    
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

  onFileSelected(event: any): void{
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => {
      this.selectedImage = reader.result as string;
    };
    reader.readAsDataURL(file);
  }

}
