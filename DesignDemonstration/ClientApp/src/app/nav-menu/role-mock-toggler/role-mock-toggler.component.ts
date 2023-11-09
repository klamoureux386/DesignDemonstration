import { Component } from '@angular/core';
import { Role, UserService } from 'src/app/user.service';

@Component({
  selector: 'app-role-mock-toggler',
  templateUrl: './role-mock-toggler.component.html',
  styleUrls: ['./role-mock-toggler.component.scss']
})
export class RoleMockTogglerComponent {

  public isSelected: boolean = false;

  constructor(public userService: UserService) {

  }

  toggleUserRole() {
    this.isSelected = !this.isSelected;

    if (this.isSelected)
      this.userService.currentUserRole = Role.Admin;
    else
      this.userService.currentUserRole = Role.User;

  }

}