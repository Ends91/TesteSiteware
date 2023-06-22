using LojaSiteware.Application;
using LojaSiteware.Domain.Entities;
using LojaSiteware.Infra.Data.Configuration;
using LojaSiteware.Infra.Data.Implementations.Repositories;
using LojaSiteware.Infra.Data.Implementations.Repositories.ProductRepository;
using LojaSiteware.Infra.Data.Interfaces.Repositories;
using LojaSiteware.Infra.Data.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaSiteware
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
            services.AddControllers().AddControllersAsServices();

            services.AddDbContext<LojaSitewareContext>(options =>
            {
                options.UseInMemoryDatabase("LojaSitewareDb");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Loja Siteware API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LojaSitewareContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

               app.UseCors("AllowAllOrigins");

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loja Siteware API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Products.Add(new Product { Name = "Produto A", Price = 10, Promotion = new Promotion { Description = "3 por 10 reais" }});
            dbContext.Products.Add(new Product { Name = "Produto B", Price = 25, Promotion = new Promotion { Description = "Leve 2 e pague 1" } });
            dbContext.Products.Add(new Product { Name = "Produto C", Price = 20 });
            dbContext.SaveChanges();

        }
    }
}
