import { ProductFormComponent } from './product-form.component';
import { ProductService } from './product.service';
import { HomeComponent } from './../home/home.component';
import { NgModule }            from '@angular/core';
import { CommonModule }        from '@angular/common';
import { FormsModule, 
         ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule }        from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { PreventUnsavedChangesGuard, FormComponent } from './../prevent-unsaved-changes-guard.service';
import { ProductComponent } from './../product/product.component';
import { ProductRouting } from './product.routing';
import { UomService } from '../uom/uom.service';
import { ProductCategoryService } from '../productcategory/productcategory.service';

@NgModule({
   declarations: [
    ProductComponent,
    ProductFormComponent
   
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
     
  ],
  exports: [
  ProductComponent,
  ProductFormComponent

  ],
  providers: [
    PreventUnsavedChangesGuard,
    ProductService,
    UomService,
    ProductCategoryService
  ]
 
})
export class ProductModule { }
