namespace Pedidos.API.Domain.Entities
{
    public enum EnumStatusPedido
    {
        AguardandoPagamento = 1,
        AguardandoFornecedores = 2,
        EmTransito=3,
        Concluido=4
    }
}