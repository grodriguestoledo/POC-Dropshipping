import { EnderecoModel } from './endereco-model';
import { PedidoItemModel } from './pedido-item-model';
export class PedidoCadastroModel {
    
    public itens?: PedidoItemModel[]= [];
    /**
     *
     */
    constructor(public codigoPedido?:string,public enderecoParaEntrega?:  EnderecoModel) {
        
        
    }
}