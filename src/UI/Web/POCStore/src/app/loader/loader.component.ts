import { LoaderService } from './../common/services/loader.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit {

  public exibirLoader: boolean = false;
  constructor(private loaderService: LoaderService) {
    this.loaderService.onIniciarLoading.subscribe(() => { this.toggleLoader(true); });
    this.loaderService.onEncerrarLoading.subscribe(() => { this.toggleLoader(false); });
  }

  ngOnInit() {
  }

  toggleLoader(exibir) {
    if (!exibir) {
      window.setTimeout(() => {
        this.exibirLoader = exibir;
      }, 500);
    }
    else this.exibirLoader = exibir;
  }
}
