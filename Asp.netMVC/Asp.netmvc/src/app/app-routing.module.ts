import { ProductsComponent } from './products/products.component';
import { LoginComponent } from './login/login.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './login/register/register.component';
import { VendorRegisterComponent } from './vendorlogin/vendor-register/vendor-register.component';
import { VendorloginComponent } from './vendorlogin/vendorlogin.component';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
const routes: Routes = [{
  path:'login' ,component:LoginComponent
}, {
  path:'register' ,
  component:RegisterComponent
},
{
path:'Products',
component:ProductsComponent
},
{
  path:'VendorRegister',
  component:VendorRegisterComponent
},
{
path:'Vendorlogin',
component:VendorloginComponent
},
{
path:'forgotpassword',
component:ForgotpasswordComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
