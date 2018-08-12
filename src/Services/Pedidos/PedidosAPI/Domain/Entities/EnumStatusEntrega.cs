namespace Pedidos.API.Domain.Entities
{
    public enum EnumStatusEntrega
    {
        AguardandoEmbalagem = 1,
        Embalado =2,
        AguardandoExpedicao =3,
        Expedido=4,
        EmTransporte = 5,
        Entregue = 6
    }
}