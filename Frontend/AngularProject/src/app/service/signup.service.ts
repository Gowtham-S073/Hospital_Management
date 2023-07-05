import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChangePasswrd } from '../models/change-password';
import { LoginResponseModel } from '../models/login-response';
import { LoginRequestModel } from '../models/login-requestmodel';
import { SignupRequestModel } from '../models/signup-request-model';
import { Status } from '../models/status';
import { TempRequestModel } from '../models/TempRequestModel';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  
  constructor(private http:HttpClient) { 

  }

  login(model:LoginRequestModel){
  return this.http.post<LoginResponseModel>(`https://localhost:7118/api/Authorization/Login`,model);
  }

  signup(model:SignupRequestModel){
     return this.http.post<Status>(`https://localhost:7118/api/Authorization/Registration`,model);
  }

  temp(model:TempRequestModel){
    return this.http.post<Status>(`https://localhost:7118/api/DoctorTemp`,model);
  }

  chagePassword(model:ChangePasswrd){
    return this.http.post<Status>(`https://localhost:7118/api/Authorization/ChangePassword`,model);
    }

}