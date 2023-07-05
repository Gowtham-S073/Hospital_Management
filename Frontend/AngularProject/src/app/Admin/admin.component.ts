import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/models/status';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../service/api.service';
import { ProtectedService } from '../service/protected.service';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { SignupService } from '../service/signup.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent {
  constructor(private api: ApiService,
    private formBuilder: FormBuilder,
    private signup: SignupService
  ) { }
  ngOnInit(): void {
    this.getAllDoctorDetails()
  }
  AddForm!: FormGroup
  DDoctors: any

  private getAllDoctorDetails(): void {
    this.api.GetDoctorTemp().subscribe(result => {
      this.DDoctors = result
    });
  }


  public Add(doctor: any): void {
    this.signup.signup(doctor).subscribe({
      next: (res) => {
        console.log(res);

      }
    });
    this.Deny(doctor)
  }

  public Deny(doctor: any): void {
    console.log(doctor)
    this.api.tempdelete(doctor.userName).subscribe((res) => {
      alert('Deleted');
    });
    window.location.reload();
  }
}




