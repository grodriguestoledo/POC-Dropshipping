import { EventEmitter, Injectable } from "@angular/core";
import { ContaAutenticadaModel } from "../models/conta-autenticada-model";
@Injectable()
export class Events
{
    public usuarioAutenticouEvent = new EventEmitter<ContaAutenticadaModel>(false);
    public usuarioEfetuouLogoffEvent = new EventEmitter<boolean>(false);
}