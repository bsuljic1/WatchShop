import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { EventEmitter, Injectable, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { Privilege } from '../models/privilege.model';
import { Role } from '../models/role.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService implements OnInit {
  currentUser: User = JSON.parse(localStorage.getItem('currentUser'));
  currentUserEmitter: EventEmitter<User> = new EventEmitter();
  constructor(private http: HttpClient, private router: Router) {}
  ngOnInit(): void {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  addUser(user: User) {
    const url = this.url + '/user';
    var obj = {
      userFirstName: user.userFirstName,
      userLastName: user.userLastName,
      email: user.email,
      password: user.password,
      phone: user.phone,
      address: user.address,
    };

    return this.http.post(url, obj);
  }

  loginUser(email: string, password: string) {
    const url = this.url + '/user';
    let paramsObject = {};
    paramsObject['email'] = email;
    paramsObject['password'] = password;

    return this.http
      .get<User>(url, {
        params: new HttpParams({ fromObject: paramsObject }),
      })
      .subscribe((response) => {
        this.currentUser = response;

        let roleParams = {};
        roleParams['userId'] = this.currentUser.userId;
        this.http
          .get<Role>(url + '/role', {
            params: new HttpParams({ fromObject: roleParams }),
          })
          .subscribe((res) => {
            this.currentUser.role = res;

            let privilegeParams = {};
            privilegeParams['roleId'] = this.currentUser.role.roleId;
            this.http
              .get<Privilege[]>(url + '/privilege', {
                params: new HttpParams({ fromObject: privilegeParams }),
              })
              .subscribe((res) => {
                this.currentUser.privileges = res;
              });
            localStorage.setItem(
              'currentUser',
              JSON.stringify(this.currentUser)
            );
            this.currentUserEmitter.emit(this.currentUser);
            if (this.currentUser.role.roleName == 'Costumer')
              this.router.navigateByUrl('/');
            else this.router.navigateByUrl('/adminPanel');
          });
      });
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUser = null;
    this.currentUserEmitter.emit(this.currentUser);
    Swal.fire({
      title: 'Are you sure you want to logout?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, logout',
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire('You are logged out.');
      }
    });
    this.router.navigateByUrl('/');
  }
}
