import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { customerComponent } from './customer/customer.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
