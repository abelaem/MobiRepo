import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SalesService } from './sales/sales.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatAutocompleteModule, MatInputModule } from '@angular/material';

import { NotFoundComponent } from './not-found.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PreventUnsavedChangesGuard } from '../app/prevent-unsaved-changes-guard.service';
import { routing }           from './app.routing';

import { ProductModule } from './product/product.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProductComponent } from './product/product.component';
import { HomeComponent } from './home/home.component';
import { ProductRouting } from './product/product.routing';
import { ProductcategoryComponent } from './productcategory/productcategory.component';
import { UomComponent } from './uom/uom.component';
import { SalesComponent } from './sales/sales.component';
import { SalesforomComponent } from './sales/salesforom.component';
import { SalesModule } from './sales/sales.module';
import { SalesRouting } from './sales/sales.routing';
import { SalesorderlineComponent } from './salesorderline/salesorderline.component';

@NgModule({
   declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    NotFoundComponent,
    ProductcategoryComponent,
    UomComponent,
    SalesorderlineComponent,
    
   

  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
   
    MatInputModule,
    MatAutocompleteModule,
    BrowserAnimationsModule,
    routing,
    ProductRouting,
    ProductModule,
    SalesRouting,
    SalesModule,
    FormsModule
    
  
    
  ],
  providers: [
    PreventUnsavedChangesGuard,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
