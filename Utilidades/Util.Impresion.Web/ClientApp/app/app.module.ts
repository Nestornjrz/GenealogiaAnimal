import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { FileSelectDirective } from 'ng2-file-upload'; //https://github.com/valor-software/ng2-file-upload/issues/418
///Componentes
import { UploadFileComponent } from './components/uploadFile/uploadfile.component';
import { ListadoMarcas } from './components/listadoMarcas/listadoMarcas.component';
///Servicios
import { ListadoMarcasService } from './components/listadoMarcas/listadoMarcasService';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        FileSelectDirective, //https://github.com/valor-software/ng2-file-upload/issues/418
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
