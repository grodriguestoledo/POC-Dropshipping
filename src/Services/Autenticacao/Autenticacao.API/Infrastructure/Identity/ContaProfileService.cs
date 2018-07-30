using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Autenticacao.API.Infrastructure;
using IdentityServer4.Extensions;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace Autenticacao.API.Infrastructure.Identity
{
    public class ContaProfileService : IProfileService
    {
        private readonly AutenticacaoDbContext _context;
        public ContaProfileService(AutenticacaoDbContext context)
        {
            _context = context;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = Convert.ToInt64(context.Subject.GetSubjectId());
            var conta = await _context.Contas.FirstOrDefaultAsync(x => x.ContaId == id);
            if(conta != null){
                var claims = new List<Claim>();
                claims.Add(new Claim("username",conta.Login));
                claims.Add(new Claim("email",conta.Login));
                claims.Add(new Claim("nomeCompleto",conta.NomeCompleto));
                claims.Add(new Claim("role",conta.TipoConta.ToString()));

                context.IssuedClaims = claims;
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
             var id = Convert.ToInt64(context.Subject.GetSubjectId());
             var conta = await _context.Contas.FirstOrDefaultAsync(x => x.ContaId == id);
             context.IsActive = conta != null;
        }
    }
}