import { Component, OnInit } from "@angular/core";
import { ServicesService } from "./services.service";
import { Service } from "../models/service";

@Component({
    selector: 'services',
    templateUrl: './services.component.html',
    providers: [ServicesService]
})

export class ServicesComponent implements OnInit {

    services: Service[] = [];
    servicesList: Service[] = [];
    selectedService: number = -1;

    constructor(private httpService: ServicesService) {
    }

    ngOnInit(): void {
        this.getServices();
    }

    getServices(){
        this.httpService.getServices().subscribe(
            (result: Service[]) => { 
                this.services = result;
                this.servicesList = result;
                localStorage[this.httpService.localStorageName] = JSON.stringify(this.services); 
            },
            error => { console.log(error); }
        );
    }

    createService(){
     this.selectedService = -1;  
    }

    selectService(serviceId: number){
        this.selectedService = serviceId;
    }

    filter(field: string, value: string){
        this.servicesList = Object.assign([], this.services).filter(
            item => item[field].toString().toLowerCase().match(value.toLowerCase())
        );
    }
}