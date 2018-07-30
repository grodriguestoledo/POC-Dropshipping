
import { AppRoutingModule } from './app.routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuTopoComponent } from './menu-topo/menu-topo.component';
import { LojaModule } from './loja/loja.module';
import { ClienteModule } from './cliente/cliente.module';


@NgModule({
  declarations: [
    AppComponent,
    MenuTopoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LojaModule,
    ClienteModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
