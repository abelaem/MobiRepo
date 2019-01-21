import { RouterModule  }    		  from '@angular/router';

import { SalesforomComponent } from './salesforom.component';
import { SalesComponent } from './sales.component';
import { PreventUnsavedChangesGuard } from '../prevent-unsaved-changes-guard.service';
import { salesorderline } from '../domain/salesorderline';
import { SalesorderlineComponent } from '../salesorderline/salesorderline.component';

export const  SalesRouting =RouterModule.forChild([
  {
       path: 'sales/:id', 
 	component: SalesforomComponent,
  		canDeactivate: [ PreventUnsavedChangesGuard ]  
  },
 {
         path: 'sales/new', 
 		component: SalesforomComponent,
 		canDeactivate: [ PreventUnsavedChangesGuard ]  
 },
{
path: 'orderline', 
component: SalesorderlineComponent,
canDeactivate: [ PreventUnsavedChangesGuard ]  
},

 { path: 'sales', component: SalesComponent },


]);