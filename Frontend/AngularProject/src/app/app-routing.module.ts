import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AdminComponent } from './Admin/admin.component';
import { HomepageComponent } from './homepage/homepage.component';
import { MainPageComponent } from './main-page/main-page.component';
import { PatientPageComponent } from './patient-page/patient-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { DoctorspageComponent } from './doctor-page/doctor-page.component';
import { AuthGuard } from './service/auth.guard';


const routes: Routes = [
  {path:'',component:HomepageComponent},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'admin',component:AdminComponent},
  {path:'mainpage',component:MainPageComponent},
  {path:'login/mainpage',component:MainPageComponent},
  {path:'PatientPage',component:PatientPageComponent,canActivate:[AuthGuard], data:{roles:['Patient']}},
  {path:'AdminPage',component:AdminComponent, canActivate:[AuthGuard], data:{roles:['Admin']}},
  {path:'DoctorPage',component:DoctorspageComponent,canActivate:[AuthGuard], data:{roles:['Doctor']}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
