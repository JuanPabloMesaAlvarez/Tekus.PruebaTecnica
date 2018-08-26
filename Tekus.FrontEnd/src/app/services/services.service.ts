import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";
import { Injectable } from "@angular/core";
import { Service } from "../models/service";
import { Observable } from "rxjs";

@Injectable()
export class ServicesService {

    localStorageName: string = "services";
    public get dbStorage(): boolean {
        return JSON.parse(localStorage["dbStorage"]);
    }

    constructor(private http: HttpHandlerService) {

    }

    getServices() {
        if (this.dbStorage) {
            var uri = "services";
            return this.http.get(uri);
        }
        else {
            return Observable.of(JSON.parse(localStorage[this.localStorageName]));
        }
    }

    getServiceById(serviceId: number) {
        if (this.dbStorage) {
            var uri = `services/${serviceId}`;
            return this.http.get(uri);
        }
        else {
            var services = JSON.parse(localStorage[this.localStorageName])
            return Observable.of(services.find(s => s.ServiceId === serviceId));
        }
    }

    createService(service: Service) {
        if (this.dbStorage) {
            var uri = "services";
            return this.http.post(uri, service);
        }
        else {
            var services = JSON.parse(localStorage[this.localStorageName])
            return Observable.of(services.push(service));
        }
    }

    updateService(service: Service) {
        if (this.dbStorage) {
            var uri = `services/${service.ServiceId}`;
            return this.http.put(uri, service);
        }
    }
}