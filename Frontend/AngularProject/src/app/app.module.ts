import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {  FormGroup, FormsModule , ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { UserComponent } from './user/user.component';
import { AdminComponent } from './Admin/admin.component';
import { HomepageComponent } from './homepage/homepage.component';
import { MainPageComponent } from './main-page/main-page.component';
import { PatientPageComponent } from './patient-page/patient-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { DoctorspageComponent } from './doctor-page/doctor-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    UserComponent,
    AdminComponent,
    HomepageComponent,
    MainPageComponent,
    PatientPageComponent,
    AdminPageComponent,
    DoctorspageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
  
}
