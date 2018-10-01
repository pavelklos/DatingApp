import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  // @Input() now: any;
  now: any;

  constructor(public authService: AuthService, private alertify: AlertifyService) {
    setInterval(() => {
      this.now = Date.now();
    }, 1);
  }

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

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
      this.alertify.success('Logged in successfully');
    }, error => {
      console.log(error);
      this.alertify.error(error);
    });
  }

  loggedIn() {
    // const token = localStorage.getItem('token');
    // return !!token; // true or false
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
    this.alertify.message('Logged out');
  }
}

