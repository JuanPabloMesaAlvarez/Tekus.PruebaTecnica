import { Component, Input, OnChanges, SimpleChanges, Output, EventEmitter } from "@angular/core";
import { ServicesService } from "./services.service";
import { CustomersService } from "../customers/customers.service";
import { Service } from "../models/service";
import { Customer } from "../models/customer";
import { CountriesService } from "../countries/countries.service";
import { Country } from "../models/country";

@Component({
    selector: 'service',
    templateUrl: './service.component.html',
    providers: [ServicesService, CustomersService, CountriesService]
})

export class ServiceComponent implements OnChanges {

    @Input() serviceId: number = -1;
    @Output() serviceCreated = new EventEmitter();

    entity: Service = new Service();
    customers: Customer[] = [];
    countries: Country[] = [];

    constructor(private service: ServicesService, private customerService: CustomersService, private countryServices: CountriesService) {
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.getCustomers();
        this.getCountries();
        
        if (changes["serviceId"].previousValue === changes["serviceId"].currentValue) {
            return;
        }

        if (changes["serviceId"].currentValue === -1) {
            this.entity = new Service();
            return;
        }

        this.service.getServiceById(this.serviceId).subscribe(
            (result: Service) => {
                this.entity = result;
            },
            error => {
                console.log(error.error.ExceptionMessage);
            }
        );
    }

    getCountries(){
        this.countryServices.getCountries().subscribe(
            (result: Country[]) => { this.countries = result },
            error => { console.log(error); }
        );
    }

    getCustomers(){
        this.customerService.getCustomers().subscribe(
            (result: Customer[]) => { this.customers = result },
            error => { console.log(error); }
        );
    }

    saveService() {
        if (this.serviceId === -1) {
            this.service.createService(this.entity).subscribe(
                result => { this.serviceCreated.emit(); },
                error => { console.error(error.error.ExceptionMessage); }
            );
            return;
        }

        this.service.updateService(this.entity).subscribe(
            result => { this.serviceCreated.emit(); },
            error => { console.error(error.error.ExceptionMessage); }

        );
    }

    selectCountry(selectedCountry: number){
        var item = this.entity.CountriesIds.indexOf(selectedCountry);
        if (item > -1) {
            this.entity.CountriesIds.splice(item, 1);
            return;
        }
        this.entity.CountriesIds.push(selectedCountry);
    }

    existCountry(countryId: number) {
        if (!this.entity.CountriesIds) {
            return false;
        }
        
        return this.entity.CountriesIds.indexOf(countryId) > -1;
    }
}