import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ServiceBase } from "../Utils/services/serviceBase";
import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";

@Injectable()
export class CountriesService extends ServiceBase {

    constructor(private http: HttpHandlerService) {
        super()
        this.localStorageName = "countries";
    }

    getCountries() {
        if (this.dbStorage) {
            var uri = "countries";
            if (this.srvCache) {
                uri += "cache"
            }
            return this.http.get(uri);
        } else {
            return Observable.of(JSON.parse(localStorage[this.localStorageName]));
        }
    }

    getCountryById(countryId: string) {
        if (this.dbStorage) {
            var uri = `countries/${countryId}`;
            if (this.srvCache) {
                uri = `countriescache/${countryId}`;
            }
            return this.http.get(uri);
        }
        else {
            var countries = JSON.parse(localStorage[this.localStorageName])
            return Observable.of(countries.find(c => c.CountryId === countryId));
        }
    }
}