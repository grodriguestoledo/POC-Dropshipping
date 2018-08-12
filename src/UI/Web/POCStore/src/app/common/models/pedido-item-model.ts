import { PedidoSubItemModel } from './pedido-item-subitem-model';
export class PedidoItemModel {
    public subitens?: PedidoSubItemModel[] = [];
    /**
     *
     */
    constructor(public fornecedorUID?:string, public fornecedor?:string, public valorFrete?:number, public prazoMinimoEntrega?:number,public prazoMaximoEntrega?:number) {
        
    }
}