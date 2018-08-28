import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ServiceBase } from "../Utils/services/serviceBase";
import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";

@Injectable()
export class CustomersService extends ServiceBase {

    constructor(private http: HttpHandlerService) {
        super()
        this.localStorageName = "customers";
    }

    getCustomers() {
        if (this.dbStorage) {
            var uri = "customers";
            if (this.srvCache) {
                uri += "cache"
            }
            return this.http.get(uri);
        }
        else {
            return Observable.of(JSON.parse(localStorage[this.localStorageName]));
        }

    }

    getCustomerById(customerId: string) {
        if (this.dbStorage) {
            var uri = `customers/${customerId}`;
            if (this.srvCache) {
                uri = `customerscache/${customerId}`
            }
            return this.http.get(uri);
        }
        else {
            var customers = JSON.parse(localStorage[this.localStorageName]);
            return Observable.of(customers.find(c => c.CustomerId === customerId));
        }
    }
}