import { environment } from '../../../environments/environment';
import { Injectable } from "@angular/core";
import { HttpClientService } from "./http.client.service";
import { Events } from '../events/events';
import { ContaAutenticadaModel } from '../models/conta-autenticada-model';

@Injectable()
export class AutenticacaoService {
  constructor(private httpClient: HttpClientService, private events: Events) {

  }
  estaAutenticado() : boolean{
    let conta = window.localStorage.getItem('conta');
    return conta != undefined;
  }
  obterConta(): ContaAutenticadaModel {
    let conta = window.localStorage.getItem('conta');
    if(!conta) return undefined;
    return JSON.parse(conta) as ContaAutenticadaModel;
  }
  efetuarLogoff() {
    window.localStorage.removeItem('token');
    window.localStorage.removeItem('conta');
    this.events.usuarioEfetuouLogoffEvent.emit(true);
  }
  autenticar(login: string, senha: string) {
    this.httpClient.post('/federation/token',
      `grant_type=password&client_id=${environment.clientId}&client_secret=${environment.clientSecret}&username=${login}&password=${senha}&scope=openid poc-api.all`,
      'application/x-www-form-urlencoded').subscribe((res) => {

        window.localStorage.setItem('token', res['access_token']);

        this.httpClient.get('/federation/userinfo').subscribe((userInfoRes) => {
          let response = <any>userInfoRes;
          let conta = new ContaAutenticadaModel(response.sub, response.username, response.nomeCompleto, response.role);

          window.localStorage.setItem('conta', JSON.stringify(conta));

          this.events.usuarioAutenticouEvent.emit(conta);
        })
      });;
  }
}