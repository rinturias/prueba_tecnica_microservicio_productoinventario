using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Application.UseCases.Consumers;
using System.Product.Domain.Interfaces;
using System.Product.Infrastructure.EF;
using System.Product.Infrastructure.EF.Context;
using System.Product.Infrastructure.Repositories;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure
{
   
        public static class Extensions
        {

            public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            {

                services.AddMediatR(Assembly.GetExecutingAssembly());
                var connectionString = configuration.GetConnectionString("ProductDbConnectionString");

                services.AddDbContext<ReadDbContext>(context => context.UseSqlServer(connectionString));
                services.AddDbContext<WriteDbContext>(context => context.UseSqlServer(connectionString));



                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IKardexRepository, KardexRepository>();
            
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                AddRabbitMq(services, configuration);

                return services;
            }

        private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config => {
                config.AddConsumer<SaleMadeConsumer>().Endpoint(endpoint => endpoint.Name = SaleMadeConsumer.QueueName);

                config.UsingRabbitMq((context, cfg) => {
                    var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                    cfg.Host(uri);

                    cfg.ReceiveEndpoint(SaleMadeConsumer.QueueName, endpoint => {
                        endpoint.ConfigureConsumer<SaleMadeConsumer>(context);
                    });
                });
            });
        }
    }
}