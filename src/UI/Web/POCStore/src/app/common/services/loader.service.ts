import { EventEmitter } from '@angular/core';
import { Injectable } from "../../../../node_modules/@angular/core";

@Injectable()
export class LoaderService{

    public onIniciarLoading : EventEmitter<any> = new EventEmitter();
    public onEncerrarLoading : EventEmitter<any> = new EventEmitter();

    public totalRequisicoes : number = 0;
    /**
     *
     */
    constructor() {
    }
    
    iniciarRequisicao(){
        this.totalRequisicoes += 1;
        this.onIniciarLoading.emit();
    }

    encerrarRequisicao(){
        this.totalRequisicoes -=1;
        if(this.totalRequisicoes == 0)
            this.onEncerrarLoading.emit();
    }

}