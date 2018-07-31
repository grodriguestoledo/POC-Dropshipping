import { HttpClientService } from './../common/services/http.client.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '../../../node_modules/@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AutenticacaoService } from '../common/services/autenticacao.service';
import { Events } from '../common/events/events';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  providers:[],
  declarations: [LoginComponent]
})
export class ClienteModule { }
