export class ItemCarrinhoDeCompraModel
{
    /**
     *
     */
    constructor(public codigoProduto : string, public nomeProduto?:string, public quantidade?:number,public precoUnitario?:number,public fornecedorUID?:string, public fornecedor?:string, public imagemProduto?:string) {
       
    }
}