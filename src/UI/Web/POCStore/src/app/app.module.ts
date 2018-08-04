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


@NgModule({
  declarations: [
    AppComponent,
    MenuTopoComponent,
    ErroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LojaModule,
    ClienteModule
  ],
  providers: [Events,AutenticacaoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
