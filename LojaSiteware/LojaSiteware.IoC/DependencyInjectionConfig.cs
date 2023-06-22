using LojaSiteware.Application;
using LojaSiteware.Infra.Data.Implementations.Repositories;
using LojaSiteware.Infra.Data.Implementations.Repositories.ProductRepository;
using LojaSiteware.Infra.Data.Interfaces.Repositories;
using LojaSiteware.Infra.Data.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSiteware.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
