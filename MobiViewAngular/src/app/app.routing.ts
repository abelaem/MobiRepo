
import { HomeComponent } from './home/home.component';

import { RouterModule  }     from '@angular/router';

import { NotFoundComponent } from './not-found.component';

export const routing = RouterModule.forRoot([
	{ path: '', component: HomeComponent },
	
   { path: 'not-found', component: NotFoundComponent },
//	{ path: '**', redirectTo: 'not-found' }
]);