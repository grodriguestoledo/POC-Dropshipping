import { AutenticacaoService } from './../../common/services/autenticacao.service';
import { CarrinhoDeCompraService } from './../../common/services/carrinho-de-compra.service';
import { Component, OnInit } from '@angular/core';
import { CarrinhoDeCompraModel } from '../../common/models/carrinho-de-compra-model';

@Component({
  selector: 'venda-carrinho-de-compra',
  templateUrl: './carrinho-de-compra.component.html',
  styleUrls: ['./carrinho-de-compra.component.css']
})
export class CarrinhoDeCompraComponent implements OnInit {

  private itensPorFornecedor = [];

  private carrinho: CarrinhoDeCompraModel;
  constructor(private carrinhoDeCompraService: CarrinhoDeCompraService, private autenticacaoService: AutenticacaoService) {

  }

  ngOnInit() {
    let conta = this.autenticacaoService.obterConta();
    if (conta) {
      this.carrinhoDeCompraService.obterCarrinhoDeCompraSalvo(conta.id).subscribe((c) => {
        this.carrinho = c;
        // this.fornecedores = this.carrinho.itens.map((x) => ( { fornecedorUID: x.fornecedorUID, fornecedor:x.fornecedor }));

        let fornecedoresUIDDistinct = Array.from(new Set(this.carrinho.itens.map((x) => x.fornecedorUID)));

        for (let i = 0; i < fornecedoresUIDDistinct.length; i++) {
          let fornecedorUID = fornecedoresUIDDistinct[i];
          let itensAComprarDoFornecedor = this.carrinho.itens.filter(x => x.fornecedorUID == fornecedorUID);
          this.itensPorFornecedor.push({ valorFrete :0, fornecedorUID: fornecedorUID, nome:itensAComprarDoFornecedor[0].fornecedor, itens: itensAComprarDoFornecedor });
        }
    
      });
    }
  }

  calculaValorTotalFornecedor(fornecedor){

  return fornecedor.itens.map(x=>x.quantidade * x.precoUnitario).reduce((somaTotal,valorAtual)=> somaTotal + valorAtual);
  }

}
