import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Purchase } from '../models/purchase.model';
import { User } from '../models/user.model';
import { Watch } from '../models/watch.model';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class PurchaseService {
  private purchases: Purchase[];
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

  getPurchases() {
    let purchasesParamsObject = {};
    purchasesParamsObject['UserId'] = this.currentUser.userId;
    return this.http.get<Purchase[]>(this.url + '/purchase', {
      params: new HttpParams({ fromObject: purchasesParamsObject }),
    });
  }

  addToPurchases(purchase: Purchase) {
    const url = this.url + '/purchase';

    var obj = {
      purchasePrice: purchase.purchasePrice,
      quantity: purchase.quantity,
      timeOfPurchase: purchase.timeOfPurchase,
      userId: this.currentUser.userId,
      watchId: purchase.watchId,
    };

    return this.http.post(url, obj);
  }
}
