import { DetalheProdutoModel } from '../models/detalhe-produto-model';
import { ListaProdutoModel } from '../models/lista-produto-model';
import { Injectable } from "@angular/core";
import { HttpClientService } from "./http.client.service";
import { Observable } from 'rxjs';

@Injectable()
export class ProdutoService {
    constructor(private httpClient: HttpClientService) {

    }

    obterProdutos(filtro ?:string): Observable<ListaProdutoModel[]> {
        return new Observable<ListaProdutoModel[]>(obs => {
            let url = '/produtos';
            if(filtro != null && filtro != '') url+='?f=' + filtro;
            this.httpClient.get(url).subscribe((res: ListaProdutoModel[]) => {
                let retorno = res.map(m=>{
                    return new ListaProdutoModel(m.codigoProduto,m.nomeProduto,m.preco,m.imagemProduto,m.fornecedor,m.fornecedorUID);
                });
                obs.next(retorno);
                obs.complete();
            },(er)=>{
                if(er.status==404) {
                    obs.next([]);
                    obs.complete();
                }
            });
        });
    }

    obterProdutoDetalhe(codigoProduto : string): Observable<DetalheProdutoModel> {
        return new Observable<DetalheProdutoModel>(obs => {
            this.httpClient.get('/produtos/' + codigoProduto).subscribe((res: DetalheProdutoModel) => {
                let retorno = new DetalheProdutoModel(res.codigoProduto,res.nomeProduto,res.preco,res.imagemProduto,res.fornecedor,res.descricao,res.detalhes,res.fornecedorUID);
                obs.next(retorno);
                obs.complete();
            },(er)=>{
                if(er.status==404) {
                    obs.next(undefined);
                    obs.complete();
                }
            });
        });
    }
}