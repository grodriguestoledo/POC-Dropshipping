using System;

namespace Cliente.API.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; } 
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public bool EhEnderecoPrincipal { get; set; }
        public Guid UID { get; set; }
        public string Descricao { get; set; }
    }
}