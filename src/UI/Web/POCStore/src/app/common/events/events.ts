import { EventEmitter, Injectable } from "@angular/core";
import { ContaAutenticadaModel } from "../models/conta-autenticada-model";
import { ItemAdicionadoAoCarrinhoEventModel } from "./item-adicionado-ao-carrinho-event.model";
@Injectable()
export class Events
{
    public usuarioAutenticouEvent = new EventEmitter<ContaAutenticadaModel>(false);
    public usuarioEfetuouLogoffEvent = new EventEmitter<boolean>(false);
    public itemAdicionadoAoCarrinhoEvent = new EventEmitter<ItemAdicionadoAoCarrinhoEventModel>(false);
}