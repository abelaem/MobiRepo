import { ProductService } from './../product/product.service';
import { Component, OnInit } from '@angular/core';
import { salesorderline } from '../domain/salesorderline';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-salesorderline',
  templateUrl: './salesorderline.component.html',
  styleUrls: ['./salesorderline.component.css']
})
export class SalesorderlineComponent implements OnInit {
  orderline:salesorderline[]=[]
  orderlinesingle:salesorderline
  awaitorderline:salesorderline[]=[]
  subtotals:salesorderline[]=[]
  editFiel:string
  searchTerm : FormControl = new FormControl();

  searchResult:any = [];
  constructor(private service:ProductService) { 
    //this.orderlinesingle = new salesorderline();
     
  }

  ngOnInit() {
    this.orderlinesingle= new salesorderline()
   this.orderline.push(this.orderlinesingle)
   this.searchTerm.valueChanges
   .subscribe(data => {
      if(!(data==="")){
       this.service.search_word(data).subscribe(response =>{
           this.searchResult=response
           
       },
       err=>{"no result"}
       )
      } })

  
  }


  updateList(id: number, property: string, event: any) {
    const editField = event.target.textContent;
    this.orderline[id][property] = editField;
    //this.orderline[id]["Subtotal"]=this.orderline[id]["Quantity"]*this.orderline[id]["UnitPrice"]
    console.log("dsf")
  }

  remove(id: any) {
    this. awaitorderline.push(this.orderline[id]);
    this.orderline.splice(id, 1);
  }

  add() {
      
      this.orderlinesingle = new salesorderline()
      this.orderline.push(this.orderlinesingle);
      this.subtotals.push( new salesorderline())
    
   
  }

  changeValue(id: number, property: string, event: any) {
   this.editFiel = event.target.textContent;
  // event.target.textContent=""
   // this.subtotals[id][property] = event.target.textContent;
  // if(! isNaN(this.subtotals[id]["Quantity"]) && !isNaN(this.subtotals[id]["UnitPrice"]))
  //    this.orderline[id]["Subtotal"]=this.subtotals[id]["Quantity"]*this.subtotals[id]["UnitPrice"]
   //console.log(this.orderline[id]["Subtotal"])
  
  }

}
