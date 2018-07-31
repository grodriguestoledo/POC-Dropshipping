import { Component, OnInit } from '@angular/core';
import { Events } from '../common/events/events';
import { ContaAutenticadaModel } from '../common/models/conta-autenticada-model';
import { AutenticacaoService } from '../common/services/autenticacao.service';

@Component({
  selector: 'store-menu-topo',
  templateUrl: './menu-topo.component.html',
  styleUrls: ['./menu-topo.component.css']
})
export class MenuTopoComponent implements OnInit {

  public conta : ContaAutenticadaModel = undefined;
  constructor(private events : Events, private autenticacaoService:AutenticacaoService) { }

  ngOnInit() {
    this.events.usuarioAutenticouEvent.subscribe((res)=>{this.onUsuarioAutenticadoHandler(res);});
    this.events.usuarioEfetuouLogoffEvent.subscribe(()=>{this.onUsuarioLogoffHandler();})
    this.conta = this.autenticacaoService.obterConta() as ContaAutenticadaModel;
  }

  sair(){
    this.autenticacaoService.efetuarLogoff();
  }

  onUsuarioAutenticadoHandler(contaAutenticada:ContaAutenticadaModel){
 
    this.conta = contaAutenticada;
  }
  onUsuarioLogoffHandler(){
    this.conta = undefined;
  }
}
