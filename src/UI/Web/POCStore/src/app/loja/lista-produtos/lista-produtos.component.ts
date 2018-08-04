import { Component, OnInit } from '@angular/core';
import { ListaProdutoModel } from '../../common/models/lista-produto-model';
import { ProdutoService } from '../../common/services/produto.service';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';


@Component({
  selector: 'store-lista-produtos',
  templateUrl: './lista-produtos.component.html',
  styleUrls: ['./lista-produtos.component.css']
})
export class ListaProdutosComponent implements OnInit {

  public listaDeProdutos: Array<ListaProdutoModel>;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private produtoService: ProdutoService) {
    this.listaDeProdutos = [];

    this.route.queryParamMap.subscribe((params) => {
      let filtro = params.get('f');

      this.produtoService.obterProdutos(filtro).subscribe(produtos => {
        this.listaDeProdutos = produtos;
        if(this.listaDeProdutos.length == 0) {
            router.navigate(['/loja/produto-nao-encontrado'],{preserveQueryParams:true});
        }
      });

    });
  }

  ngOnInit() {
  }


}
