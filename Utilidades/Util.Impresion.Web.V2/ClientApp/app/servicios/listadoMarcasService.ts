import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

//import { IRaza } from './raza';
@Injectable()
export class ListadoMarcasService {
    constructor(private _http: Http) { }
    private _razaUrl = 'api/listadoArchivoCargados';
    getMarcas(): Observable<any[]> {
        return this._http.get(this._razaUrl)
            .map((response: Response) => <any[]>response.json())
            .do(data => console.log('TODOS:' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}