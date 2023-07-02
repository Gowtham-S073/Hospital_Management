import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Status } from '../models/status';


@Injectable({
  providedIn: 'root'
})
export class ProtectedService {
  //private baseUrl=environment.baseUrl;
  constructor(private http:HttpClient) { }
  
  getUserData(){
    return this.http.get<Status>(`https://localhost:7118/api/protected/getdata`);
  }

  getAdminData(){
    return this.http.get<Status>(`https://localhost:7118/api/Admin`);
  }

}