import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Status } from 'src/app/models/status';
import { SignupService } from 'src/app/service/signup.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  frm!: FormGroup;
  status!: Status;

  get f() {
    return this.frm.controls;  
  }


  constructor(private signupService: SignupService, private fb: FormBuilder,
    private authService: AuthService, private router: Router
  ) { }

  onPost() {
    this.status = { statusCode: 0, message: "wait...." };
    this.signupService.login(this.frm.value).subscribe({
      next: (res) => {
        console.log(res);
        localStorage.setItem("token",res.token);
        localStorage.setItem("role",res.roles);
        localStorage.setItem("name", res.username);

        this.status.statusCode = res.statusCode;
        this.status.message = res.message;
        this.roles=res.roles;

        if(this.roles=="Admin")
        { 
          console.log(this.roles)
          this.router.navigate(['/mainpage']);
        }
       
        else if(this.roles=="Patient")
        {
          this.router.navigate(['/mainpage']);
        }
        if (res.statusCode == 1) {
          this.router.navigate(['/mainpage']).then(() => {
            window.scrollTo(0, 0);
            location.reload();
          })}
        
      },
      error: (err) => {
        console.log(err);
        this.status.statusCode = 0;
        this.status.message = "some error on server side";
      }
    })
  }

  ngOnInit(): void {
    this.frm = this.fb.group({
      'username': ['', Validators.required],
      'password': ['', Validators.required]
    })

  }

  log(): void {

  }


  roles:any
  isLoggedIn!: boolean;

}