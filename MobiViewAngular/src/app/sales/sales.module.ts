import { SalesService } from './sales.service';
import { SalesComponent } from './sales.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule, FormBuilder } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { ProductFormComponent } from '../product/product-form.component';
import { ProductComponent } from '../product/product.component';
import { SalesforomComponent } from './salesforom.component';
import { sales } from '../domain/sales';

@NgModule({
  declarations: [
  
   SalesComponent,
   SalesforomComponent,
   

  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
  ],exports:[

   SalesComponent,
   SalesforomComponent

  ],providers:[

    SalesService,
    FormBuilder,
  
  ]
})
export class SalesModule { }
