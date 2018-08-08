using System.Linq;
using Carrinho.API.Domain.Entities;
using Carrinho.API.Presentation.DTOs;

namespace Carrinho.API.Common
{
    public static class Mapper
    {
        public static CarrinhoDeCompraDTO Map(CarrinhoDeCompra carrinho)
        {
            return new CarrinhoDeCompraDTO
            {
                PrecoTotalDoCarrinhoSemFrete = carrinho.CalcularPrecoTotalDoCarrinho(),
                Itens = carrinho.Itens.Select(x =>
                    new ItemCarrinhoDeCompraDTO
                    {
                        NomeProduto = x.NomeProduto,
                        Quantidade = x.Quantidade,
                        PrecoUnitario = x.PrecoUnitario,
                        FornecedorUID = x.FornecedorUID,
                        Fornecedor = x.Fornecedor
                    }
                ).ToList()
            };
        }

        public static CarrinhoDeCompra Map(CarrinhoDeCompraDTO carrinho)
        {
            return new CarrinhoDeCompra
            {
                Itens = carrinho.Itens.Select(x =>
                    new ItemCarrinhoDeCompra
                    {
                        NomeProduto = x.NomeProduto,
                        Quantidade = x.Quantidade,
                        PrecoUnitario = x.PrecoUnitario,
                        FornecedorUID = x.FornecedorUID,
                        Fornecedor = x.Fornecedor
                    }
                ).ToList()
            };
        }
    }
}