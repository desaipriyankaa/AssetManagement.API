using AssetManagement.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API
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
            
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddScoped<IMachineInfoRepository, MachineInfo>();
            services.AddScoped<IAssetInfoRepository, AssetInfo>();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "AssetManagementOpenApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "AssetManagement API",
                        Version = "1"
                    }); ;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
            {
                app.UseExceptionHandler();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/AssetManagementOpenApiSpecification/swagger.json",
                    "AssetManagement API");
            });

            app.UseStatusCodePages();

            app.UseMvc();

        }
    }
}
