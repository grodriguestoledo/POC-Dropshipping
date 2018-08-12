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
                console.log(pedido);
                obs.next(pedido);
                obs.complete();
            })
        });
    }
}