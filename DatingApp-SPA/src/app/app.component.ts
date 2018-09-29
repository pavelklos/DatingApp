import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DatingApp-SPA';
  now: number;

  constructor() {
    setInterval(() => {
      this.now = Date.now();
    }, 1);
  }
}
