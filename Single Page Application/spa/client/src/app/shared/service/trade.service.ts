import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { UrlService } from './url.service';
import { SearchRequest } from '../requestModels/searchRequest';
import { Trade } from '../models/trade.model';

@Injectable({
  providedIn: 'root'
})
export class TradeService extends ApiService{

  trade: Trade;
  tradeList: Trade[];
  isUpdate: boolean;

  constructor(httpClient: HttpClient, urlService: UrlService) {
    super(httpClient, urlService, urlService.TradeUrl, urlService.TradeQueryUrl);
    this.activate();
  }

  activate() {
    this.searchRequest = new SearchRequest('', 'Modified', 'False');
    this.searchRequest.Page = 1;
   }

   getAllTrade() {
    this.getList().subscribe((data: any) => {
      this.tradeList = data;
    });
  }
}
