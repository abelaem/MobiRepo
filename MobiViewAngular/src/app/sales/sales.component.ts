import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { SalesService } from './sales.service';
import { sales } from '../domain/sales';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
sales:any


  constructor(private service:SalesService) { }

  ngOnInit() {
 

    this.service.getUsers().subscribe(response=>{
      this.sales=response},
      err=>{console.log(err)}
    
    )}
    deleteSales(sale:any)
    {


    }
}
