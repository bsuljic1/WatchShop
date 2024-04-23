import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Color } from '../models/color.model';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  constructor(private http: HttpClient) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getColors() {
    return this.http.get(this.url + '/color');
  }

  getColorById(id: number) {
    const url = this.url + '/color/' + id;
    return this.http.get<Color>(url).pipe();
  }

  getColorByName(name: string) {
    let colorParamsObject = {};
    colorParamsObject['name'] = name;
    return this.http
      .get<Color>(this.url + '/color/name/', {
        params: new HttpParams({ fromObject: colorParamsObject }),
      })
      .pipe();
  }
}
