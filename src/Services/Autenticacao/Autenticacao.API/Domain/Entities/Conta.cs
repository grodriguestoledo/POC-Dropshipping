using System;

namespace Autenticacao.API.Domain.Entities
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public EnumTipoConta TipoConta { get; set; }
        public Guid ContaUID {get;set;}

        public string NomeCompleto
        {
            get
            {
                return this.Nome + " " + this.Sobrenome;
            }
        }

        public bool ConferirSenha(string tentativaDeSenha)
        {
            return this.Senha.Equals(tentativaDeSenha);
        }

        public bool EhCliente()
        {
            return TipoConta == EnumTipoConta.Cliente;
        }
    }
}