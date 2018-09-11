import { Observable } from 'rxjs';
import { HttpClientService } from './http.client.service';
import { Injectable } from '@angular/core';
import { DadosFornecedorEntregaModel } from '../models/dados-fornecedor-entrega-model';

@Injectable()
export class FornecedorService
{
    /**
     *
     */
    constructor(public httpClient : HttpClientService) {
    }

    obterDadosDeEntrega(fornecedorUID?:string, cep?:string) : Observable<DadosFornecedorEntregaModel>{
        return new Observable((obs)=>{
            this.httpClient.get('/fornecedores/' + fornecedorUID + '/frete/' + cep).subscribe((res : DadosFornecedorEntregaModel)=>{
                obs.next(res);
                obs.complete();
            });
        });
    }

    obterEstoqueDoProduto(fornecedorUID?:string, codigoProduto?:string) : Observable<boolean>{
        return new Observable((obs)=>{
            this.httpClient.get('/fornecedores/' + fornecedorUID + '/produtos/' + codigoProduto + '/estoque').subscribe((res:boolean)=>{
                obs.next(res);
                obs.complete();
            });
        });
    }
}