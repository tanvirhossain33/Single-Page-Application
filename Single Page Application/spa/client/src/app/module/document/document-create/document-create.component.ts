import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { DocumentService } from 'src/app/shared/service/document.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpErrorResponse, HttpClient } from '@angular/common/http';
import { Document } from 'src/app/shared/models/document.model';
import { UrlService } from 'src/app/shared/service/url.service';


@Component({
  selector: 'app-document-create',
  templateUrl: './document-create.component.html',
  styleUrls: ['./document-create.component.css']
})
export class DocumentCreateComponent implements OnInit {

  trades: any;
  levels: any;

  errorMessage: string;
  filesToUpload: Array<File>;
  selectedFileNames: string[] = [];
    public isLoadingData: Boolean = false;
    @ViewChild('fileUpload') fileUploadVar: any;
    uploadResult: any;
    res: Array<string>;

  constructor(
    private httpClient: HttpClient,
    private service: DocumentService,
    private urlService: UrlService,
    private toaster: ToastrService) { 
      this.errorMessage = "";
        this.filesToUpload = [];
        this.selectedFileNames = [];
        this.uploadResult = "";
    }

  ngOnInit() {
    this.service.document = new Document();
    this.service.count();
    this.service.document.TradeId = "";
    this.service.document.LevelId = "";
    this.getTradeList();
    
  }

  OnSubmit(form: NgForm) {
    if (!this.service.isUpdate) {
      this.insertRecord(form);
      this.upload();
    } else {
      this.updateRecord(this.service.document);
    }
  }

  insertRecord(form: NgForm) {
    this.service.post(form.value)
    .subscribe(
      (data: any) => {
        this.resetForm(form);
        this.toaster.success('Document create successful');
        this.service.refreshList();
        console.log(data);
        this.ngOnInit();
      },
      (error: HttpErrorResponse) => {
        this.toaster.error('Document create failed');
        console.log(error);
      }
    );
  }

  updateRecord(document: Document) {
    this.service.put(document).subscribe(
      (data: any) => {
        this.toaster.success('Document update successful');
        this.service.refreshList();
        console.log(data);
        this.ngOnInit();
        this.service.isUpdate = false;
      },
      (error: HttpErrorResponse) => {
        this.toaster.error("Document update failed");
        console.log(error);
      }
    );
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }
    this.service.document = new Document();

    this.service.document.TradeId = "";
    this.service.document.LevelId = "";
    this.getTradeList();
  }

  cancel() {
    this.service.isUpdate = false;
    this.ngOnInit();
  }

  getTradeList(){
    this.service.load(this.urlService.TradeQueryUrl + "/LoadTrades").subscribe(
      (data: any) => {
        this.trades = data;
        console.log(data);
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      }
    )
  }

  getLevelList(value: string){
    this.service.load(this.urlService.LevelQueryUrl + "/LoadLevels?input=" + value).subscribe(
      (data: any) => {
        this.levels = data;
        console.log(data);
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      }
    )
  }

  loadLevels(value: string){

    this.getLevelList(value);
  }

  fileChangeEvent(fileInput: any)
    {
        this.uploadResult = "";
        this.filesToUpload = <Array<File>>fileInput.target.files;

        for (let i = 0; i < this.filesToUpload.length; i++)
        {
            this.selectedFileNames.push(this.filesToUpload[i].name);
        }
    }

    upload()
    {
        if (this.filesToUpload.length == 0)
        {
            alert('Please select at least 1 PDF files to upload!');
        }
        else if (this.filesToUpload.length > 1) {
            alert('Please select a maximum of 1 PDF files to upload!');
        }
        else
        {
            if (this.validatePDFSelectedOnly(this.selectedFileNames))
            {
                this.uploadFiles();
            }
        }
    }

    validatePDFSelectedOnly(filesSelected: string[])
    {
        for (var i = 0; i < filesSelected.length; i++)
        {
            if (filesSelected[i].slice(-3).toUpperCase() != "PDF")
            {
                alert('Please selecte PDF files only!');
                return false;
            }
            else {
                return true;
            }
        }
    }

    uploadFiles()
    {
        this.uploadResult = "";

        if (this.filesToUpload.length > 0)
        {
            this.isLoadingData = true;

            let formData: FormData = new FormData();

            for (var i = 0; i < this.filesToUpload.length; i++)
            {
                formData.append('uploadedFiles', this.filesToUpload[i], this.filesToUpload[i].name);
            }

            let apiUrl = this.urlService.FileUploadUrl;
            //let apiUrl = "/api/Upload/UploadFiles";
            this.httpClient.post(apiUrl, formData)
                .subscribe
                (
                    data => {
                        this.uploadResult = data;
                        this.errorMessage = "";
                    },
                    err => {
                        console.error(err);
                        this.errorMessage = err;
                        this.isLoadingData = false;
                    },
                    () => {
                        this.isLoadingData = false,
                        this.selectedFileNames = [];
                        this.filesToUpload = [];
                    }
                );
        }
    }


}
