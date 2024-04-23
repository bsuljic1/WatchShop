import { Component, Input, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { Purchase } from '../shared/models/purchase.model';
import { User } from '../shared/models/user.model';
import { Watch } from '../shared/models/watch.model';
import { CartService } from '../shared/services/cart.service';
import { PurchaseService } from '../shared/services/purchase.service';
import { UserService } from '../shared/services/user.service';
import { WishListService } from '../shared/services/wish-list.service';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.css'],
})
export class ItemCardComponent implements OnInit {
  @Input() watch: Watch;
  currentUser: User = JSON.parse(localStorage.getItem('currentUser'));

  constructor(
    private cartService: CartService,
    private purchaseService: PurchaseService,
    private userService: UserService,
    private wishListService: WishListService
  ) {}

  ngOnInit(): void {
    this.userService.currentUserEmitter.subscribe(
      (res) => (this.currentUser = res)
    );
  }

  addToCart(watch: Watch) {
    this.cartService.addToCart(this.watch, 1);
  }

  buyNow(watch: Watch) {
    let p = new Purchase(
      '',
      this.watch.price + this.watch.shippingPrice,
      1,
      new Date(),
      '',
      this.watch.watchId
    );
    this.purchaseService.addToPurchases(p);
    Swal.fire({
      title: 'Product bought successfully!',
      text: 'Your purchase has been added to purchase history',
      icon: 'success',
    });
  }

  addToWishList() {
    this.wishListService.addToWishList(
      this.watch.watchId,
      this.currentUser.userId
    );
  }
}
