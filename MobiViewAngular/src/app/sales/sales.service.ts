import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';


@Injectable()
export class SalesService {
	private _url = "http://localhost:5912/api/Sales";

	constructor(private _http: HttpClient){
	}

	getUsers(){
		return this._http.get(this._url)
        .pipe(map(res => res));	
	}
    
    getUser(userId){
		return this._http.get(this.getSalesUrl(userId))
		
	}
    
    addSales(user){
		return this._http.post(this._url,user)
		
	}
    
    updateUser(product){
		return this._http.put(this.getSalesUrl(product.Id), product)
			
	}
    
    deleteUser(userId){
        
        
		return this._http.delete(this.getSalesUrl(userId))
		
	}
    
    private getSalesUrl(Id){
		return this._url + "/" + Id;
	}
}