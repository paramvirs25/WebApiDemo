import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';

import { ListComponent } from './employee/list/list.component';
import { DetailComponent } from './employee/detail/detail.component';

const routes: Routes = [
  { path: 'employee-list', component: ListComponent },
  { path: 'employee-detail/:id', component: DetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

