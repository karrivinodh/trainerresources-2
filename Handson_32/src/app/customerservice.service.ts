import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CustomerserviceService {

  readonly APIUrl="http://localhost:5257/api/TblCustomers";
  constructor(private http:HttpClient) { }

  ServiceMethodGetCustomerList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl);
  }
}
