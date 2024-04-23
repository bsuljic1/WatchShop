import { state } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from '../shared/models/cart.model';
import { Purchase } from '../shared/models/purchase.model';
import { Watch } from '../shared/models/watch.model';
import { CartService } from '../shared/services/cart.service';
import { PurchaseService } from '../shared/services/purchase.service';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  cart: Cart[];
  watches: any[];
  totalPrice: number;
  totalLength: number;
  page: number = 1;

  constructor(
    private purchaseService: PurchaseService,
    private cartService: CartService,
    private router: Router,
    private watchService: WatchService
  ) {}

  ngOnInit(): void {
    this.cart = history.state.cart;
    this.watches = history.state.watches;
    this.totalPrice = history.state.totalPrice;
    this.totalLength = history.state.totalLength;
    console.log(this.cart);
    console.log(this.watches);
  }

  checkout() {
    for (let c of this.cart) {
      var p = new Purchase(
        '',
        c.totalPrice,
        c.quantity,
        new Date(),
        '',
        c.watchId
      );
      this.purchaseService.addToPurchases(p).subscribe(() => {
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
      });
    }

    this.router.navigateByUrl('/purchase/history');
  }
}
