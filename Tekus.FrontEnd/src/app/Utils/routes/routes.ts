import { Routes } from "@angular/router";

import { HomeComponent } from "../../home/home.component";
import { CustomersComponent } from "../../customers/customers.component";
import { ServicesComponent } from "../../services/services.component";
import { SummaryComponent } from "../../summary/summary.component";

export const appRoutes: Routes = [
    {
        path: 'home', component: HomeComponent,
        children: [
            {
                path: 'customers', component: CustomersComponent,
            },
            {
                path: 'services', component: ServicesComponent,
            }
            ,
            {
                path: 'summary', component: SummaryComponent,
            }
        ]
    },
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    { path: '**', component: HomeComponent }
];