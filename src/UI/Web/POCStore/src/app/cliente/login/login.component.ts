import { ContaAutenticadaModel } from '../../common/models/conta-autenticada-model';
import { Component, OnInit } from '@angular/core';
import { AutenticacaoService } from '../../common/services/autenticacao.service';
import { Events } from '../../common/events/events';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public urlRedirPosLogin: string;
  constructor(
    private autenticacaoService: AutenticacaoService,
    private events: Events,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    console.log('oie');
    this.route.queryParamMap.subscribe((params) => {
      let paramUrl = params.get('redir');
      if (paramUrl && paramUrl != '') {
        this.urlRedirPosLogin = atob(paramUrl);
      }
    });
    this.events.usuarioAutenticouEvent.subscribe((res) => { this.onUsuarioAutenticadoHandler(res); });
  }

  autenticar(form) {
    this.autenticacaoService.autenticar(form.value.email, form.value.senha);
  }

  onUsuarioAutenticadoHandler(conta: ContaAutenticadaModel) {
    if (this.urlRedirPosLogin && this.urlRedirPosLogin != '') {
      this.router.navigateByUrl(this.urlRedirPosLogin);
    }
    else this.router.navigate(['']);
  }
}
