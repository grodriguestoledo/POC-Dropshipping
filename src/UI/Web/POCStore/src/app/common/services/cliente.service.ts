import { EnderecoModel } from './../models/endereco-model';
import { DetalheProdutoModel } from '../models/detalhe-produto-model';
import { ListaProdutoModel } from '../models/lista-produto-model';
import { Injectable } from "@angular/core";
import { HttpClientService } from "./http.client.service";
import { Observable } from 'rxjs';

@Injectable()
export class ClienteService {
    constructor(private httpClient: HttpClientService) {

    }

    obterEnderecos(contaUID): Observable<EnderecoModel[]> {
        return new Observable<EnderecoModel[]>(obs => {

            this.httpClient.get('/clientes/' + contaUID + '/enderecos').subscribe((res: EnderecoModel[]) => {
                let retorno = res.map(m => {
                    return new EnderecoModel();
                });
                obs.next(retorno);
                obs.complete();
            }, (er) => {
                if (er.status == 404) {
                    obs.next([]);
                    obs.complete();
                }
            });
        });
    }
}