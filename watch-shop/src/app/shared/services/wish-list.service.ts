import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { WishList } from '../models/wish-list.model';
import Swal from 'sweetalert2';
@Injectable({
  providedIn: 'root',
})
export class WishListService {
  constructor(private http: HttpClient) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getWishList(userId: string) {
    const url = this.url + '/wishList/' + userId;
    return this.http.get<WishList[]>(url).pipe();
  }

  addToWishList(wId: string, uId: string) {
    var obj = {
      wishListId: '',
      watchId: wId,
      userId: uId,
    };
    console.log(obj);
    return this.http
      .post<WishList>(this.url + '/wishList', obj, this.httpOptions)
      .pipe()
      .subscribe((res) => console.log(res));
  }

  deleteFromWishList(wishListId: string) {
    return this.http.delete(this.url + '/wishList' + wishListId);
  }
}
