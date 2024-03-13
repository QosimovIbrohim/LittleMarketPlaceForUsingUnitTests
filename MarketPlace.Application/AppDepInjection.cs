using MarketPlace.Application.Abstractions;
using MarketPlace.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Application
{
    public static class AppDepInjection
    {
        public static IServiceCollection AddAppLication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
