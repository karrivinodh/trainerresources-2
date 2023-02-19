import { Component } from '@angular/core';
import { LoginService } from '../../login.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
constructor(private loginService: LoginService) { }
LoginList:any=[];
ngOnInit() :void {
 
}

}
