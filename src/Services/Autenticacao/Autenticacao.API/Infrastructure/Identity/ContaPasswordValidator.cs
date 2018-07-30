using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.API.Infrastructure.Identity
{
    public class ContaPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly AutenticacaoDbContext _context;
        public ContaPasswordValidator(AutenticacaoDbContext context)
        {
            _context = context;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var senhaCriptografada = context.Password.Sha256();
            var conta = await _context.Contas.FirstOrDefaultAsync(x=>x.Login == context.UserName);
            if(conta != null) 
            {
                if(conta.ConferirSenha(senhaCriptografada))
                {
                    context.Result = new GrantValidationResult(conta.ContaId.ToString(),OidcConstants.GrantTypes.Password);
                    return;
                }
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,"usuário ou senha inválidos");
        }
    }
}