import { Component, OnInit } from '@angular/core';

import { IRaza } from './raza';
import { RazaService } from './raza.service';

@Component({
    selector: 'razas',
    template: require('./razas.component.html'),
    styles: [require('./razas.component.css')]
})
export class RazasComponent {
    razas: IRaza[];
    errorMessage: string;
    constructor(private _razaService: RazaService) { }

    ngOnInit(): void {
        this._razaService.getRazas()
            .subscribe(razas => this.razas = razas,
            error => this.errorMessage = <any>error);
        console.log("Se ejecuto el ngOnInit");
    }
}