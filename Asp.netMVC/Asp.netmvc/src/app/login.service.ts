import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';  
import {Observable} from 'rxjs';
import { LoginComponent } from './login/login.component';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
 readonly apiurl="http://localhost:5069/api/Token"
 
  /*constructor(private http:HttpClient) {
    servicemethodgetLoginList():Observable<any[]>{
    return this.http.post('this.Apiurl')
  
  }
}*/
}



