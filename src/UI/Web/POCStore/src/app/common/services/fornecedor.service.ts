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
            // if(cep=='09850090'){
            //     dadosEntrega.maximoDiasEntrega = 15;
            //     dadosEntrega.minimoDiasEntrega = 8;
            //     dadosEntrega.valorFrete = 20.88;
            // }
            // else {
            //     dadosEntrega.maximoDiasEntrega = 10;
            //     dadosEntrega.minimoDiasEntrega = 4;
            //     dadosEntrega.valorFrete = 0;
            // }
            // obs.next(dadosEntrega);
            // obs.complete();
        });
    }
}