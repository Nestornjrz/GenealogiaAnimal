import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
//Servicios
//import { ProveeClientesService } from '../../../servicios/proveeClientesService';
//Dtos
import { IProveeClienteDto } from '../../../dtos/ProveeClienteDto';
import { IImagenesDto } from '../../../dtos/ImagenesDto';


@Component({
    selector: 'form-cargas',
    template: require('./formulario.component.html'),
    styles: [require('./formulario.component.css')]
})
export class Formulario { //implements OnInit{  
    model: IImagenesDto = { nombre: "", proveedorID: 0 };
    proveedores: [IProveeClienteDto];

    errorMessage: string;

    //constructor(private _proveeClientesService: ProveeClientesService) { }

    //ngOnInit(): void {
    //    this._proveeClientesService.getProveedores()
    //        .subscribe(proveedores => this.proveedores = proveedores,
    //        error => this.errorMessage = <any>error);
    //}
}
