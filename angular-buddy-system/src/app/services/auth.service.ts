import { Injectable } from '@angular/core';
import { RegisterUser } from '../models/RegisterUser';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Token } from '../models/Token';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { APIURL } from 'src/environments/environment.prod';

const Api_Url = APIURL

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userInfo: Token;

  loggedIn: boolean;

  constructor(private http: HttpClient, private router: Router) { 
    if (localStorage.getItem('id_token')) {
      this.loggedIn = true;
    }
  }

  register(regUserData: RegisterUser) {
    return this.http.post(`${Api_Url}/api/Account/Register`, regUserData);
  }

  login(loginInfo) {
    const authString =
      `grant_type=password&username=${encodeURI(loginInfo.email)}&password=${encodeURI(loginInfo.password)}`;
    return this.http.post(`${Api_Url}/token`, authString).subscribe((token: Token) => {
      this.userInfo = token;
      localStorage.setItem('id_token', token.access_token);
      this.loggedIn = true;
      this.router.navigate(['/buddies/current-user']);
      console.log("JSux approves this Login");
    });
  }

    currentUser(): Observable<Object> {
      if (!localStorage.getItem('id_token')) {
        return new Observable(observer => observer.next(false));
        }

      return this.http.get(`$${Api_Url}/api/Account/UserInfo`, { headers: this.setHeaders() });
    }

    logout() {
      localStorage.removeItem('id_token');
      this.loggedIn = false;

      this.http.post(`${Api_Url}/api/Account/Logout`, { headers: this.setHeaders() });
      this.router.navigate(['/login']);
    }

    private setHeaders(): HttpHeaders {
      return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
    }
}
