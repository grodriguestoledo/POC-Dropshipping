import { DetalheProdutoModel } from '../models/detalhe-produto-model';
export class ItemAdicionadoAoCarrinhoEventModel{
    /**
     *
     */
    constructor(public produto : DetalheProdutoModel ,public quantidade?:number) {
        
    }
}