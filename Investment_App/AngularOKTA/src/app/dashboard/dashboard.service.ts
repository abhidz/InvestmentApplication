import { Injectable } from '@angular/core';
import config from '../config/app-config';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  url: string = '';

  constructor(private router: Router, private http: HttpClient) { }

  private getEncodedHashValue(): any {
    return encodeURIComponent(window.location.hash.substring(1));
  }
  private getDecodedHashValue(encodedHashValue: string): any {
    return decodeURIComponent(encodedHashValue);
  }

  authorizeCallback() {
    const encodedhash = this.getEncodedHashValue();
    const hash = this.getDecodedHashValue(encodedhash);

    const result = hash.split("&")
      .reduce((rslt: { [x: string]: any; }, item: string) => {
        const parts = item.split("=");
        rslt[parts[0]] = parts[1];
        return rslt;
      },
        {});
    if (result != undefined && result.access_token != null) {
      const accessToken = result.access_token;
      this.url = config.oidc.apiBaseUrl2 + '/api/FundDetail';
      return this.http.get(this.url, { headers: { Authorization: 'Bearer ' + accessToken } });
    }
    else {
      return result;
    }
  }
}
