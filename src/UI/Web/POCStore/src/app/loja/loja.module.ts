import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuscaProdutosComponent } from './busca-produtos/busca-produtos.component';
import { ListaProdutosComponent } from './lista-produtos/lista-produtos.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports:[
    BuscaProdutosComponent
  ],
  declarations: [BuscaProdutosComponent, ListaProdutosComponent]
})
export class LojaModule { }
