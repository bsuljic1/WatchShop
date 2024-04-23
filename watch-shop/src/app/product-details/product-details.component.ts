import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Watch } from '../shared/models/watch.model';
import { CartService } from '../shared/services/cart.service';
import { WatchService } from '../shared/services/watch.service';
import { NgModel } from '@angular/forms';
import { PurchaseService } from '../shared/services/purchase.service';
import { Purchase } from '../shared/models/purchase.model';
import Swal from 'sweetalert2';
import { WishListService } from '../shared/services/wish-list.service';
import { UserService } from '../shared/services/user.service';
import { User } from '../shared/models/user.model';
import { Cart } from '../shared/models/cart.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
  providers: [WatchService],
})
export class ProductDetailsComponent implements OnInit {
  @Input() watch: Watch;
  @Input() id: string;

  quantityModel: number = 1;
  currentUser: User = JSON.parse(localStorage.getItem('currentUser'));
  constructor(
    private watchService: WatchService,
    private route: ActivatedRoute,
    private cartService: CartService,
    private purchaseService: PurchaseService,
    private wishListService: WishListService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
      this.watchService.getWatchById(this.id).subscribe((response: Watch) => {
        this.watch = response;
      });
    });
    this.userService.currentUserEmitter.subscribe(
      (res) => (this.currentUser = res)
    );
  }

  addToCart() {
    this.cartService.addToCart(this.watch, this.quantityModel);
  }

  buyNow() {
    let p = new Purchase(
      '',
      this.watch.price + this.watch.shippingPrice,
      this.quantityModel,
      new Date(),
      '',
      this.watch.watchId
    );
    this.purchaseService.addToPurchases(p).subscribe((res) => {
      Swal.fire({
        title: 'Product bought successfully!',
        text: 'Your purchase has been added to purchase history',
        icon: 'success',
      });
    });
  }

  addToWishList() {
    this.wishListService.addToWishList(
      this.watch.watchId,
      this.currentUser.userId
    );
  }
}
