import { LoaderService } from './loader.service';
import { environment } from '../../../environments/environment';
import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  private apiUrl: string;
  constructor(
    private httpClient: HttpClient, 
    private loaderService: LoaderService, 
    private router : Router) {
    this.apiUrl = environment.apiUrl;
  }


  get(url: string): Observable<Object> {
    let headers = this.createDefaultHeaders();
    this.loaderService.iniciarRequisicao();

    return new Observable<Object>((obs) => {
      this.httpClient.get(this.apiUrl + url, { headers: headers }).subscribe((res) => {
        this.loaderService.encerrarRequisicao();
        obs.next(res);
      },(er)=>{
        this.loaderService.encerrarRequisicao();
        window.location.href = '#/**';
        obs.error(er);
      });
    });
  }
  post(url, data, contentType: string = 'application/json'): Observable<Object> {
    let headers = this.createDefaultHeaders(contentType);
    this.loaderService.iniciarRequisicao();
    return new Observable<Object>((obs) => {
      this.httpClient.post(this.apiUrl + url, data, { headers: headers }).subscribe((res) => {
        this.loaderService.encerrarRequisicao();
        obs.next(res);
      },(er)=>{
        this.loaderService.encerrarRequisicao();
        window.location.href = '#/**';
        obs.error(er);
      });
    });
  }
  put(url, data): Observable<Object> {
    let headers = this.createDefaultHeaders();
    return this.httpClient.put(this.apiUrl + url, data, {
      headers: headers
    });
  }
  delete(url): Observable<Object> {
    let headers = this.createDefaultHeaders();
    return this.httpClient.delete(this.apiUrl + url, {
      headers: headers
    });
  }
  private createDefaultHeaders(contentType: string = 'application/json'): HttpHeaders {
    let headers = new HttpHeaders({
      'Content-Type': contentType
    });

    let authorization = window.localStorage.getItem("token");
    if (authorization && authorization.length > 0) {
      headers = headers.append("Authorization", "Bearer " + authorization);
    }
    return headers;
  }
}
