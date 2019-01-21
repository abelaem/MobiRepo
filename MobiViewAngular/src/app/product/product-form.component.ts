import { ProductCategoryService } from './../productcategory/productcategory.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute }                from '@angular/router';

import { uom} from '../Domain/uom'
import { Product } from './../Domain/product';
import { FormGroup, FormBuilder, FormControl, RequiredValidator, Validators } from '@angular/forms';
import { ProductService } from './product.service';
import { UomService } from './../uom/uom.service';
import {CustomValidator} from '../shared/validator'




@Component(
{
    selector:'productForm',
    templateUrl:"../product/product-form.component.html"


})
export class ProductFormComponent implements OnInit {
    form:FormGroup
    product:any
    title:string
    id:number
    uoms:any
    productcategorys:any
    constructor(
        private _service:ProductService,
        private fm:FormBuilder,
        private _router: Router,
        private _route: ActivatedRoute,
        private _productService:ProductService,
        private _uomService:UomService,
        private _productcategory:ProductCategoryService
       
        ){

        this.product=new Product()

         this.form=fm.group({
        'Id':new FormControl(""),
        'Name':new FormControl("",Validators.required),
        'Quantity':new FormControl("",[Validators.required,Validators.pattern("^[0-9]*$")]),
        'ProductCategoryId':new FormControl("",Validators.required),
        'ProductCategory':new FormControl("",Validators.required),
        'UOMId':new FormControl("",Validators.required),
        'UOM':new FormControl("",Validators.required),
      
        }
       
        
        )
     
    }

    ngOnInit(){
        this._route.params.subscribe(params => {
            this.id = +params["id"];
            this.title = this.id ? "Edit Product" : "New Product";
        
        if (!this.id)
			return;
            
        this._productService.getUser(this.id)
			.subscribe(
                response => {
                    this.product=response
                   
                });
        });
        
        this._uomService.getUoms()
            .subscribe(
                response=> { 
                    
                     this.uoms=response
                    
                })


        this._productcategory.getUoms()
            .subscribe(response=>{
                    
                      this.productcategorys=response
                    
            })

    }
    
   
    save()
    {   
        console.log(this.form)
        
        
        if(this.id)
        {
            this.product=this.form.value
            this._service.updateUser(this.product).subscribe(responce=>{
            this._router.navigate(['products']);
            },
            err=>{
            this._router.navigate["not-found"]
            })
        }
        
          
        else{
            this._service.addUser(this.form.value).subscribe(responce=>{
            this._router.navigate(['products']);
            },
            err=>{
                 this._router.navigate["not-found"]
            })
        } 
    }
   
}