import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';
import { ListComponent } from './employee/list/list.component';
import { MessagesComponent } from './messages/messages.component';
import { DetailComponent } from './employee/detail/detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    MessagesComponent,
    DetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
