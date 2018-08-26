import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class CustomersService {

    localStorageName: string = "customers";
    public get dbStorage(): boolean {
        return JSON.parse(localStorage["dbStorage"]);
    }

    constructor(private http: HttpHandlerService) {

    }

    getCustomers() {
        if (this.dbStorage) {
            var uri = "customers";
            return this.http.get(uri);
        }
        else {
            return Observable.of(JSON.parse(localStorage[this.localStorageName]));
        }

    }

    getCustomerById(customerId: string) {
        if (this.dbStorage) {
            var uri = `customers/${customerId}`;
            return this.http.get(uri);
        }
        else {
            var customers = JSON.parse(localStorage[this.localStorageName]);
            return Observable.of(customers.find(c => c.CustomerId === customerId));
        }
    }
}