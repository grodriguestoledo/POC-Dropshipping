using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pedidos.API.Infrastructure.Data;

namespace Pedidos.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var autenticacaoCfg = Configuration.GetSection("Autenticacao");
            var identityServer = autenticacaoCfg["servidor"];
            var apiName = autenticacaoCfg["apiname"];
            var apiSecret = autenticacaoCfg["apisecret"];
            var providerName = autenticacaoCfg["providername"];
            var connectionStr = Configuration.GetConnectionString("DefaultConnection");

            var migrationAssembly = this.GetType().GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<PedidosDbContext>(options => { options.UseSqlServer(connectionStr, sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)); });

            services.AddMvc();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).AddIdentityServerAuthentication(o =>
            {
                o.SupportedTokens = SupportedTokens.Both;
                o.ApiName = apiName;
                o.ApiSecret = apiSecret;
                o.Authority = identityServer;
                o.RequireHttpsMetadata = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
