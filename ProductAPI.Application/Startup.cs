using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infra.Data.Repository;
using ProductAPI.Service.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductAPI.Application
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Product Api",
                    Description = "A ASP.NET Core 2.1 Web Api project with DDD",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Hudson Lima",
                        Email = "hudsonlima.ti@gmail.com",
                        Url = "https://github.com/hudsonlima"
                    }
                });
            });

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            services.AddMvc().AddXmlSerializerFormatters();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddTransient<ProductService, ProductService>();
            services.AddTransient<BrandService, BrandService>();
            services.AddTransient<ProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
