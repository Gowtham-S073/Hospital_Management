import { Component } from '@angular/core';
import { Status } from '../models/status';
import { ProtectedService } from 'src/app/service/protected.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  status!:Status;
  constructor(private protectedService:ProtectedService) { 
    // we will intercept each request and append httpHeader with accesstoken in each request,with the help of HttpInterceptor

  }


  ngOnInit(): void {
    this.protectedService.getUserData().subscribe({
      next: (res)=>{
       this.status=res;
      },
      error: (err)=>{
        console.log(err);      }
    })
  }
}
