using System;

namespace Fornecedores.API.Domain
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public Guid CodigoFornecedor { get; set; }
        public string Nome { get; set; }
    }
}