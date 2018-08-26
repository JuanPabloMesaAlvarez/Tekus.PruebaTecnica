import { Component } from "@angular/core";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent {

    dbStorage: boolean = true;

    constructor() {
        localStorage["dbStorage"] = this.dbStorage;
    }

    changeDbStorage(){
        this.dbStorage = !this.dbStorage;
        localStorage["dbStorage"] = this.dbStorage;
    }
}