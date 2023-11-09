import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public currentUserRole: Role = Role.User;

  constructor() { }

  public get isAdmin(): boolean {
    return this.currentUserRole === Role.Admin
  }
}

export enum Role {
  User,
  Admin
}