import { PedidoService } from './../../common/services/pedido.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'venda-historico-pedidos',
  templateUrl: './historico-pedidos.component.html',
  styleUrls: ['./historico-pedidos.component.css']
})
export class HistoricoPedidosComponent implements OnInit {

  public listaDePedidos = [];
  constructor(private pedidoService : PedidoService) { }

  ngOnInit() {
    this.pedidoService.obterMeusPedidos().subscribe((res)=>{
      this.listaDePedidos = res;
    });
  }

}
