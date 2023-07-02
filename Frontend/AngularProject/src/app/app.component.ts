import { AuthService } from './service/auth.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  title = 'AngularProject';
  roles="";
  isLoggedIn!:boolean;

  checkLoggedInUser(){
    this.isLoggedIn= this.authService.isLoggedIn();
    this.roles=this.authService.getUserRole();
  }
  logout(){
    this.authService.logout();
    this.Route.navigate(['/'])
  }
  constructor(private authService:AuthService, private Route:Router){
  }
}
