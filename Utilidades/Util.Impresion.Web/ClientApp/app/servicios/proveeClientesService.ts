import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { IProveeClienteDto } from '../dtos/ProveeClienteDto';
@Injectable()
export class ProveeClientesService {
    constructor(private _http: Http) { }
    private _proveeClientesUrl = 'api/ProveeClientes/GetProveedores';
    getProveedores(): Observable<[IProveeClienteDto]> {
        return this._http.get(this._proveeClientesUrl)
            .map((response: Response) => <any[]>response.json())
            .do(data => console.log('TODOS:' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}