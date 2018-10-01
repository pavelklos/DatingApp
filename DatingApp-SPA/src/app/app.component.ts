import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'DatingApp-SPA';
  now: number;
  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService) {
    setInterval(() => {
      this.now = Date.now();
    }, 1);
  }

  ngOnInit(): void {
    const token = localStorage.getItem('token');
    this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    if (this.authService.loggedIn()) {
      this.authService.expirationDate = this.jwtHelper.getTokenExpirationDate(token);
    }
  }
}
