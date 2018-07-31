import { ContaAutenticadaModel } from './../../common/models/conta-autenticada-model';
import { Component, OnInit } from '@angular/core';
import { AutenticacaoService } from '../../common/services/autenticacao.service';
import { Events } from '../../common/events/events';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private autenticacaoService: AutenticacaoService, private events : Events, private router : Router) { }

  ngOnInit() {
    this.events.usuarioAutenticouEvent.subscribe((res)=>{this.onUsuarioAutenticadoHandler(res);});
  }

  autenticar(form) {
    this.autenticacaoService.autenticar(form.value.email,form.value.senha);
  }

  onUsuarioAutenticadoHandler(conta:ContaAutenticadaModel){
    this.router.navigate(['']);
  }
}
