import { DetalheProdutoModel } from './../../common/models/detalhe-produto-model';
import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../common/services/produto.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'store-detalhe-produto',
  templateUrl: './detalhe-produto.component.html',
  styleUrls: ['./detalhe-produto.component.css']
})
export class DetalheProdutoComponent implements OnInit {

  public produto: DetalheProdutoModel;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private produtoService: ProdutoService) {


  }

  ngOnInit() {
    this.route.paramMap.subscribe(params=>{
      let codigoProduto = params.get('codigoProduto');
      this.produtoService.obterProdutoDetalhe(codigoProduto).subscribe((response)=>{
        this.produto = response;
      });
    })
  }

}
