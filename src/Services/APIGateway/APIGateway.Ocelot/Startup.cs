using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacheManager.Core;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace APIGateway.Ocelot
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
            .AddJsonFile("ocelot.json")
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var autenticacaoCfg = Configuration.GetSection("Autenticacao");
            var identityServer = autenticacaoCfg["servidor"];
            var apiName = autenticacaoCfg["apiname"]; 
            var apiSecret = autenticacaoCfg["apisecret"]; 
            var providerName = autenticacaoCfg["providername"];

            Action<IdentityServerAuthenticationOptions> options = o =>
            {
                o.SupportedTokens = SupportedTokens.Both;
                o.ApiName = apiName;
                o.ApiSecret = apiSecret;
                o.Authority = identityServer;
            };

            services.AddAuthentication().AddIdentityServerAuthentication(providerName, options);

            services.AddOcelot(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseOcelot().Wait();
        }
    }
}
