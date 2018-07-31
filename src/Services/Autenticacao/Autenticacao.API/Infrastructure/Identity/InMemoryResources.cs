using System.Collections.Generic;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace Autenticacao.API.Infrastructure.Identity
{
    public static class InMemoryResources
    {
        public static IEnumerable<ApiResource> GetAPIResources()
        {
            return new[]{ new ApiResource
                    {
                        Name = "poc-api",
                        DisplayName = "POC API",
                        Description = "POC API",
                        UserClaims = new List<string> { "profile", "email", "role" },
                        ApiSecrets = new List<Secret> { new Secret("apiSecret".Sha256()) },
                        Scopes = new List<Scope>
                        {
                            new Scope()
                            {
                                Name = "poc-api.all",
                                UserClaims = new [] { "profile", "email", "role" },
                            }
                         }

                    }

             };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]{
                            new IdentityResources.OpenId(),
                            new IdentityResources.Profile(),
                            new IdentityResources.Email(),
                            new IdentityResource {
                                Name = "role",
                                UserClaims = new List<string> {"role"}
                            }
              };
        }

    }
}