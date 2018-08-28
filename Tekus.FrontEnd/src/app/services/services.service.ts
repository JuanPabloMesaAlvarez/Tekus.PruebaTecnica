import { Injectable } from "@angular/core";
import { Service } from "../models/service";
import { Observable } from "rxjs";
import { ServiceBase } from "../Utils/services/serviceBase";
import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";

@Injectable()
export class ServicesService extends ServiceBase {

    constructor(private http: HttpHandlerService) {
        super()
        this.localStorageName = "services";
    }

    getServices() {
        if (this.dbStorage) {
            var uri = "services";
            if (this.srvCache) {
                uri += "cache"
            }
            return this.http.get(uri);
        }
        else {
            return Observable.of(JSON.parse(localStorage[this.localStorageName]));
        }
    }

    getServiceById(serviceId: number) {
        if (this.dbStorage) {
            var uri = `services/${serviceId}`;
            if (this.srvCache) {
                uri = `servicescache/${serviceId}`;
            }
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
            if (this.srvCache) {
                uri += "cache"
            }
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
            if (this.srvCache) {
                uri = `servicescache/${service.ServiceId}`;
            }
            return this.http.put(uri, service);
        }
    }
}