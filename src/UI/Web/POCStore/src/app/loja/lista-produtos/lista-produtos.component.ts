import { Component, OnInit } from '@angular/core';
import { ListaProdutoModel } from '../models/lista-produto-model';

@Component({
  selector: 'store-lista-produtos',
  templateUrl: './lista-produtos.component.html',
  styleUrls: ['./lista-produtos.component.css']
})
export class ListaProdutosComponent implements OnInit {

  private listaDeProdutos : Array<ListaProdutoModel>;
  constructor() { 
    this.listaDeProdutos = [];
    this.listaDeProdutos.push(new ListaProdutoModel("Produto01",12,"https://www.petlove.com.br/images/products/171069/product/Sanitario-Higienico-Pet-Injet-Xixi-Pets-Premium---Rosa.jpg?1495043600","Whiskas"));
    this.listaDeProdutos.push(new ListaProdutoModel("Ração Golden Gatos Adultos Castrados Salmão - 1 Kg",8.99,"https://www.petlove.com.br/images/products/183166/small/3110240-1.jpg?1495064063","Golden"));
    this.listaDeProdutos.push(new ListaProdutoModel("Produto03",12,"https://www.petlove.com.br/images/products/171069/product/Sanitario-Higienico-Pet-Injet-Xixi-Pets-Premium---Rosa.jpg?1495043600"));
    this.listaDeProdutos.push(new ListaProdutoModel("Produto04",12,"https://www.petlove.com.br/images/products/171069/product/Sanitario-Higienico-Pet-Injet-Xixi-Pets-Premium---Rosa.jpg?1495043600"));
    this.listaDeProdutos.push(new ListaProdutoModel("Produto05",12,"https://www.petlove.com.br/images/products/171069/product/Sanitario-Higienico-Pet-Injet-Xixi-Pets-Premium---Rosa.jpg?1495043600"));
  }

  ngOnInit() {
  }


}
