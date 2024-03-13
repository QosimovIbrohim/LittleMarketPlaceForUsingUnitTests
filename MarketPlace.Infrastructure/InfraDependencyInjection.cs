﻿using MarketPlace.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infrastructure
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastruct(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MpDbContext>(ops =>
            {
                ops.UseNpgsql(configuration.GetConnectionString("DefCon"));
            });
            return services;
        }
    }
}
