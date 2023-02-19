import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
 readonly APIUrl="http://localhost:5069/api/Products" ;

  constructor(private http:HttpClient) { }

  ServiceMethodGetProductsList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl);


  }
}
