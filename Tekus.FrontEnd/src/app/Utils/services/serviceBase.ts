import { Injectable } from "@angular/core";

@Injectable()
export class ServiceBase {

    public localStorageName: string = "";
    public get dbStorage(): boolean {

        try {
            return JSON.parse(localStorage["dbStorage"]);
        } catch (error) {
            return true;
        }
    }

    public get srvCache(): boolean {
        try {
            return JSON.parse(localStorage["srvCache"]);
        } catch (error) {
            return false;
        }

    }
}