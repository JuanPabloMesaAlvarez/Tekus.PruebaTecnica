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
}