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
using InfraEstrutura;
using InfraEstrutura.Interface;
using InfraEstrutura.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<AplicationDbContext>(
              options => options.UseMySql("server=localhost;user id=root;Password=Si@010101;database=FoodService; Allow User Variables=True"));

            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<UnitOfWork, UnitOfWork>();
            services.AddScoped<IJsonAutoMapper, JsonAutoMapperGeneric>();
            services.AddScoped<IJsonAutoMapper, JsonAutoMapperGeneric>();
            services.AddScoped<IMesaNegocio, MesaNegocio>();
            services.AddScoped<IConsumoRepository, ConsumoRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<MesaRepository, MesaRepository>();
            services.AddScoped<ProdutoRepository, ProdutoRepository>();
            services.AddScoped<ProdutoItemRepository, ProdutoItemRepository>();
            services.AddScoped<CardapioService, CardapioService>();
            services.AddScoped<ProdutoService, ProdutoService>();



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
