import { ProveeClienteDto } from './ProveeClienteDto';
export class ImagenDto {   
    constructor(
        public proveedor: ProveeClienteDto,
        public nombre: string
    ) { 

    }
}