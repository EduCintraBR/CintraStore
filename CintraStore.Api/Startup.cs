using CintraStore.Domain.StoreContext.Handlers;
using CintraStore.Domain.StoreContext.Repositories;
using CintraStore.Domain.StoreContext.Services;
using CintraStore.Infra.StoreContext.DataContexts;
using CintraStore.Infra.StoreContext.Repositories;
using CintraStore.Infra.StoreContext.Services;
using CintraStore.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace CintraStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddResponseCompression();

            services.AddScoped<CintraDataContext, CintraDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { 
                            Title = "Cintra Store API", 
                            Version = "v1", 
                            Description = "Esta é uma API de testes, criada no curso Criando APIs com ASP.NET Core 2.0 e Dapper do balta.io"
                });
            });

            Settings.ConnectionString = Configuration["connectionString"];
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cintra Store - Docs");
            });
        }
    }
}
