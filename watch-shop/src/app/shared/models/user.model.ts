import { Privilege } from './privilege.model';
import { Role } from './role.model';

export class User {
  public userId: string;
  public userFirstName: string;
  public userLastName: string;
  public email: string;
  public password: string;
  public phone: string;
  public address: string;
  public role: Role;
  public privileges: Privilege[] = [];

  constructor(
    userId: string,
    userFirstName: string,
    userLastName: string,
    email: string,
    password: string,
    phone: string,
    address: string
  ) {
    this.userId = userId;
    this.userFirstName = userFirstName;
    this.userLastName = userLastName;
    this.email = email;
    this.password = password;
    this.phone = phone;
    this.address = address;
  }
}
