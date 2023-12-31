import { BrowserModule, bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { provideHttpClient } from "@angular/common/http";
import { RouterModule } from '@angular/router';
import './assets/js/main.js';
import { AuthGuard } from './app/ui/components/auth/guard/auth.guard';
import { MatDialogModule } from '@angular/material/dialog';
import { provideAnimations } from '@angular/platform-browser/animations';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';


bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(),
    importProvidersFrom(BrowserModule, MatDialogModule,SweetAlert2Module.forRoot(), RouterModule.forRoot([
        {
            path: "",
            loadComponent: () => import("./app/ui/components/layouts/layouts.component").then(c => c.LayoutsComponent),
            canActivateChild: [AuthGuard],
            children: [
                {
                    path: "",
                    loadComponent: () => import("./app/ui/components/blank/blank.component").then(c => c.BlankComponent)
                },
                {
                    path: "student",
                    loadComponent: () => import("./app/ui/components/student/student.component").then(c => c.StudentComponent)
                },
                {
                    path: "course-for-student",
                    loadComponent: () => import("./app/ui/components/course-for-student/course-for-student.component").then(c => c.CourseForStudentComponent)
                },
                {
                    path: "student-courses",
                    loadComponent: () => import("./app/ui/components/course-for-student/courses/courses.component").then(c => c.CoursesComponent)
                },
                {
                    path: "course-for-staff",
                    loadComponent: () => import("./app/ui/components/course-for-staff/course-for-staff.component").then(c => c.CourseForStaffComponent)
                },
                {
                    path: "staff-courses",
                    loadComponent: () => import("./app/ui/components/course-for-staff/staff-course/staff-course.component").then(c => c.StaffCourseComponent)
                },
                {
                    path: "courses",
                    loadComponent: () => import("./app/ui/components/course/course.component").then(c => c.CourseComponent)
                },
                {
                    path: "main-role-settings",
                    loadComponent: () => import("./app/ui/components/settings/main-role-settings/main-role-settings.component").then(c => c.MainRoleSettingsComponent)
                },
                {
                    path: "user-settings",
                    loadComponent: () => import("./app/ui/components/settings/user-settings/user-settings.component").then(c => c.UserSettingsComponent)
                }
            ]
        },
        {
            path: "login",
            loadComponent: () => import("./app/ui//components/auth/login/login.component").then(c => c.LoginComponent)
        },
        {
            path: "register",
            loadComponent: () => import("./app/ui/components/auth/register/register.component").then(c => c.RegisterComponent)
        }
    ])),
    provideAnimations()
]
})
  

