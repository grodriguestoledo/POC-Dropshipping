import { PedidoService } from './../../services/pedido.service';
export class ListaPedidoModel
{
    public statusPedidoStr:string;
    /**
     *
     */
    constructor(public codigoPedido?:string, public dataPedido?:Date, public valorTotal?:number, public dataAtualizacao?:Date ,public status?:number, public statusStr?:string, public pedidoId?:number) {
    }


}