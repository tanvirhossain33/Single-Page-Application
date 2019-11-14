import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Document } from '../models/document.model';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { UrlService } from './url.service';
import { SearchRequest } from '../requestModels/searchRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DocumentService extends ApiService {

  document: Document;
  documentList: Document[];
  isUpdate: boolean;

  constructor(httpClient: HttpClient, urlService: UrlService) {
    super(httpClient, urlService, urlService.DocumentUrl, urlService.DocumentQueryUrl);
    this.activate();
   }

   activate() {
    this.searchRequest = new SearchRequest('', 'Modified', 'False');
    this.searchRequest.Page = 1;
   }

   getAllDocument() {
    this.search().subscribe((data: any) => {
      this.documentList = data;
    });
  }

  refreshList() {
    this.getAllDocument();
  }

}
