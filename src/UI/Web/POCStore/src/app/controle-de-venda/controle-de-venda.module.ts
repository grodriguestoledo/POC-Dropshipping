import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoDeCompraComponent } from './carrinho-de-compra/carrinho-de-compra.component';
import { FormsModule } from '../../../node_modules/@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [CarrinhoDeCompraComponent]
})
export class ControleDeVendaModule { }
