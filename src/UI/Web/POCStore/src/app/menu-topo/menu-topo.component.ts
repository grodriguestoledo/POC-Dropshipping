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

  public itensNoCarrinho : number = 0;
  public conta: ContaAutenticadaModel = undefined;
  constructor(private events: Events, private autenticacaoService: AutenticacaoService) { }

  ngOnInit() {
    this.events.usuarioAutenticouEvent.subscribe((res) => { this.onUsuarioAutenticadoHandler(res); });
    this.events.usuarioEfetuouLogoffEvent.subscribe(() => { this.onUsuarioLogoffHandler(); })
    this.events.itemAdicionadoAoCarrinhoEvent.subscribe((event:ItemAdicionadoAoCarrinhoEventModel) => { this.onItemAdicionadoAoCarrinho(event);})
    this.conta = this.autenticacaoService.obterConta() as ContaAutenticadaModel;
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

  onItemAdicionadoAoCarrinho(event:ItemAdicionadoAoCarrinhoEventModel) {
    this.itensNoCarrinho += event.quantidade;
  }
}
