import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoDeCompraComponent } from './carrinho-de-compra/carrinho-de-compra.component';
import { FormsModule } from '@angular/forms';
import { CarrinhoVazioComponent } from './carrinho-vazio/carrinho-vazio.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [CarrinhoDeCompraComponent, CarrinhoVazioComponent]
})
export class ControleDeVendaModule { }
