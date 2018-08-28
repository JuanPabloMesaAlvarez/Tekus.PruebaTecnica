import { Component, OnInit } from "@angular/core";
import { CustomersService } from "./customers.service";
import { Customer } from "../models/customer";

@Component({
    selector: 'customers',
    templateUrl: './customers.component.html',
    providers: [CustomersService]
})

export class CustomersComponent implements OnInit {

    customers: Customer[] = [];
    customersList: Customer[] = [];
    selectedCustomer: number = -1;

    constructor(private service: CustomersService) {
    }

    ngOnInit(): void {
        this.getCustomers();
    }

    getCustomers(){
        this.service.getCustomers().subscribe(
            (result: Customer[]) => { 
                this.customers = result;
                this.customersList = result; 
                localStorage[this.service.localStorageName] = JSON.stringify(this.customers); 
            },
            error => { console.log(error); }
        );
    }

    selectCustomers(customerId: number){
        this.selectedCustomer = customerId;
    }

    filter(field: string, value: string){
        this.customersList = Object.assign([], this.customers).filter(
            item => item[field].toString().toLowerCase().match(value.toLowerCase())
        );
    }
}