import { Component, OnInit } from '@angular/core';
import { Purchase } from '../shared/models/purchase.model';
import { User } from '../shared/models/user.model';
import { Watch } from '../shared/models/watch.model';
import { PurchaseService } from '../shared/services/purchase.service';
import { UserService } from '../shared/services/user.service';
import { WatchService } from '../shared/services/watch.service';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.css'],
})
export class PurchaseHistoryComponent implements OnInit {
  purchases: Purchase[] = [];
  watches: any[] = [];
  page: number = 1;
  totalSize: number;

  constructor(
    private purchaseService: PurchaseService,
    private watchService: WatchService
  ) {}

  ngOnInit(): void {
    this.purchaseService.getPurchases().subscribe((response) => {
      this.purchases = response;
      this.totalSize = response.length;
      for (let p of this.purchases) {
        this.watchService
          .getWatchById(p.watchId)
          .subscribe((response: Watch) => {
            let watch = response;
            watch['quantity'] = p.quantity;
            watch['date'] = p.timeOfPurchase;
            this.watches.push(watch);
          });
      }
    });
  }
}
