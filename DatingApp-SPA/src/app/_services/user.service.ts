import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

// SERVER ERROR : 401 after Login -> Members
// const httpOptions = {
//   headers: new HttpHeaders({
//     'Authorization': 'Bearer ' + localStorage.getItem('token')
//   })
// };
// SERVER ERROR : 401 after Login -> Members

@Injectable({
  providedIn: 'root'
})

export class UserService {

  // baseUrl = 'http://localhost:5000/api/users/';
  // baseUrl = environment.apiUrl + 'users/';
  baseUrl = environment.apiUrl;

  // constructor() { }
  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    // return this.http.get<User[]>(this.baseUrl + 'users', httpOptions);
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  getUser(id): Observable<User> {
    // return this.http.get<User>(this.baseUrl + 'users/' + id, httpOptions);
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

}
