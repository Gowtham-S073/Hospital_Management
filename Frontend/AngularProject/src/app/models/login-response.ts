import { Status } from "./status";

export interface LoginResponseModel extends Status{
     token:string, 
         refreshToken :string,
         expiration:string,
         name:string,
         username :string
}