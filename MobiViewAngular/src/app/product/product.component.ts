import { Product } from './../Domain/product';
import { ProductService } from './product.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: '../product/product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products:any;
  constructor(private _service:ProductService) {

   
   }
 
  ngOnInit() {
    this._service.getUsers().subscribe(
      product => {this.products = product}
    )
   
  }

  deleteProduct(productItme:Product)
  {
    var index=this.products.indexOf(productItme)
    if (confirm("Are you sure you want to delete " + productItme.Name + "?"))
    {
   this._service.deleteUser(productItme.Id).subscribe(
     responce => {
       this.products.splice(index,1);
      
      },
     err => {
      alert("Could not delete the Product.");
     }
   )
  }
}
}
