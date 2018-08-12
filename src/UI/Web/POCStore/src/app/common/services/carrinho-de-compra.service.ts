import { DetalheProdutoModel } from '../models/detalhe-produto-model';
import { CarrinhoDeCompraModel } from '../models/carrinho-de-compra-model';
import { Injectable } from '@angular/core';
import { HttpClientService } from './http.client.service';
import { Events } from '../events/events';
import { Observable } from 'rxjs';
import { ItemAdicionadoAoCarrinhoEventModel } from '../events/item-adicionado-ao-carrinho-event.model';
import { AutenticacaoService } from './autenticacao.service';
import { ItemCarrinhoDeCompraModel } from '../models/item-carrinho-de-compra-model';
import { ContaAutenticadaModel } from '../models/conta-autenticada-model';
@Injectable()
export class CarrinhoDeCompraService {
    public carrinhoKey: string = "cart";
    constructor(
        private httpClient: HttpClientService,
        private autenticacaoService: AutenticacaoService,
        private events: Events) {
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
                    this.salvarCarrinhoDeCompraLocalStorage(carrinho);

                    this.salvarCarrinhoDeCompraServidor(conta.id, carrinho).subscribe(() => {
                        let eventArg = new ItemAdicionadoAoCarrinhoEventModel(produto, quantidade);
                        this.events.itemAdicionadoAoCarrinhoEvent.emit(eventArg);
                        obs.next(carrinho);
                        obs.complete();
                    });
                });
            }
            else {

                let carrinhoSalvoStr = window.localStorage.getItem(this.carrinhoKey);
                console.log(carrinhoSalvoStr);
                let carrinhoJSON = !carrinhoSalvoStr ? undefined : JSON.parse(carrinhoSalvoStr);
                let carrinho = carrinhoJSON ? new CarrinhoDeCompraModel(carrinhoJSON.precoTotalDoCarrinhoSemFrete) : new CarrinhoDeCompraModel();

                if (carrinho && carrinhoJSON.itens && carrinhoJSON.itens.length) {
                    for (let i = 0; i < carrinhoJSON.itens.length; i++) {
                        let item = carrinhoJSON.itens[i];
                        carrinho.itens.push(new ItemCarrinhoDeCompraModel(item.codigoProduto, item.nomeProduto, item.quantidade, item.precoUnitario, item.fornecedorUID, item.fornecedor, item.imagemProduto));
                    }
                }

                carrinho.adicionarProdutoAoCarrinho(produto, quantidade);
                this.salvarCarrinhoDeCompraLocalStorage(carrinho);
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
                let carrinhoSalvoStr = window.localStorage.getItem(this.carrinhoKey);
                console.log(carrinhoSalvoStr);
                let carrinhoJSON = !carrinhoSalvoStr ? undefined : JSON.parse(carrinhoSalvoStr);
                let carrinho = carrinhoJSON ? new CarrinhoDeCompraModel(carrinhoJSON.precoTotalDoCarrinhoSemFrete) : undefined;

                if (carrinho) {
                    for (let i = 0; i < carrinhoJSON.itens.length; i++) {
                        let item = carrinhoJSON.itens[i];
                        carrinho.itens.push(new ItemCarrinhoDeCompraModel(item.codigoProduto, item.nomeProduto, item.quantidade, item.precoUnitario, item.fornecedorUID, item.fornecedor, item.imagemProduto));
                    }
                }

                obs.next(carrinho);
                obs.complete();
            }
        });
    }

    

    private salvarCarrinhoDeCompraServidor(clienteUID: string, carrinho: CarrinhoDeCompraModel): Observable<any> {
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
    private salvarCarrinhoDeCompraLocalStorage(carrinho) {
        window.localStorage.setItem(this.carrinhoKey, JSON.stringify(carrinho));
    }
    private onUsuarioAutenticouEventHandler(conta: ContaAutenticadaModel) {
        let carrinhoSalvoStr = window.localStorage.getItem(this.carrinhoKey);
        let carrinho = !carrinhoSalvoStr ? undefined : JSON.parse(carrinhoSalvoStr) as CarrinhoDeCompraModel;

        if (carrinho) {
            this.salvarCarrinhoDeCompraServidor(conta.id, carrinho).subscribe(() => {
            });
        }
    }
}