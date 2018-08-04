import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'store-busca-produtos',
  templateUrl: './busca-produtos.component.html',
  styleUrls: ['./busca-produtos.component.css']
})
export class BuscaProdutosComponent implements OnInit {

  public busca : string;
  constructor(private router: Router, private route: ActivatedRoute) 
  { 
     
  }

  ngOnInit() {
    this.route.queryParamMap.subscribe((params) => {
      let f = params.get('f');
      this.busca=f;
     });
  }

  buscarProdutos(form) {
    if (form.value.busca != '') this.router.navigate(['/loja'], { queryParams: { 'f': form.value.busca } });
    else this.router.navigate(['/loja']);
  }
}
