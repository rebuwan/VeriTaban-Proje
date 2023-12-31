import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { SidebarRolesModel } from 'src/app/commons/models/all-role-models/sidebar-roles.model';
import { AllRoleChecksService } from 'src/app/commons/services/all-role-checks.service';
import { SettingRolesModel } from 'src/app/commons/models/all-role-models/setting-roles.model';


@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit{

  sidebarRoles: SidebarRolesModel = new SidebarRolesModel();
  settingRoles: SettingRolesModel = new SettingRolesModel();

  constructor(
    private _route: Router,
    private _roleService: AllRoleChecksService
  ){}

  ngOnInit(): void {
    this._roleService.getSidebarRole(this.sidebarRoles);
    this._roleService.getSettingRole(this.settingRoles);
  }


  cikisYap(){
    localStorage.removeItem("accessToken");
    this._route.navigate(['/login']);
  }

}
