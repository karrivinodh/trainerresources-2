import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CDEServiceService {
  readonly APIUrl="http://localhost:5092/api/Products";

  constructor(private http:HttpClient) { }

  ServiceMethodGetProductList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl);


  }
}
