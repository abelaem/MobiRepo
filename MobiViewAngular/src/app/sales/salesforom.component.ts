import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import {formatDate} from '@angular/common';

import { SalesService } from './sales.service';
import { sales } from '../domain/sales';


@Component({
  selector: 'app-salesforom',
  templateUrl: './salesforom.component.html',
  styleUrls: ['./salesforom.component.css']
})
export class SalesforomComponent implements OnInit {
  salesform:FormGroup
  private sale:sales
  title:string
  id:number
  constructor(
    private _service:SalesService,
    private fm:FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute,
   
  ){
   
    
    this.salesform=fm.group({
     
      'Id':new FormControl(""), 
      'Reference':new FormControl("",Validators.required), 
      'CreatedBy':new FormControl("",Validators.required), 
      'Partner':new FormControl("",Validators.required), 
      'PartnerId':new FormControl("",Validators.required), 
      'CreatedDate':new FormControl("",Validators.required),
      'SalesTotal':new FormControl("",Validators.required),
       
      })
      
      this.sale= new sales(arguments);
      this.sale.CreatedDate= formatDate(new Date(), 'yyyy/MM/dd', 'en');
      

   }

  ngOnInit() {
   
  }
  save()
  {
   console.log(this.salesform.value)
   this._service.addSales(this.salesform.value).subscribe(response=>{
    console.log("wrong") },
    err=>{

      console.log(err)
    }
    
    );
  }

}
