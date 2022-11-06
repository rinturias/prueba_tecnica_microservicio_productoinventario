using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Factories;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Application
{
  public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IProductFactory, ProductFactory>();
            services.AddTransient<IKardexFactory, KardexFactory>();
            return services;
        }

    }
}
