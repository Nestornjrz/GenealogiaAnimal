import { Component } from '@angular/core';
import { FileSelectDirective ,  FileUploader } from 'ng2-file-upload';

const URL = 'http://localhost:15125/api/uploadFile';

@Component({
    selector: 'upload-file',
    template: require('./uploadfile.component.html')
})
export class UploadFileComponent {
    public uploader: FileUploader = new FileUploader({ url: URL });
    
}
