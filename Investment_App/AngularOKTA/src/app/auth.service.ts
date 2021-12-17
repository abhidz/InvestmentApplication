import { Injectable } from '@angular/core';
import config from './config/app-config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string = '';

  constructor() { }

  authorize() {
    const authorizationUrl = this.getAuthorizationUrl();
    const redirectUri = location.protocol + "//" + location.host + "/callback";
    const nonce = `N${Math.random()}${Date.now()}`;
    const state = Date.now() + "" + Math.random();
    const url = authorizationUrl
      + "&redirect_uri=" +
      encodeURI(redirectUri) +
      "&nonce=" +
      encodeURI(nonce) +
      "&state=" +
      encodeURI(state);;
    window.location.href = url;
  }

  getAuthorizationUrl() {
    const authorizationUrl = config.oidc.issuer + "/v1/authorize";
    const clientId = config.oidc.clientId;
    const responseType = "id_token token";
    const scope = "email profile openid";
    return authorizationUrl +
      "?response_type=" +
      encodeURI(responseType) +
      "&client_id=" +
      encodeURI(clientId) +
      "&scope=" +
      encodeURI(scope);
  }
}
