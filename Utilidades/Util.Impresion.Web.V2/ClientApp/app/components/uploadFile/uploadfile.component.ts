import { Component, OnInit } from '@angular/core';
import { FileSelectDirective, FileUploader } from 'ng2-file-upload';//http://valor-software.com/ng2-file-upload/

const URL = 'http://localhost:14224/api/uploadFile';

@Component({
    selector: 'upload-file',
    template: require('./uploadfile.component.html')
})

export class UploadFileComponent implements OnInit {
    public uploader: FileUploader = new FileUploader({ url: URL });

    /**  Gracias ha este enlace https://github.com/valor-software/ng2-file-upload/issues/251 
      pude saber como registrar funciones a los eventos de FileUploader */
    ngOnInit() {
        this.uploader.onCompleteItem = (item:any, response:any, status:any, headers:any) => {
            console.log("Archivo subido" + response);            
        };
        this.uploader.onErrorItem = (item:any, response:any, status:any, headers:any) => {
            console.log("Error: " + response);
        };
    }
}
