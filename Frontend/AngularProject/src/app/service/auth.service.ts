import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from "@auth0/angular-jwt"; 
import { RefreshTokenRequest } from '../models/refresh-token-request';
import { TokenService } from '../service/token.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/internal/operators/tap';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor(private http: HttpClient,private router : Router) { }
  signIn(Id: string, password: string) {
    const signInData = { Id, password };
    
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text' as 'json'  // Treat the response as plain text
    };

    return this.http.post<string>('https://localhost:7033/api/Authorization/Login', signInData, httpOptions)
      .pipe(
        
        tap((jwtToken) => {
          localStorage.setItem('jwtToken', jwtToken);
        //   localStorage.setItem('role',role);
        })
      );
  }
  
  

  getToken()
  {
    return localStorage.getItem('token');
  }

  
  logout(){
     localStorage.removeItem("username");
     localStorage.removeItem("token");
     localStorage.removeItem("roles");
     this.router.navigate(['']);
  }

  // constructor(private router:Router,private tokenService:TokenService) { }

  // isLoggedIn(){
  //   return !!this.getAccessToken() && !this.isTokenExpired()
  // }

  // addUsername(username:string){
  //   localStorage.setItem('username',username);
  // }

  // addAccessToken(accessToken:string){
  //   localStorage.setItem('accessToken',accessToken);
  // }


  // addRefreshToken(refToken:string){
  //   localStorage.setItem('refreshToken',refToken);
  // }

  // getAccessToken(){
  //   return localStorage.getItem('accessToken');
  // }

  // getUsername(){
  //   return localStorage.getItem('username');
  // }

  // getRefreshToken(){
  //   return localStorage.getItem('refreshToken');
  // }

  // // check expiration of our token
  // isTokenExpired(){
  //   const token: string=this.getAccessToken()??"";
  //       if(!token)
  //         return false;
  //       const tokenSplit:string=token.split('.')[1];
  //       const decodedString:string=atob(tokenSplit);
  //       const jsonString=JSON.parse(decodedString);
  //       const expiry = (jsonString).exp;
  //       return (Math.floor((new Date).getTime() / 1000)) >= expiry;

  // }
  
  // logout(){
  //    localStorage.removeItem("username");
  //    localStorage.removeItem("accessToken");
  //    localStorage.removeItem("refreshToken");
  //    this.router.navigate(['/login']);
  // }

  // getUserRole(){
  //   const helper = new JwtHelperService();
  //   const decodedToken = helper.decodeToken(this.getAccessToken()??"");
  //   if(decodedToken){
  //   const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

  //   console.log(role);
  //   return role; 
  //   }
  //   return "";
  // }

  // // refreshing the access token
  // async refreshingToken():Promise<boolean>{
  //   const token = this.getAccessToken();
  //   const refreshToken = this.getRefreshToken();
  //   if(!token || !refreshToken){
  //      return false;
  //   }
  //   let success!:boolean;
  //   const data:RefreshTokenRequest={accessToken:token,refreshToken:refreshToken};

  //   this.tokenService.generateRefreshToken(data).subscribe({
  //      next: (response)=>{
  //         this.addAccessToken(response.accessToken);
  //         this.addRefreshToken(response.refreshToken);
  //      },
  //      error: (error)=>{
  //       console.log(error);
  //       success=false;
  //      }
  //   });
  //   return success;
  // }

}