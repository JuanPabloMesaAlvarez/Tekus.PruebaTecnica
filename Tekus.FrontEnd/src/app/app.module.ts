import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { httpInterceptorProviders } from './Utils/httpHandler/httpInterceptor.service';
import { HttpHandlerService } from "./Utils/httpHandler/httpHandler.service";
import { appRoutes } from './Utils/routes/routes';
import { HomeComponent } from "./home/home.component";
import { CustomersComponent } from "./customers/customers.component";
import { ServicesComponent } from "./services/services.component";
import { ServiceComponent } from "./services/service.component";
import { SummaryComponent } from "./summary/summary.component";


@NgModule({
  declarations: [
    AppComponent, HomeComponent, CustomersComponent,
    ServicesComponent, ServiceComponent, SummaryComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [HttpHandlerService, 
    httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
