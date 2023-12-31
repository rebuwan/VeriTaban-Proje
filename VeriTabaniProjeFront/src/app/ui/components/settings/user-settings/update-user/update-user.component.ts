import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrService, ToastrType } from 'src/app/commons/services/toastr.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { UserService } from '../services/user.service';
import { FormsModule, NgForm } from '@angular/forms';
import { ValidInputDirective } from 'src/app/commons/directives/valid-input.directive';
import { UserModel } from '../models/user.model';

@Component({
  selector: 'app-update-user',
  standalone: true,
  imports: [CommonModule,FormsModule,ValidInputDirective],
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent {
  date: Date = new Date();

  selectedImage: string;

  departmentTypes: any[];
  selectedDepartmentType: number = -1;
  User : UserModel = new UserModel();

  constructor(
    public _dialogRef: MatDialogRef<UpdateUserComponent>,
    private _service: UserService,
    private _toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.User = data.model;
      this.selectedImage = "https://localhost:7235" + this.User.photo;
  }

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

  update(form: NgForm) {	
    let model = new FormData();
    
    model.append("id",this.User.id);
    model.append("userId",this.User.userId);
    model.append('name', form.controls['name'].value);
    model.append('lastName', form.controls['lastName'].value);
    model.append('birthdate', form.controls['birthdate'].value);
    model.append('departmentId', form.controls['departmentId'].value);
    model.append('photo', this.selectedImage);
    
		if (form.valid) {
      this._service.update(model, res => {
        this._toastr.toast(ToastrType.Success, 'Ekleme Başarılı', res.message);
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
