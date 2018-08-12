import { CarrinhoDeCompraService } from '../../common/services/carrinho-de-compra.service';
import { ItemAdicionadoAoCarrinhoEventModel } from '../../common/events/item-adicionado-ao-carrinho-event.model';
import { DetalheProdutoModel } from '../../common/models/detalhe-produto-model';
import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../common/services/produto.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Events } from '../../common/events/events';

@Component({
  selector: 'store-detalhe-produto',
  templateUrl: './detalhe-produto.component.html',
  styleUrls: ['./detalhe-produto.component.css']
})
export class DetalheProdutoComponent implements OnInit {

  public produto: DetalheProdutoModel;
  public quantidade : number = 1;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private produtoService: ProdutoService,
    private events: Events,
    private carrinhoDeCompraService : CarrinhoDeCompraService
    ) {


  }

  ngOnInit() {
    this.route.paramMap.subscribe(params=>{
      let codigoProduto = params.get('codigoProduto');
      this.produtoService.obterProdutoDetalhe(codigoProduto).subscribe((response)=>{
        this.produto = response;
      });
    })
  }

  onComprarClick(){
    this.carrinhoDeCompraService.adicionarItemAoCarrinho(this.produto,this.quantidade).subscribe((carrinho)=>{
      this.router.navigate(['carrinho-de-compra']);
    });
  }
}
