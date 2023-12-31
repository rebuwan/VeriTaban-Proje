import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ValidInputDirective } from 'src/app/commons/directives/valid-input.directive';
import { StudentService } from '../service/student.service';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { StudentUpdateModel } from '../models/student-update.model';


@Component({
  selector: 'app-student-update',
  standalone: true,
  imports: [CommonModule, FormsModule, ValidInputDirective],
  templateUrl: './student-update.component.html',
  styleUrls: ['./student-update.component.css']
})
export class StudentUpdateComponent implements OnInit {

  date: Date = new Date();

  selectedImage: string;

  departmentTypes: any[];
  selectedDepartmentType: any;

  updateModel: any;

  constructor(
    private _dialogRef: MatDialogRef<StudentUpdateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _service: StudentService,
    private _toastr: ToastrService
  ){
    this.updateModel = data.model;
    this.selectedImage = "https://localhost:7235" + this.updateModel.photoUrl;
    console.log(this.updateModel);
  }

  ngOnInit(): void {
    this.getAllDepartmanTypes();
    this.selectedDepartmentType = this.updateModel.departmentId;
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

  update(form: NgForm){
    let model = new StudentUpdateModel();

    // model.append("id", this.updateModel.id);
    // model.append("name", form.controls["name"].value);
    // model.append("lastName", form.controls["lastName"].value);
    // model.append("ddepartmentId", form.controls["departmentId"].value);
    // model.append("birthdate", form.controls["birthdate"].value);
    // model.append("enrollmentDate", form.controls["enrollmentDate"].value);

    model.departmentId = form.controls["departmentId"].value;
    model.id = this.updateModel.id;
    model.name = form.controls["name"].value;
    model.lastName = form.controls["lastName"].value;

    if (form.valid) {
      this._service.update(model, res => {
        this._toastr.toast(ToastrType.Success, 'Ekleme Başarılı', res.message);
        form.reset();
        this.closeDetail();
      });
		}
  }


  closeDetail() {
		this._dialogRef.close();
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
