using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fornecedores.API.Infrastructure.Integration
{

    public interface IFornecedorIntegrationService
    {
        Task<DadosEntrega> ObterDadosDaEntregaDoFornecedor(string codigoFornecedor, string cep);
    }

    public class FornecedorIntegrationService : IFornecedorIntegrationService
    {
        private readonly string _urlApiFornecedor;
        public FornecedorIntegrationService(string urlApiFornecedor)
        {
            _urlApiFornecedor=urlApiFornecedor;
        }
        public async Task<DadosEntrega> ObterDadosDaEntregaDoFornecedor(string codigoFornecedor, string cep)
        {
            var url = string.Format(_urlApiFornecedor,codigoFornecedor,cep);
            using(var client = new HttpClient())
            {
                var resposta = await client.GetAsync(url);

                if(resposta.IsSuccessStatusCode)
                {
                    var jsonStr = await resposta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DadosEntrega>(jsonStr);
                }

                return null;
            }
        }
    }
}