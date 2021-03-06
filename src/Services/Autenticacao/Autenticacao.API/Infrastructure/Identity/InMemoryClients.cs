using System.Collections.Generic;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace Autenticacao.API.Infrastructure.Identity
{
    public static class InMemoryClients
    {
        public static IEnumerable<Client> GetClients(){
            return new[]{
                  new Client()
                    {
                        ClientId = "poc-api",
                        ClientName = "Cliente da POC",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = new List<Secret> { new Secret("123mudar".Sha256()) },
                        AllowedScopes = new List<string> { "poc-api.all",StandardScopes.OpenId,StandardScopes.Profile,StandardScopes.Email },
                        AccessTokenLifetime = 72000,
                        IdentityTokenLifetime = 72000
                    }
              };
        }
    }
}