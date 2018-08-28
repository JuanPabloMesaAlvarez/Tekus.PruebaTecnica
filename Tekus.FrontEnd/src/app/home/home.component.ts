import { Component } from "@angular/core";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent {

    dbStorage: boolean = true;
    srvCache: boolean = false;

    constructor() {
        localStorage["dbStorage"] = this.dbStorage;
        localStorage["srvCache"] = this.srvCache;
    }

    changeDbStorage(){
        this.dbStorage = !this.dbStorage;
        localStorage["dbStorage"] = this.dbStorage;
    }

    changeSrvCache(){
        this.srvCache = !this.srvCache;
        localStorage["srvCache"] = this.srvCache;
    }
}