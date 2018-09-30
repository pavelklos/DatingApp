import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  // login() {
  //   // console.log(this.model);
  //   const logInfo = ' [' + this.model.username + ':' + this.model.password + ']';
  //   this.authService.login(this.model).subscribe(next => {
  //     console.log('Logged in successfully' + logInfo);
  //   }, error => {
  //     console.log(error);
  //      // error => { console.log('Failed to login' + logInfo); });
  //   });
  // }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // true or false
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    });
  }
}

