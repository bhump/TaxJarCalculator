using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxJar.Api.Helpers;
using TaxJar.Api.HttpClients;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;
using TaxJar.Api.Repositories;
using TaxJar.Api.Services;

namespace TaxJar.Api
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
            services.AddControllers();
            services.AddSingleton<ITaxRepository, TaxRepository>();
            services.AddSingleton<ITaxService, TaxService>();
            services.AddSingleton<IUriHelper, UriHelper>();
            services.AddSingleton<ITaxRateHttpClient, TaxRateHttpClient>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IClientService, ClientService>();

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}