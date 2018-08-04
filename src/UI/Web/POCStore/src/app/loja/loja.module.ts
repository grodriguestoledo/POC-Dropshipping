import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BuscaProdutosComponent } from './busca-produtos/busca-produtos.component';
import { ListaProdutosComponent } from './lista-produtos/lista-produtos.component';
import { DetalheProdutoComponent } from './detalhe-produto/detalhe-produto.component';
import { ProdutoService } from '../common/services/produto.service';
import { FormsModule } from '@angular/forms';
import { ProdutoNaoEncontradoComponent } from './produto-nao-encontrado/produto-nao-encontrado.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    BuscaProdutosComponent
  ],
  declarations: [BuscaProdutosComponent, ListaProdutosComponent, DetalheProdutoComponent, ProdutoNaoEncontradoComponent],
  providers:[ProdutoService]
})
export class LojaModule { }
