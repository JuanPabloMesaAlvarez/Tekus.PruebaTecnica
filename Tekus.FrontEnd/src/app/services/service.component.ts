import { Component, Input, OnChanges, SimpleChanges, Output, EventEmitter } from "@angular/core";
import { ServicesService } from "./services.service";
import { CustomersService } from "../customers/customers.service";
import { Service } from "../models/service";
import { Customer } from "../models/customer";

@Component({
    selector: 'service',
    templateUrl: './service.component.html',
    providers: [ServicesService, CustomersService]
})

export class ServiceComponent implements OnChanges {

    @Input() serviceId: number = -1;
    @Output() serviceCreated = new EventEmitter();

    entity: Service = new Service();
    customers: Customer[] = [];

    constructor(private service: ServicesService, private customerService: CustomersService) {
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.getCustomers();
        
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
}