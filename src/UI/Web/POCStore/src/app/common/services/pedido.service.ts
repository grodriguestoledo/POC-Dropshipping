import { ListaPedidoModel } from './../models/pedidos/lista-pedido-model';
import { DetalheProdutoModel } from '../models/detalhe-produto-model';
import { ListaProdutoModel } from '../models/lista-produto-model';
import { Injectable } from "@angular/core";
import { HttpClientService } from "./http.client.service";
import { Observable } from 'rxjs';
import { PedidoCadastroModel } from '../models/pedido-cadastro-model';

@Injectable()
export class PedidoService {
    constructor(private httpClient: HttpClientService) {

    }

    registrarPedido(pedido : PedidoCadastroModel) : Observable<any>{
        return new Observable((obs)=>{
            this.httpClient.post('/pedidos',pedido).subscribe((pedido)=>{
                obs.next(pedido);
                obs.complete();
            })
        });
    }

    obterMeusPedidos() : Observable<ListaPedidoModel[]>{
        return new Observable((obs)=>{
            this.httpClient.get('/pedidos/meus-pedidos').subscribe((res:ListaPedidoModel[])=>{
                let pedidos = res.map(x=>new ListaPedidoModel(x.codigoPedido,x.dataPedido,x.valorTotal,x.dataAtualizacao,x.status, this.statusPedido(x.status),x.pedidoId));
                obs.next(pedidos);
                obs.complete();
            });
        });
    }

     statusPedido(status:number) : string{
        let statusStr = "";

        switch(status)
        {
            case 1: return "Aguardando pagamento";
            case 2: return "Aguardando fornecedores";
            case 3: return "Em trânsito";
            case 4: return "Concluído";
        }

        return statusStr;
    }
}