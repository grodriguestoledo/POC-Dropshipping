using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Fornecedores.API.Infrastructure.Data;
using Fornecedores.API.Infrastructure.Integration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fornecedores.API
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
            var connectionStr = Configuration.GetConnectionString("DefaultConnection");

            var migrationAssembly = this.GetType().GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<FornecedoresDbContext>(options => { options.UseSqlServer(connectionStr, sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)); });
            services.AddScoped<IFornecedoresDbContext>(provider => provider.GetService<FornecedoresDbContext>());

            var fornecedorApiUrl = Configuration.GetSection("FornecedorIntegracao")["URL"];
            services.AddTransient<IFornecedorIntegrationService>(i=> new FornecedorIntegrationService(fornecedorApiUrl));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
