import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../../_models/user';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  users: User[];

  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    // this.loadUsers();
    // ROUTE RESOLVER - delete loadUsers()

        // this.loadUser();
    // ROUTE RESOLVER - delete loadUser()
    this.route.data.subscribe(data => {
      this.users = data['users'];
      this.alertify.success(Object.keys(this.users).length + ' users loaded.');
    });
  }

  // members
  // loadUsers() {
  //   this.userService.getUsers().subscribe((users: User[]) => {
  //     this.users = users;
  //     this.alertify.success(Object.keys(this.users).length + ' users loaded.');
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }
}
