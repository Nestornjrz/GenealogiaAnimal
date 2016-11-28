import { Component, OnInit } from '@angular/core';

import { ListadoMarcasService } from './listadoMarcasService';

@Component({
    selector: 'listado-marcas',
    template: require('./listadoMarcas.component.html'),
    styles: [require('./listadoMarcas.component.css')]
})
export class ListadoMarcas implements OnInit {
    marcas: any[];

    errorMessage: string;
    constructor(private _listadoMarcasService: ListadoMarcasService) { }

    ngOnInit(): void {
        this._listadoMarcasService.getMarcas()
            .subscribe(marcas => this.marcas = marcas,
            error => this.errorMessage = <any>error);
        console.log("Se ejecuto el ngOnInit");
    }
}
