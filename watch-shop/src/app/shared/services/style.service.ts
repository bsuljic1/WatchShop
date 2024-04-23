import { Style } from '../models/style.model';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StyleService {
  constructor(private http: HttpClient) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getStyles() {
    return this.http.get(this.url + '/style');
  }

  getStyleById(id: string) {
    const url = this.url + '/style/' + id;
    return this.http.get<Style>(url).pipe();
  }
}
