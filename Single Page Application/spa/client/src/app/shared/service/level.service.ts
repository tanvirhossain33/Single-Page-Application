import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Level } from '../models/level.model';
import { HttpClient } from '@angular/common/http';
import { UrlService } from './url.service';
import { SearchRequest } from '../requestModels/searchRequest';

@Injectable({
  providedIn: 'root'
})
export class LevelService extends ApiService{
  
  level: Level;
  levelList: Level[];
  isUpdate: boolean;

  constructor(httpClient: HttpClient, urlService: UrlService) {
    super(httpClient, urlService, urlService.LevelUrl, urlService.LevelQueryUrl)
  }

  activate() {
    this.searchRequest = new SearchRequest('', 'Modified', 'False');
    this.searchRequest.Page = 1;
  }

   getAllTrade() {
    this.getList().subscribe((data: any) => {
      this.levelList = data;
    });
  }
}
