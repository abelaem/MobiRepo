import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';


@Injectable()
export class ProductService {
	private _url = "http://localhost:5912/api/ProductsApi";

	constructor(private _http: HttpClient){
	}
	
	search_word(term){
        return this._http.get(this._url +"/serach/"+ term)
	}
	
	getUsers(){
		return this._http.get(this._url)
        .pipe(map(res => res));	
	}
    
    getUser(userId){
		return this._http.get(this.getProductUrl(userId))
		
	}
    
    addUser(user){
		return this._http.post(this._url,user)
			
	}
    
    updateUser(product){
		return this._http.put(this.getProductUrl(product.Id), product)
			
	}
    
    deleteUser(userId){
        
        
		return this._http.delete(this.getProductUrl(userId))
		
	}
    
    private getProductUrl(Id){
		return this._url + "/" + Id;
	}
}