import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class CountriesService {

    localStorageName: string = "countries";
    public get dbStorage(): boolean {
        return JSON.parse(localStorage["dbStorage"]);
    }

    constructor(private http: HttpHandlerService) {

    }

    getCountries() {
        if (this.dbStorage) {
            var uri = "countries";
            return this.http.get(uri);
        } else {
            return Observable.of(JSON.parse(localStorage[this.localStorageName]));
        }
    }

    getCountryById(countryId: string) {
        if (this.dbStorage) {
            var uri = `countries/${countryId}`;
            return this.http.get(uri);
        }
        else {
            var countries = JSON.parse(localStorage[this.localStorageName])
            return Observable.of(countries.find(c => c.CountryId === countryId));
        }
    }
}