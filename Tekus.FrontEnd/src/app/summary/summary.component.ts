import { Component, OnInit } from "@angular/core";
import { CustomersService } from "../customers/customers.service";
import { ServicesService } from "../services/services.service";
import { CountriesService } from "../countries/countries.service";
import { Customer } from "../models/customer";
import { Service } from "../models/service";
import { Country } from "../models/country";
import { THIS_EXPR } from "@angular/compiler/src/output/output_ast";

@Component({
    selector: 'summary',
    templateUrl: './summary.component.html',
    providers: [CustomersService, CountriesService, ServicesService]
})

export class SummaryComponent implements OnInit {

    customers: Customer[] = [];
    services: Service[] = [];
    countries: Country[] = [];

    constructor(private customerServices: CustomersService, private serviceServices: ServicesService, private countryServices: CountriesService) {
    }

    ngOnInit(): void {
        this.getCustomers();
        this.getServices();
        this.getCountries();
    }

    getCustomers(){
        this.customerServices.getCustomers().subscribe(
            (result: Customer[]) => { this.customers = result },
            error => { console.log(error); }
        );
    }

    getServices(){
        this.serviceServices.getServices().subscribe(
            (result: Service[]) => { this.services = result },
            error => { console.log(error); }
        );
    }

    getCountries(){
        this.countryServices.getCountries().subscribe(
            (result: Country[]) => { 
                this.countries = result
                localStorage[this.countryServices.localStorageName] = JSON.stringify(this.countries); 
            },
            error => { console.log(error); }
        );
    }

}