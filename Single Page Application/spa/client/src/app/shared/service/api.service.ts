import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UrlService } from './url.service';
import { SearchRequest } from '../requestModels/searchRequest';



@Injectable({
  providedIn: 'root'
})
export class ApiService {
  currentUserRole: string;

  searchRequest: SearchRequest;

  numberOfData: number;
  page: number;
  pageSize: number;

  httpClient: HttpClient;
  urlService: UrlService;
  saveUrl: string;
  searchUrl: string;

  constructor(httpClient: HttpClient, urlService: UrlService, saveUrl: string, searchUrl: string) {
    this.httpClient = httpClient;
    this.urlService = urlService;
    this.saveUrl = saveUrl;
    this.searchUrl = searchUrl;
   }

  load(url: string): Observable<any> {
    return this.httpClient.get(url).pipe(catchError(this.formatErrors));
  }

  fileDownload(url: string): Observable<any> {
    return this.httpClient.get(url, {responseType: 'blob' as 'json'});
  }

  search(callCount: boolean = true): Observable<any> {
    if (callCount) {
      this.count();
    }
    return this.httpClient.post(this.searchUrl, this.searchRequest).pipe(catchError(this.formatErrors));
  }

  getList(callCount: boolean = true): Observable<any> {
    if (callCount) {
      this.count();
    }
    const url = this.searchUrl + '?request=' + JSON.stringify(this.searchRequest);
    return this.httpClient.get(url).pipe(catchError(this.formatErrors));
  }

  count() {
    const url = this.searchUrl + '?request=' + JSON.stringify(this.searchRequest);
    return this.httpClient.get(url).subscribe(
      (data: any) => {
        this.numberOfData = data;
        this.page = this.searchRequest.Page;
        this.pageSize = this.searchRequest.PerPageCount;
        this.searchRequest.TotalPage = Math.ceil(data / 10);

        console.log(data);
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      }
    );
  }

  post(model): Observable<any> {
    model.Created = new Date();
    model.CreatedBy = model.Manager;
    model.Modified = new Date();
    model.ModifiedBy = model.Manager;

    return this.httpClient.post(this.saveUrl, model).pipe(catchError(this.formatErrors));
  }

  put(model): Observable<any> {

    model.Modified = new Date();

    return this.httpClient.put(this.saveUrl, model).pipe(catchError(this.formatErrors));
  }

  delete(id: string): Observable<any> {
    return this.httpClient.delete(this.saveUrl + '?id=' + id).pipe(catchError(this.formatErrors));
  }

  formatErrors(error: any): Observable<any> {
    return throwError(error.error);
  }
}
