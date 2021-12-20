import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class FundActionService {
  
   url:any = localStorage.getItem("url");
   accessToken: any = localStorage.getItem("accesstoken");

  constructor(private service:HttpClient) { }

  insertFund(request:any){
    debugger;
    return this.service.post(this.url, request, { headers: { Authorization: 'Bearer ' + this.accessToken } })
  }
}
