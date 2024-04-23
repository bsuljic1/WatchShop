import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../shared/models/user.model';
import { Watch } from '../shared/models/watch.model';
import { WishList } from '../shared/models/wish-list.model';
import { UserService } from '../shared/services/user.service';
import { WatchService } from '../shared/services/watch.service';
import { WishListService } from '../shared/services/wish-list.service';

@Component({
  selector: 'app-wish-list',
  templateUrl: './wish-list.component.html',
  styleUrls: ['./wish-list.component.css'],
})
export class WishListComponent implements OnInit {
  wishLists: WishList[] = [];
  watches: Watch[] = [];
  page: number = 1;
  totalSize: number;
  currentUser: User = JSON.parse(localStorage.getItem('currentUser'));

  constructor(
    private watchService: WatchService,
    private router: Router,
    private wishListService: WishListService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.wishListService
      .getWishList(this.currentUser.userId)
      .subscribe((response: WishList[]) => {
        this.wishLists = response;

        this.watches = [];
        for (var c of this.wishLists) {
          this.watchService
            .getWatchById(c.watchId)
            .subscribe((response: Watch) => {
              var watch = response;
              this.watches.push(watch);
            });
        }
      });

    this.userService.currentUserEmitter.subscribe(
      (res) => (this.currentUser = res)
    );
  }

  delete(watch: Watch) {
    let wid = this.wishLists.filter(
      (w) => w.watchId == watch.watchId && w.userId == this.currentUser.userId
    )[0];
    this.wishListService
      .deleteFromWishList(wid.wishListId)
      .subscribe((res) => this.ngOnInit());
  }

  add() {
    this.router.navigateByUrl('/addProduct');
  }
}
