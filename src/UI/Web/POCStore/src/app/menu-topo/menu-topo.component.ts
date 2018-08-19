import { CarrinhoDeCompraService } from '../common/services/carrinho-de-compra.service';
import { Component, OnInit } from '@angular/core';
import { Events } from '../common/events/events';
import { ContaAutenticadaModel } from '../common/models/conta-autenticada-model';
import { AutenticacaoService } from '../common/services/autenticacao.service';
import { ItemAdicionadoAoCarrinhoEventModel } from '../common/events/item-adicionado-ao-carrinho-event.model';

@Component({
  selector: 'store-menu-topo',
  templateUrl: './menu-topo.component.html',
  styleUrls: ['./menu-topo.component.css']
})
export class MenuTopoComponent implements OnInit {

  public itensNoCarrinho: number = 0;
  public conta: ContaAutenticadaModel = undefined;
  constructor(private events: Events, private autenticacaoService: AutenticacaoService, private carrinhoDeCompraService: CarrinhoDeCompraService) { }

  ngOnInit() {
    this.events.usuarioAutenticouEvent.subscribe((res) => { this.onUsuarioAutenticadoHandler(res); });
    this.events.usuarioEfetuouLogoffEvent.subscribe(() => { this.onUsuarioLogoffHandler(); });
    this.events.itemAdicionadoAoCarrinhoEvent.subscribe((event: ItemAdicionadoAoCarrinhoEventModel) => { this.onItemAdicionadoAoCarrinho(event); });
    this.events.carrinhoEsvaziadoEvent.subscribe(()=>{ this.onCarrinhoEsvaziado();});
    this.conta = this.autenticacaoService.obterConta() as ContaAutenticadaModel;

    let clienteUID = this.conta != undefined ? this.conta.id : undefined;
    this.carrinhoDeCompraService.obterCarrinhoDeCompraSalvo(clienteUID).subscribe((carrinho) => {
      if (carrinho)
        this.itensNoCarrinho = carrinho.itens.length;
    });

  }

  sair() {
    this.autenticacaoService.efetuarLogoff();
  }

  onUsuarioAutenticadoHandler(contaAutenticada: ContaAutenticadaModel) {
    this.conta = contaAutenticada;
  }
  onUsuarioLogoffHandler() {
    this.conta = undefined;
  }

  onItemAdicionadoAoCarrinho(event: ItemAdicionadoAoCarrinhoEventModel) {
    this.itensNoCarrinho += event.quantidade;
  }

  onCarrinhoEsvaziado(){
    this.itensNoCarrinho =0;
  }
}
