import { DetalheProdutoModel } from './../models/detalhe-produto-model';
import { CarrinhoDeCompraModel } from './../models/carrinho-de-compra-model';
import { Injectable } from '@angular/core';
import { HttpClientService } from './http.client.service';
import { Events } from '../events/events';
import { Observable } from '../../../../node_modules/rxjs';
import { ItemAdicionadoAoCarrinhoEventModel } from '../events/item-adicionado-ao-carrinho-event.model';
import { AutenticacaoService } from './autenticacao.service';
import { ItemCarrinhoDeCompraModel } from '../models/item-carrinho-de-compra-model';
import { ContaAutenticadaModel } from '../models/conta-autenticada-model';
@Injectable()
export class CarrinhoDeCompraService {
    constructor(
        private httpClient: HttpClientService,
        private autenticacaoService: AutenticacaoService,
        private events: Events) {
        console.log('criou o evento');
        events.usuarioAutenticouEvent.subscribe((conta) => { this.onUsuarioAutenticouEventHandler(conta); })

    }

    adicionarItemAoCarrinho(produto: DetalheProdutoModel, quantidade: number): Observable<CarrinhoDeCompraModel> {
        return new Observable((obs) => {
            if (this.autenticacaoService.estaAutenticado()) {
                let conta = this.autenticacaoService.obterConta();
                this.obterCarrinhoDeCompraSalvo(conta.id).subscribe((carrinho) => {
                    if (!carrinho) {
                        carrinho = new CarrinhoDeCompraModel();
                    }
                    carrinho.adicionarProdutoAoCarrinho(produto, quantidade);
                    this.salvarCarrinhoDeCompra(conta.id, carrinho).subscribe(() => {
                        let eventArg = new ItemAdicionadoAoCarrinhoEventModel(produto, quantidade);
                        this.events.itemAdicionadoAoCarrinhoEvent.emit(eventArg);
                        obs.next(carrinho);
                        obs.complete();
                    });
                });
            }
            else {
                let carrinhoKey = "cart";
                let carrinhoSalvoStr = window.localStorage.getItem(carrinhoKey);
                let carrinho = !carrinhoSalvoStr ? new CarrinhoDeCompraModel() : JSON.parse(carrinhoSalvoStr) as CarrinhoDeCompraModel;

                carrinho.adicionarProdutoAoCarrinho(produto, quantidade);
                window.localStorage.setItem(carrinhoKey, JSON.stringify(carrinho));
                let eventArg = new ItemAdicionadoAoCarrinhoEventModel(produto, quantidade);
                this.events.itemAdicionadoAoCarrinhoEvent.emit(eventArg);
                obs.next(carrinho);
                obs.complete();
            }
        });

    }

    obterCarrinhoDeCompraSalvo(clienteUID?: string): Observable<CarrinhoDeCompraModel> {
        return new Observable((obs) => {

            if (this.autenticacaoService.estaAutenticado() && clienteUID) {
                this.httpClient.get('/carrinho/' + clienteUID).subscribe((res: CarrinhoDeCompraModel) => {
                    if (res) {
                        let carrinho = new CarrinhoDeCompraModel(res.precoTotalDoCarrinhoSemFrete);
                        carrinho.itens = res.itens;
                        obs.next(carrinho);
                    }
                    else
                        obs.next(undefined);

                    obs.complete();
                }, (er) => {
                    console.log(er);
                    obs.next(undefined);
                    obs.complete();
                });
            }
            else {
                let carrinhoKey = "cart";
                let carrinhoSalvoStr = window.localStorage.getItem(carrinhoKey);
                let carrinho = !carrinhoSalvoStr ? undefined : JSON.parse(carrinhoSalvoStr) as CarrinhoDeCompraModel;
                obs.next(carrinho);
                obs.complete();
            }
        });
    }
    private salvarCarrinhoDeCompra(clienteUID: string, carrinho: CarrinhoDeCompraModel): Observable<any> {
        return new Observable((obs) => {
            this.httpClient.post('/carrinho/' + clienteUID, carrinho).subscribe((res) => {
                obs.next(true);
                obs.complete();
            }, (er) => {
                console.log(er);
                obs.next(false);
                obs.complete();
            });

        });
    }

    private onUsuarioAutenticouEventHandler(conta: ContaAutenticadaModel) {
        let carrinhoKey = "cart";
        let carrinhoSalvoStr = window.localStorage.getItem(carrinhoKey);
        let carrinho = !carrinhoSalvoStr ? undefined : JSON.parse(carrinhoSalvoStr) as CarrinhoDeCompraModel;

        if (carrinho) {
            this.salvarCarrinhoDeCompra(conta.id, carrinho).subscribe(() => {
                window.localStorage.removeItem(carrinhoKey);
            });
        }
    }
}