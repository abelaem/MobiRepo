import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';


@Injectable()
export class UomService {
	private _url = "http://localhost:5912/api/uom";

	constructor(private _http: HttpClient){
	}

	getUoms(){
		return this._http.get(this._url)
        .pipe(map(res => res));	
	}
    
    getUom(userId){
		return this._http.get(this.getUomUrl(userId))
		
	}
    
    addUom(user){
		return this._http.post(this._url,user)
			
	}
    
    updateUser(product){
		return this._http.put(this.getUomUrl(product.Id), product)
			
	}
    
    deleteUser(userId){
        
        
		return this._http.delete(this.getUomUrl(userId))
		
	}
    
    private getUomUrl(Id){
		return this._url + "/" + Id;
	}
}