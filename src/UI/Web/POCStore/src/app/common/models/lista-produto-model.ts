export class ListaProdutoModel{
    /**
     *
     */
    //public urlDetalhe : string ;
    constructor(public codigoProduto?:string,public nomeProduto?:string, public preco?:number, public imagemProduto?:string, public fornecedor?:string ) {
  
    }

    public urlDetalhe(){
        return "/#/produtos/" + this.codigoProduto + "/detalhes";
    }
}