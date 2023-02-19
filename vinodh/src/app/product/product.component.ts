import { Component ,OnInit} from '@angular/core';
import { CDEServiceService } from 'src/app/cdeservice.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit{
constructor(private service:CDEServiceService){}
ProductsList:any=[];
ngOnInit():void{
  this.getProductsList();
}
getProductsList(){
  this.service.ServiceMethodGetProductList().subscribe(data=>{this.ProductsList=data;});
}
}
