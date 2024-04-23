import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Condition } from '../models/condition.model';

@Injectable({
  providedIn: 'root',
})
export class ConditionService {
  constructor(private http: HttpClient) {}

  url: string = environment.url;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getConditions() {
    return this.http.get(this.url + '/condition');
  }

  getConditionById(id: string) {
    const url = this.url + '/condition/' + id;
    return this.http.get<Condition>(url).pipe();
  }

  getConditionByName(name: string) {
    let conditionParamsObject = {};
    conditionParamsObject['name'] = name;
    return this.http
      .get<Condition>(this.url + '/condition/name/', {
        params: new HttpParams({ fromObject: conditionParamsObject }),
      })
      .pipe();
  }
}
