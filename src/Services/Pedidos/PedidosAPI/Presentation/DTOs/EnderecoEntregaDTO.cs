namespace Pedidos.API.Presentation.DTOs
{
  
    public class EnderecoEntregaDTO
    {
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string UF { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
    }
}