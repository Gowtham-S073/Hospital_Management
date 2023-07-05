import { Component, OnInit } from '@angular/core';
import { SignupService } from 'src/app/service/signup.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { validPattern } from '../Helpers/patter-match.validator';
import { MustMatch } from '../Helpers/must-match.validator';
import { Status } from 'src/app/models/status';
import { ApiService } from '../service/api.service';
import { Router } from '@angular/router';
import { TempRequestModel } from '../models/TempRequestModel';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{

  constructor(private signupService: SignupService,private service :ApiService,
    private router:Router , private fb: FormBuilder) { }

  frm!: FormGroup;
  status!: Status;
  role!: any

  get f() {
    return this.frm.controls;
  }

  goToLoginPage() {
    this.router.navigate(['/login']);
  }
  public onPost(): void {

    if (this.role == 'Doctor') {
      this.status={statusCode:0,message:"Wait For Admin Approval"}
      this.signupService.temp(this.frm.value).subscribe({
        next:(res)=>{
          console.log(res)
          this.frm.reset()
        }
      })
    }
    else  {
      this.status = { statusCode: 0, message: "Please Fill All Details" };
      this.signupService.signup(this.frm.value).subscribe({
        next: (res) => {
          console.log(res);
          this.status = res;
          this.frm.reset();
        }
      })
    }
  }

  ngOnInit(): void {
    const patternRegex = new RegExp('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$');
    this.frm = this.fb.group({
      'name': ['', Validators.required],
      'email': ['', Validators.required],
      'username': ['', Validators.required],
      'roles': [''],
      'password': ['', [Validators.required, validPattern(patternRegex)]]
    }, {
    })
console.log(this.frm)
  }

  get nameVal() {
    return this.frm?.get('nameVal');
  }
  get password() {
    return this.frm?.get('password');
  }
}
