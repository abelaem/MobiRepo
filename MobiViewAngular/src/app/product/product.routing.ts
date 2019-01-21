import { RouterModule  }    		  from '@angular/router';

import {ProductFormComponent} from '../product/product-form.component'
import { ProductComponent }    		  from './product.component';
import { PreventUnsavedChangesGuard } from '../prevent-unsaved-changes-guard.service';

export const  ProductRouting =RouterModule.forChild([
{
        path: 'products/:id', 
		component: ProductFormComponent,
		canDeactivate: [ PreventUnsavedChangesGuard ]  
},
{
        path: 'products/new', 
		component: ProductFormComponent,
		canDeactivate: [ PreventUnsavedChangesGuard ]  
},
{ path: 'products', component: ProductComponent },


]);