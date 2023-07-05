import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../service/api.service';
import { AuthService } from '../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent {
  public AddForm!: FormGroup;
  roles="";
  isLoggedIn!:boolean;

  constructor(private formBuilder: FormBuilder, private authService:AuthService, private Route:Router, private api: ApiService) {}

  ngOnInit(): void {
    this.init();
  }

  private init(): void {
    this.AddForm = this.formBuilder.group({
      doctorname: [],
      sex: [],
      specialization: [],
      experience: [],
      phoneNumber: []
    });
  }

  public Add(): void {
    console.log(this.AddForm);
    this.api.PostDoctorDetails(this.AddForm.value).subscribe((result) => {
      alert('Added Successfully');
    });
  }
}
