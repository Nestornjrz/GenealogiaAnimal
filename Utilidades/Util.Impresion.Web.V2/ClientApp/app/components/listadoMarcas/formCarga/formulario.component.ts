import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
//Servicios
import { ProveeClientesService } from '../../../servicios/proveeClientesService';
//Dtos
import { ProveeClienteDto } from '../../../dtos/ProveeClienteDto';
import { ImagenDto } from '../../../dtos/ImagenesDto';


@Component({
    selector: 'form-cargas',
    template: require('./formulario.component.html'),
    styles: [require('./formulario.component.css')]
})
export class Formulario implements OnInit {
    model: ImagenDto;
    proveedores: [ProveeClienteDto];
    proveedorIndefinido: ProveeClienteDto;
    proveedorValidateError: boolean = false;

    errorMessage: string;

    constructor(private _proveeClientesService: ProveeClientesService) {
        this.proveedorIndefinido = new ProveeClienteDto(0, "Seleccione la opcion");
        this.model = new ImagenDto(this.proveedorIndefinido, "");
    }

    ngOnInit(): void {
        this._proveeClientesService.getProveedores()
            .subscribe(proveedores => {
                this.proveedores = proveedores;
                this.proveedores.unshift(this.proveedorIndefinido);
            },
            error => this.errorMessage = <any>error);
    }

    validateProveedoresSelect(proveedor: ProveeClienteDto) {
        if (proveedor.proveeClienteID == 0){
            this.proveedorValidateError = true;
        } else {
            this.proveedorValidateError = false;
        }
        console.log(proveedor);
    }
}
