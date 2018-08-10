import { DetalheProdutoModel } from './detalhe-produto-model';
import { ItemCarrinhoDeCompraModel } from "./item-carrinho-de-compra-model";

export class CarrinhoDeCompraModel{
    
    public itens : Array<ItemCarrinhoDeCompraModel>;
    constructor(public precoTotalDoCarrinhoSemFrete?:number) {
        this.itens = [];
    }

    adicionarProdutoAoCarrinho(produto:DetalheProdutoModel,quantidade:number) : CarrinhoDeCompraModel{
        console.log(produto);
        let idxProduto = this.itens.findIndex(p => {return p.codigoProduto == produto.codigoProduto; });
        console.log(idxProduto);
        if (idxProduto == -1) {
            this.itens.push(new ItemCarrinhoDeCompraModel(produto.codigoProduto,produto.nomeProduto, quantidade, produto.preco, produto.fornecedorUID, produto.fornecedor,produto.imagemProduto));
        }
        else {
            this.itens[idxProduto].quantidade += quantidade;
        }

        return this;
    }
}