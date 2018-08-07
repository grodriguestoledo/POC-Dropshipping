using System;
using System.Collections.Generic;

namespace Cliente.API.Domain.Entities
{
    public class Cliente
    {
        public Guid ContaUID {get;set;}
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public ICollection<Endereco> Enderecos {get;set;}
        public ICollection<MetodoDePagamento> MetodosDePagamento {get;set;}
    }
}