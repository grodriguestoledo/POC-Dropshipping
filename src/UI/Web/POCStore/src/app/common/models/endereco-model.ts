export class EnderecoModel {
    /**
     *
     */
    constructor(public enderecoId?:number,
        public bairro?:string,
        public cep?:string,
        public cidade?:string,
        public complemento?:string,
        public descricao?:string,
        public ehEnderecoPrincipal?:boolean,
        public logradouro?:string,
        public numero?:string,
        public uf?:string,
        public uid?:string
    ) {
      
    }
}