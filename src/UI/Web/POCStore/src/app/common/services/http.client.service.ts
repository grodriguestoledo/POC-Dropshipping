import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private http: Http) { }


  get(url:string) {
    let headers = this.createDefaultHeaders();
    
  }

  private createDefaultHeaders() : Headers{
    let headers = new Headers();

    headers.append('Content-Type', 'application/json');

    let authorization = window.localStorage.getItem("token");
    if(authorization && authorization.length > 0){
      headers.append("Authorization","Bearer " + authorization);
    }
    return headers;
  }
}
