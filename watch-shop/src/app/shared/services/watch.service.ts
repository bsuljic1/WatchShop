import { Watch } from '../models/watch.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Filter } from '../models/filter.model';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class WatchService {
  constructor(private http: HttpClient, private router: Router) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getWatches() {
    return this.http.get(this.url + '/watch');
  }

  getWatchById(id: string) {
    const url = this.url + '/watch/' + id;
    return this.http.get<Watch>(url).pipe();
  }

  getWatchesByFilter(filter: Filter): Observable<Watch[]> {
    let filterParamsObject = {};

    if (filter.genderName != '')
      filterParamsObject['GenderName'] = filter.genderName;
    if (filter.brandName != '')
      filterParamsObject['BrandName'] = filter.brandName;
    if (filter.conditionName != '')
      filterParamsObject['ConditionName'] = filter.conditionName;
    if (filter.styleName != '')
      filterParamsObject['StyleName'] = filter.styleName;
    if (filter.colorName != '')
      filterParamsObject['ColorName'] = filter.colorName;
    if (filter.minPrice != 0) filterParamsObject['MinPrice'] = filter.minPrice;
    if (filter.maxPrice != 100000)
      filterParamsObject['MaxPrice'] = filter.maxPrice;
    if (filter.searchText != '')
      filterParamsObject['SearchText'] = filter.searchText;
    if (filter.sortBy != '') filterParamsObject['SortBy'] = filter.sortBy;

    return this.http.get<Watch[]>(this.url + '/watch/filter', {
      params: new HttpParams({ fromObject: filterParamsObject }),
    });
  }

  addWatch(watch: Watch) {
    console.log(watch);
    const url = this.url + '/watch';
    var obj = {
      model: watch.model,
      datePublished: watch.datePublished,
      braceletMaterial: watch.braceletMaterial,
      caseDiameter: watch.caseDiameter,
      waterResistant: watch.waterResistant,
      price: watch.price,
      shippingPrice: watch.shippingPrice,
      guarantee: watch.guarantee,
      imagePath: watch.imagePath,
      available: watch.available,
      brandId: watch.brand.brandId,
      colorId: watch.color.colorId,
      conditionId: watch.condition.conditionId,
      genderId: watch.gender.genderId,
    };

    Swal.fire({
      title: 'Do you want to save watch?',
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: 'Save',
      denyButtonText: `Don't save`,
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.post(url, obj).subscribe((response) => {});
        Swal.fire('Saved!', '', 'success');
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info');
      }
    });
  }

  deleteWatch(watch: Watch) {
    Swal.fire({
      title:
        'Are you sure you want to delete ' +
        watch.brand.brandName +
        ' ' +
        watch.model +
        '?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.http
          .delete(this.url + '/watch/' + watch.watchId)
          .subscribe((res) => {
            Swal.fire('Deleted!', 'Your file has been deleted.', 'success');
            this.router.navigateByUrl('/adminPanel');
          });
      }
    });
  }

  updateWatch(watchId: string, watch: Watch) {
    const url = this.url + '/watch/';
    var obj = {
      watchId: watch.watchId,
      model: watch.model,
      datePublished: watch.datePublished,
      braceletMaterial: watch.braceletMaterial,
      caseDiameter: watch.caseDiameter,
      waterResistant: watch.waterResistant,
      price: watch.price,
      shippingPrice: watch.shippingPrice,
      guarantee: watch.guarantee,
      imagePath: watch.imagePath,
      available: watch.available,
      brandId: watch.brand.brandId,
      colorId: watch.color.colorId,
      conditionId: watch.condition.conditionId,
      genderId: watch.gender.genderId,
    };

    console.log(watch);

    Swal.fire({
      title: 'Do you want to save the changes?',
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: 'Save',
      denyButtonText: `Don't save`,
    }).then((result) => {
      if (result.isConfirmed) {
        this.http
          .put<any>(url + watchId, obj)
          .subscribe((res) => Swal.fire('Saved!', '', 'success'));
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info');
      }
    });
  }
}
