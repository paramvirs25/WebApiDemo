import { NgModule } from '@angular/core';
import { RouterModule, Routes, Route } from '@angular/router';

import { ListComponent } from './employee/list/list.component';
import { DetailComponent } from './employee/detail/detail.component';

import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { HomeLayoutComponent } from './layouts/home-layout/home-layout.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';

import { AuthGuard } from './_guards';

const routes: Routes = [
  {
    path: '',
    component: HomeLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: ListComponent },
      { path: 'employee-list', component: ListComponent },
      { path: 'employee-detail/:id', component: DetailComponent }
    ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      }
    ]
  },
  //{ path: '', component: ListComponent, canActivate: [AuthGuard] },
  //{ path: 'login', component: LoginComponent },
  //{ path: 'register', component: RegisterComponent },
  //{ path: 'employee-list', component: ListComponent, canActivate: [AuthGuard] },
  //{ path: 'employee-detail/:id', component: DetailComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

