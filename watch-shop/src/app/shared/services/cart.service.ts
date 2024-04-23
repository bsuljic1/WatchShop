import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { Cart } from '../models/cart.model';
import { User } from '../models/user.model';
import { Watch } from '../models/watch.model';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private carts: Cart[];
  currentUser: User = JSON.parse(localStorage.getItem('currentUser'));
  constructor(private http: HttpClient, private userService: UserService) {
    this.userService.currentUserEmitter.subscribe(
      (res) => (this.currentUser = res)
    );
  }
  private watches: Watch[];

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getCarts() {
    let cartParamsObject = {};
    cartParamsObject['UserId'] = this.currentUser.userId;
    return this.http.get<Cart[]>(this.url + '/cart', {
      params: new HttpParams({ fromObject: cartParamsObject }),
    });
  }

  deleteWatchFromCart(cartId: string) {
    Swal.fire({
      title: 'Are you sure you want to remove item from cart?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire('Deleted!', 'Your file has been deleted.', 'success');
      }
    });

    return this.http.delete(this.url + '/cart/' + cartId);
  }

  addToCart(watch: Watch, quantity: number) {
    const url = this.url + '/cart';
    var obj = {
      totalPrice: watch.price,
      quantity: quantity,
      watchId: watch.watchId,
      userId: this.currentUser.userId,
    };

    this.http.post(url, obj).subscribe((response) => {
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Your watch has been added to cart',
        showConfirmButton: false,
        timer: 1500,
      });
    });
  }

  updateCartItem(cartId: string, quantity: number) {
    var obj = { CartId: cartId, Quantity: quantity };
    this.http.put<any>(this.url + '/cart', obj);
  }
}
