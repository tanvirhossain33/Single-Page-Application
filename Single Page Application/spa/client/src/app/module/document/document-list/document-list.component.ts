import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../common/base-component';
import { DocumentService } from 'src/app/shared/service/document.service';
import { ToastrService } from 'ngx-toastr';
import { Document } from 'src/app/shared/models/document.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-document-list',
  templateUrl: './document-list.component.html',
  styleUrls: [
    './document-list.component.css',
  ]
})
export class DocumentListComponent extends BaseComponent implements OnInit {

  key: string = 'Syllabus';
  reverse: boolean = false;
  sort(key){
    this.key = key;
    this.reverse = !this.reverse;
  }
  p: number = 1;

  constructor(service: DocumentService, toaster: ToastrService) {
    super(service, toaster);
   }

   ngOnInit() {
    this.activate();
  }

  activate() {
    this.service.getAllDocument();
  }

  getDocumentDetails(document: Document) {
    const url = this.service.urlService.DocumentUrl + '?id=' + document.Id;
    this.service.load(url).subscribe((data: any) => {
      this.service.document = Object.assign({}, data);
      this.service.isUpdate = true;
    });
  }

  deleteDcument(id: string) {
    this.service.delete(id).subscribe(
      (success: any) => {
        console.log(success);
        this.service.getAllDocument();
        this.toaster.success('Delete successful.');
      },
      (error: HttpErrorResponse) => {
        console.log(error);
        this.toaster.error('Delete failed.');
      }
    );
  }

  download(fileName){
    const url = this.service.urlService.FileUploadUrl + '?fileName=' + fileName;
    this.service.fileDownload(url).subscribe(
      (response: any) => {
        let dataType = response.dataType;
        let binaryData = [];
        let downloadLink = document.createElement('a');
        downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));

        downloadLink.setAttribute('download', fileName);
        document.body.appendChild(downloadLink);
        downloadLink.click();
      }
    )
    
  }

}
