import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Condition } from '../models/condition.model';
import { Gender } from '../models/gender.model';

@Injectable({
  providedIn: 'root',
})
export class GenderService {
  constructor(private http: HttpClient) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getGenders() {
    return this.http.get(this.url + '/gender');
  }

  getGenderById(id: string) {
    const url = this.url + '/gender/' + id;
    return this.http.get<Gender>(url).pipe();
  }

  getGenderByName(name: string) {
    let genderParamsObject = {};
    genderParamsObject['name'] = name;
    return this.http
      .get<Gender>(this.url + '/gender/name/', {
        params: new HttpParams({ fromObject: genderParamsObject }),
      })
      .pipe();
  }
}
