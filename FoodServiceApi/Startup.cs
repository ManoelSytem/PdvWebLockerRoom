using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Interface;
using Aplication.InterfaceNegocio;
using Aplication.Negocio;
using Aplication.Repository;
using Aplication.Servico;
using Aplication.Util;
using BusinessLogic.Servico;
using Dominio;
using InfraEstrutura.Interface;
using InfraEstrutura.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace FoodServiceApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Open",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton<IJsonAutoMapper, JsonAutoMapperGeneric>();
            services.AddSingleton<IJsonAutoMapper, JsonAutoMapperGeneric>();
            services.AddSingleton<IMesaNegocio, MesaNegocio>();
            services.AddTransient<IConsumoRepository, ConsumoRepository>();
            services.AddSingleton<IClienteService, ClienteService>();
            services.AddSingleton<IContaRepository, ContaRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Open");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
