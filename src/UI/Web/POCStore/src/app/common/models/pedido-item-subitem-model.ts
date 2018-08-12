export class PedidoSubItemModel {
    /**
     *
     */
    constructor(
        public codigoProduto?: string, 
        public imagemProduto?:string,
        public nomeProduto ?:string,
        public quantidade?: number, 
        public precoUnitario?: number) {

    }
}