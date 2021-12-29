import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class FundActionService {
  
   url:any = localStorage.getItem("url");

  constructor(private service:HttpClient) { }

  insertFundDetail(request:any){
    return this.service.post(this.url, request);
  }

  updateFundDetail(request:any){
    return this.service.put(this.url+ '/' + request.id, request);
  }

  getFundDetailByID(id:any){
    return this.service.get(this.url + '/' + id);
  }
}
