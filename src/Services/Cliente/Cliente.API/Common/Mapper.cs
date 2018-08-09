using Cliente.API.Domain.Entities;
using Cliente.API.Presentation.DTOs;

namespace Cliente.API.Common
{
    public static class Mapper
    {
        public static EnderecoDTO Map(Endereco entidade)
        {
            return new EnderecoDTO{
                Bairro = entidade.Bairro,
                CEP = entidade.CEP,
                Cidade = entidade.Cidade,
                Complemento = entidade.Complemento,
                EhEnderecoPrincipal = entidade.EhEnderecoPrincipal,
                Logradouro = entidade.Logradouro,
                Numero = entidade.Numero,
                UF = entidade.UF
            };
        }
        public static Endereco Map(EnderecoDTO dto)
        {
            return new Endereco{
                Bairro = dto.Bairro,
                CEP = dto.CEP,
                Cidade = dto.Cidade,
                Complemento = dto.Complemento,
                EhEnderecoPrincipal = dto.EhEnderecoPrincipal,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                UF = dto.UF
            };
        }
    }
}