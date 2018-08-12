import { LoaderService } from './common/services/loader.service';
import { ClienteService } from './common/services/cliente.service';
import { CarrinhoDeCompraService } from './common/services/carrinho-de-compra.service';
import { ErroComponent } from './erro/erro.component';

import { AppRoutingModule } from './app.routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuTopoComponent } from './menu-topo/menu-topo.component';
import { LojaModule } from './loja/loja.module';
import { ClienteModule } from './cliente/cliente.module';
import { Events } from './common/events/events';
import { AutenticacaoService } from './common/services/autenticacao.service';
import { ControleDeVendaModule } from './controle-de-venda/controle-de-venda.module';
import { PedidoService } from './common/services/pedido.service';
import { LoaderComponent } from './loader/loader.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuTopoComponent,
    ErroComponent,
    LoaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LojaModule,
    ClienteModule,
    ControleDeVendaModule
    
  ],
  providers: [Events,AutenticacaoService,CarrinhoDeCompraService, ClienteService,PedidoService, LoaderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
