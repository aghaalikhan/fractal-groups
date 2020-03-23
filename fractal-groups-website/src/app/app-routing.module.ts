import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchResultsComponent } from './search-results/search-results.component';
import { LandingComponent } from './landing/landing.component';
import { AddUserComponent } from './add-user/add-user.component';

const routes: Routes = [ 
  { 
    path: 'search-results', component: SearchResultsComponent 
  },
  { 
    path: '', component: LandingComponent 
  },
  {
    path: 'user/add', component: AddUserComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
