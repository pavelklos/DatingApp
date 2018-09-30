import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  baseUrl = 'http://localhost:5000/api/auth/';

  // constructor() { }
  constructor(private http: HttpClient) { }

  // POST REQ : http://localhost:5000/api/auth/login
  // POST RES : "token":"...JWT...""
  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
          }
        })
      );
  }

  // POST REQ : http://localhost:5000/api/auth/register
  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  // getValues() {
  //   this.http.
  //     get('http://localhost:5000/api/values').
  //     subscribe(
  //       response => {
  //         this.values = response;
  //       },
  //       error => { console.log(error); }
  //     );
  // }

}

