import { LoginComponent } from './cliente/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaProdutosComponent } from './loja/lista-produtos/lista-produtos.component';

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
    }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, { useHash: true })],
    exports: [RouterModule]
})
  export class AppRoutingModule { }