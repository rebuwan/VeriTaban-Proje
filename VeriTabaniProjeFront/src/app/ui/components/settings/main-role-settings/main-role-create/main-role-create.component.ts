import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { RoleService } from 'src/app/commons/services/role.service';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { MainRoleCreateModel } from '../models/main-role-create.model';
import { StudentService } from '../../../student/service/student.service';

@Component({
  selector: 'app-main-role-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './main-role-create.component.html',
  styleUrls: ['./main-role-create.component.css']
})
export class MainRoleCreateComponent implements OnInit {

  departmentTypes: any[];
  selectedDepartmentType: number = -1;

  constructor(
    private _service: RoleService,
    private _dialogRef: MatDialogRef<MainRoleCreateComponent>,
    private _toastr: ToastrService,
    private _studentService: StudentService
  ){}

  ngOnInit(): void {
    this.getAllDepartmanTypes();
  }

  getAllDepartmanTypes() {
    this._studentService.getAllDepartment('', (res) => {
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

  create(form: NgForm){
    let model: MainRoleCreateModel = new MainRoleCreateModel();
    model.title = form.controls['title'].value;
    model.departmentId = form.controls['departmentId']?.value ?
    form.controls['departmentId'].value
    : null;

    this._service.createMainRole(model, res => {
      this._toastr.toast(ToastrType.Success, "Ekleme Başarılı", res.message)
				form.reset();
				this.closePopup();
    });
  }

  closePopup() {
		this._dialogRef.close();
	}

}
