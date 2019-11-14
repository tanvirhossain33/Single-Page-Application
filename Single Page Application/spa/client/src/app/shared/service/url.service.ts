import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class UrlService {

  BaseUrl: string;

  UploadFolderUrl: string;

  baseUrl = 'http://localhost:3027';
  baseApi = this.baseUrl + '/api';

  dropdownUrl = this.baseApi + '/Dropdown';

  constructor() {

    const baseUrl = this.baseUrl;
    const baseApi = baseUrl + '/api';

    this.CompanyUrl = baseApi + '/Company';
    this.CompanyQueryUrl = baseApi + '/CompanyQuery';

    this.DocumentUrl = baseApi + '/Document';
    this.DocumentQueryUrl = baseApi + '/DocumentQuery';

    this.TradeUrl = baseApi + '/Trade';
    this.TradeQueryUrl = baseApi + '/TradeQuery';

    this.LevelUrl = baseApi + '/Level';
    this.LevelQueryUrl = baseApi + '/LevelQuery';

    this.FileUploadUrl = baseApi + '/Upload/UploadFiles';
  }

  CompanyUrl: string;
  CompanyQueryUrl: string;

  DocumentUrl: string;
  DocumentQueryUrl: string;

  TradeUrl: string;
  TradeQueryUrl: string;

  LevelUrl: string;
  LevelQueryUrl: string;

  FileUploadUrl: string;
}
