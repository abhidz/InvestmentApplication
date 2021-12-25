import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class FundActionService {
  
   url:any = localStorage.getItem("url");
   accessToken: any = localStorage.getItem("accesstoken");

  constructor(private service:HttpClient) { }

  insertFundDetail(request:any){
    return this.service.post(this.url, request, { headers: { Authorization: 'Bearer ' + this.accessToken } })
  }

  updateFundDetail(request:any){
    debugger;
    return this.service.put(this.url+ '/' + request.id, request, { headers: { Authorization: 'Bearer ' + this.accessToken } })
  }

  getFundDetailByID(id:any){
    return this.service.get(this.url + '/' + id,{ headers: { Authorization: 'Bearer ' + this.accessToken } });
  }
}
