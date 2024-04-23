import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { User } from '../shared/models/user.model';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService],
})
export class LoginComponent implements OnInit {
  login: boolean;

  currentUser: User = null;

  //login form
  emailLogin: string;
  passwordLogin: string;

  //register form
  name: string;
  email: string;
  password: string;
  phone: string;
  address: string;

  constructor(private router: Router, private userService: UserService) {
    if (this.router.url == '/login') {
      this.login = true;
    } else {
      this.login = false;
    }
  }

  ngOnInit(): void {
    this.currentUser = this.userService.currentUser;
  }

  register() {
    let user = new User(
      '',
      this.name.split(' ')[0],
      this.name.split(' ')[1],
      this.email,
      this.password,
      this.phone,
      this.address
    );
    this.userService.addUser(user).subscribe((res) => {
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'You are registered',
        showConfirmButton: false,
        timer: 1500,
      });
      this.router.navigateByUrl('/products');
    });
  }

  signIn() {
    console.log(this.emailLogin, this.passwordLogin);
    this.userService.loginUser(this.emailLogin, this.passwordLogin);
    this.ngOnInit();
  }
}
