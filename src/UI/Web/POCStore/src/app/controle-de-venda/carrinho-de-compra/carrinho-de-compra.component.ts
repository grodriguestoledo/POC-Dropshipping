import { FornecedorService } from './../../common/services/fornecedor.service';
import { PedidoSubItemModel } from '../../common/models/pedido-item-subitem-model';
import { PedidoItemModel } from '../../common/models/pedido-item-model';
import { PedidoCadastroModel } from '../../common/models/pedido-cadastro-model';
import { PedidoService } from '../../common/services/pedido.service';
import { EnderecoModel } from '../../common/models/endereco-model';
import { AutenticacaoService } from '../../common/services/autenticacao.service';
import { CarrinhoDeCompraService } from '../../common/services/carrinho-de-compra.service';
import { Component, OnInit } from '@angular/core';
import { CarrinhoDeCompraModel } from '../../common/models/carrinho-de-compra-model';
import { ClienteService } from '../../common/services/cliente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'venda-carrinho-de-compra',
  templateUrl: './carrinho-de-compra.component.html',
  styleUrls: ['./carrinho-de-compra.component.css']
})
export class CarrinhoDeCompraComponent implements OnInit {

  public itensPorFornecedor = [];
  public enderecosDoCliente = [];
  public enderecoSelecionado: EnderecoModel;
  public estaAutenticado : boolean = false;
  public carrinho: CarrinhoDeCompraModel;
  constructor(
    private router: Router,
    private carrinhoDeCompraService: CarrinhoDeCompraService,
    private autenticacaoService: AutenticacaoService,
    private clienteService: ClienteService,
    private fornecedorService: FornecedorService,
    private pedidoService: PedidoService
  ) {

  }

  ngOnInit() {
    let conta = this.autenticacaoService.obterConta();
    let contaId = conta ? conta.id : undefined;
    this.obterCarrinho(contaId);
    if (conta) {
      this.estaAutenticado = true;
      this.obterEnderecosDoCliente(conta.id);
    }
  }

  obterCarrinho(contaId) {
    this.carrinhoDeCompraService.obterCarrinhoDeCompraSalvo(contaId).subscribe((c) => {
      this.carrinho = c;
      if (!this.carrinho) {
        this.router.navigate(['carrinho-de-compra/vazio'])
        return;
      }
      let fornecedoresUIDDistinct = Array.from(new Set(this.carrinho.itens.map((x) => x.fornecedorUID)));

      for (let i = 0; i < fornecedoresUIDDistinct.length; i++) {
        let fornecedorUID = fornecedoresUIDDistinct[i];
        let itensAComprarDoFornecedor = this.carrinho.itens.filter(x => x.fornecedorUID == fornecedorUID);
        this.itensPorFornecedor.push({ freteCalculado: false, valorFrete: 0, diasMinimosParaEntrega:0, diasMaximosParaEntrega:0,fornecedorUID: fornecedorUID, nome: itensAComprarDoFornecedor[0].fornecedor, itens: itensAComprarDoFornecedor });
      }
      if (this.enderecoSelecionado) {
        this.calcularFreteDosItens(this.enderecoSelecionado);
      }
    });
  }
  obterEnderecosDoCliente(contaId) {
    this.clienteService.obterEnderecos(contaId).subscribe(enderecos => {
      this.enderecosDoCliente = enderecos;
      this.enderecoSelecionado = enderecos.find(x => { return x.ehEnderecoPrincipal });
      this.calcularFreteDosItens(this.enderecoSelecionado);
    });
  }

  calculaValorTotalFornecedorSemFrete(fornecedor) {
    return fornecedor.itens.map(x => x.quantidade * x.precoUnitario).reduce((somaTotal, valorAtual) => somaTotal + valorAtual);
  }
  calculaValorTotalFornecedorComFrete(fornecedor) {
    return fornecedor.itens.map(x => x.quantidade * x.precoUnitario).reduce((somaTotal, valorAtual) => somaTotal + valorAtual) + fornecedor.valorFrete;
  }
  onAlterouEnderecoDaEntrega(endereco) {
    this.calcularFreteDosItens(endereco);
  }
  calcularFreteDosItens(endereco) {
    for (let i = 0; i < this.itensPorFornecedor.length; i++) {
      this.calcularFrete(this.itensPorFornecedor[i], endereco.cep);
    }
  }
  calcularFrete(itemPorFornecedor, cep) {
    this.fornecedorService.obterDadosDeEntrega(itemPorFornecedor.fornecedorUID, cep).subscribe((entrega)=>{
      itemPorFornecedor.freteCalculado = true;
      itemPorFornecedor.valorFrete = entrega.valorFrete;
      itemPorFornecedor.diasMinimosParaEntrega = entrega.minimoDiasEntrega;
      itemPorFornecedor.diasMaximosParaEntrega = entrega.maximoDiasEntrega;
    });
  }

  calcularTotal() {
    let total = 0;
    for (let i = 0; i < this.itensPorFornecedor.length; i++) {
      let fornecedor = this.itensPorFornecedor[i];
      total += fornecedor.itens.map(x => x.quantidade * x.precoUnitario).reduce((somaTotal, valorAtual) => somaTotal + valorAtual) + fornecedor.valorFrete;
    }
    return total;
  }

  checkout() {
    if (!this.estaAutenticado) {
      let url = btoa('carrinho-de-compra');
      this.router.navigate(['autenticar'], { queryParams: { 'redir': url } });
      return;
    }

    let pedido = new PedidoCadastroModel();
    for (let i = 0; i < this.itensPorFornecedor.length; i++) {
      let fornecedorItens = this.itensPorFornecedor[i];
      let itemPedido = new PedidoItemModel(fornecedorItens.fornecedorUID, fornecedorItens.nome,fornecedorItens.valorFrete, fornecedorItens.diasMinimosParaEntrega, fornecedorItens.diasMinimosParaEntrega);
      for (let y = 0; y < fornecedorItens.itens.length; y++) {
        let itemFornecedor = fornecedorItens.itens[y];
        let subitem = new PedidoSubItemModel(itemFornecedor.codigoProduto,itemFornecedor.imagemProduto,itemFornecedor.nomeProduto, itemFornecedor.quantidade,itemFornecedor.precoUnitario);
        itemPedido.subitens.push(subitem);
      }

      pedido.itens.push(itemPedido)
    }
    pedido.enderecoParaEntrega = this.enderecoSelecionado;

    this.pedidoService.registrarPedido(pedido).subscribe(()=>{
      
    });
  }
}
