﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrinho.API.Infrastructure.Data;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Carrinho.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

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
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();
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
