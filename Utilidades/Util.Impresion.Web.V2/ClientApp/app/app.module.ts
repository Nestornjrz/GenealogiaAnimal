import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
///Componente raiz
import { AppComponent } from './components/app/app.component'
///Componentes de ejemplo
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
////Libreria de terceros
import { FileSelectDirective } from 'ng2-file-upload'; //https://github.com/valor-software/ng2-file-upload/issues/418
////Componentes utilizados, reutilizados y/o propios
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { UploadFileComponent } from './components/uploadFile/uploadfile.component';
import { ListadoMarcas } from './components/listadoMarcas/listadoMarcas.component';
////Servicios
import { ListadoMarcasService } from './servicios/listadoMarcasService';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        //Raiz
        AppComponent,
        //Ejemplos
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        //Terceros
        FileSelectDirective, //https://github.com/valor-software/ng2-file-upload/issues/418
        //Propios
        NavMenuComponent,
        UploadFileComponent,
        ListadoMarcas
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'upload-file', component: UploadFileComponent },
            { path: 'listado-marcas', component: ListadoMarcas },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ListadoMarcasService]
})
export class AppModule {
}
