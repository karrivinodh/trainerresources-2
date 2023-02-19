import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit  {
  constructor(private _productsService: ProductsService) {
   
    
  }
  ProductsList :any= [];
  ngOnInit(): void {
    this.getProductsList();
  }
  getProductsList() {
      this._productsService.ServiceMethodGetProductsList().subscribe(data=>{this.ProductsList = data});  

}
}
