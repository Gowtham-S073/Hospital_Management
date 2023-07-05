import { AuthService } from './service/auth.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  menuOpen = false;

  toggleMenu(): void {
    this.menuOpen = !this.menuOpen;
  }

  title = 'AngularProject';
  role: string = localStorage.getItem('role') || '';
isLoggedIn!:boolean;


logout(){

  localStorage.removeItem("token");
  localStorage.removeItem("role");
  localStorage.removeItem("username");
  sessionStorage.removeItem('docName');
  sessionStorage.removeItem('Name');
  this.Route.navigate(['/']).then(() => {
    // Optional: Scroll to the top of the page
    window.scrollTo(0, 0);
    location.reload();

  });

}
  constructor(private authService:AuthService, private Route:Router){
  }
}
