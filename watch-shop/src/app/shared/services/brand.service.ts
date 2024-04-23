import { Injectable } from '@angular/core';
import { Brand } from '../models/brand.model';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class BrandService {
  constructor(private http: HttpClient) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getBrands() {
    return this.http.get(this.url + '/brand');
  }

  getBrandById(id: string) {
    const url = this.url + '/watch/' + id;
    return this.http.get<Brand>(url).pipe();
  }

  getBrandByName(name: string) {
    console.log(name);
    let brandParamsObject = {};
    brandParamsObject['name'] = name;
    return this.http
      .get<Brand>(this.url + '/brand/name/', {
        params: new HttpParams({ fromObject: brandParamsObject }),
      })
      .pipe();
  }
}
