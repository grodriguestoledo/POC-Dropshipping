
namespace Autenticacao.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Autenticacao.API.Infrastructure.Identity;
    using Autenticacao.API.Infrastructure;
    using IdentityServer4.EntityFramework.DbContexts;
    using IdentityServer4.EntityFramework.Mappers;
    using IdentityServer4.Models;
    using IdentityServer4.Test;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

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
            var connectionStr = Configuration.GetConnectionString("DefaultConnection");

            var migrationAssembly = this.GetType().GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<AutenticacaoDbContext>(options => { options.UseSqlServer(connectionStr, sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)); });

            services
             .AddIdentityServer()
             .AddOperationalStore(options => { options.ConfigureDbContext = x => x.UseSqlServer(connectionStr, sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)); })
             //  .AddConfigurationStore(options => { options.ConfigureDbContext = x => x.UseSqlServer(connectionStr, sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)); })
             .AddProfileService<ContaProfileService>()
             .AddResourceOwnerValidator<ContaPasswordValidator>()
             .AddInMemoryApiResources(InMemoryResources.GetAPIResources())
             .AddInMemoryIdentityResources(InMemoryResources.GetIdentityResources())
             .AddInMemoryClients(InMemoryClients.GetClients())
             .AddDeveloperSigningCredential();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIdentityServer();
        }
    }
}
