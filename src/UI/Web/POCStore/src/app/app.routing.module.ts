import { CarrinhoVazioComponent } from './controle-de-venda/carrinho-vazio/carrinho-vazio.component';
import { LoginComponent } from './cliente/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaProdutosComponent } from './loja/lista-produtos/lista-produtos.component';
import { DetalheProdutoComponent } from './loja/detalhe-produto/detalhe-produto.component';
import { ProdutoNaoEncontradoComponent } from './loja/produto-nao-encontrado/produto-nao-encontrado.component';
import { ErroComponent } from './erro/erro.component';
import { CarrinhoDeCompraComponent } from './controle-de-venda/carrinho-de-compra/carrinho-de-compra.component';

const appRoutes: Routes = [
    {
        path:'loja',
        component:ListaProdutosComponent
    },
    {
        path:'',
        component:ListaProdutosComponent
    },
    {
        path:'autenticar',
        component:LoginComponent
    },
    {
        path:'produtos/:codigoProduto/detalhes',
        component:DetalheProdutoComponent
    },
    {
        path:'loja/produto-nao-encontrado',
        component:ProdutoNaoEncontradoComponent
    },
    {
        path:'carrinho-de-compra',
        component:CarrinhoDeCompraComponent
    },
    {
        path:'carrinho-de-compra/vazio',
        component:CarrinhoVazioComponent
    },
    {
        path:'**',
        component:ErroComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, { useHash: true })],
    exports: [RouterModule]
})
  export class AppRoutingModule { }