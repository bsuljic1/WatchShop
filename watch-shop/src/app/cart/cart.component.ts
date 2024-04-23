import { Component, OnInit } from '@angular/core';
import { Cart } from '../shared/models/cart.model';
import { CartService } from '../shared/services/cart.service';
import { Watch } from '../shared/models/watch.model';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
  providers: [CartService],
})
export class CartComponent implements OnInit {
  cart: Cart[] = [];
  watches: any[] = [];
  totalPrice: number = 0;
  totalLength: number = 0;
  page: number = 1;

  constructor(
    private cartService: CartService,
    private watchService: WatchService
  ) {}

  ngOnInit(): void {
    this.cartService.getCarts().subscribe((response: Cart[]) => {
      this.cart = response;
      for (let c of this.cart) {
        this.watchService
          .getWatchById(c.watchId)
          .subscribe((response: Watch) => {
            let watch = response;
            watch['quantity'] = c.quantity;
            this.watches.push(watch);
            console.log(this.watches);
            this.totalPrice = this.totalPrice + watch.price * c.quantity;
          });
      }
      this.totalPrice = this.totalPrice + 5;
      this.totalLength = this.cart.length;
      this.page = 1;
    });
  }

  deleteWatchFromCart(watchId: string) {
    var c = this.cart.filter((c) => c.watchId == watchId)[0];
    this.cartService.deleteWatchFromCart(c.cartId).subscribe(() => {
      this.cartService.getCarts().subscribe((response: Cart[]) => {
        this.cart = response;
        this.watches = [];
        this.totalPrice = 0;
        for (var c of this.cart) {
          this.watchService
            .getWatchById(c.watchId)
            .subscribe((response: Watch) => {
              var watch = response;
              watch['quantity'] = c.quantity;
              this.watches.push(watch);
              this.totalPrice = this.totalPrice + response.price;
            });
        }
        this.totalLength = this.cart.length;
        if (this.totalLength != 0) this.totalPrice = this.totalPrice + 5;
      });
    });
  }

  updateCartItem(cartId: string, quantity: number) {
    this.cartService.updateCartItem(cartId, quantity);
  }
}
