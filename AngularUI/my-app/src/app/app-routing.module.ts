import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';

import { ListComponent } from './employee/list/list.component';
import { DetailComponent } from './employee/detail/detail.component';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { AuthGuard } from './_guards';

const routes: Routes = [
  { path: '', component: ListComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'employee-list', component: ListComponent, canActivate: [AuthGuard] },
  { path: 'employee-detail/:id', component: DetailComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

