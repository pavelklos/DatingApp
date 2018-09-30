import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

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
  constructor(private authService: AuthService) {}

  ngOnInit() {
  }

  register() {
    // console.log(this.model);
    const logInfo = ' [' + this.model.username + ':' + this.model.password + ']';
    // console.log('Register' + logInfo);
    this.authService
      .register(this.model)
      .subscribe(
        () => { console.log('Registration successfull' + logInfo); },
        error => { console.log('Error' + logInfo); });
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled');
  }

}
