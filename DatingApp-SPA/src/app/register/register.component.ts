import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  model: any = {};
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();

  // constructor() { }
  constructor(private authService: AuthService, private alertify: AlertifyService) {}

  ngOnInit() {
  }

  register() {
    // const logInfo = ' [' + this.model.username + ':' + this.model.password + ']';
    // this.authService.register(this.model).subscribe(() => {
    //   console.log('Registration successful' + logInfo);
    // }, error => { console.log(error + logInfo); });

    this.authService.register(this.model).subscribe(() => {
      console.log('Registration successful');
      this.alertify.success('Registration successful');
    }, error => {
      console.log(error);
      this.alertify.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled');
    this.alertify.message('Cancelled');
  }
}
