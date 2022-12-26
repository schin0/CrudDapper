using Data.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Veiculo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.Interfaces;
using Services.Veiculo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CrossCutting
{
    public static class Bootstraper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterTypes(GetRepositories());
            services.RegisterTypes(GetServices());
        }

        public static void RegisterIDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(
                    typeof(IDbConnection), c => new SqlConnection(configuration.GetSection("ConnectionStrings:DefaultConnection").Value)
                );
        }

        public static void RegisterRabbitMQ(IConfiguration configuration)
        {
            var factory = CreateConnectionFactory(configuration);

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var mensagem = "schin teste";

            var body = Encoding.UTF8.GetBytes(mensagem);

            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body);
        }

        private static ConnectionFactory CreateConnectionFactory(IConfiguration configuration)
        {
            return new ConnectionFactory()
            {
                HostName = configuration.GetSection("RabbitMQConfiguration:HostName").Value,
                Password = configuration.GetSection("RabbitMQConfiguration:Password").Value,
                UserName = configuration.GetSection("RabbitMQConfiguration:UserName").Value
            };
        }

        private static void RegisterTypes(this IServiceCollection container, Dictionary<Type, Type> types)
        {
            foreach (var item in types)
                container.AddScoped(item.Key, item.Value);
        }

        private static Dictionary<Type, Type> GetRepositories()
            => new Dictionary<Type, Type>
            {
                { typeof(IRepositoryBase), typeof(RepositoryBase) },
                { typeof(IVeiculoRepository), typeof(VeiculoRepository) }
            };

        private static Dictionary<Type, Type> GetServices()
            => new Dictionary<Type, Type>
            {
                { typeof(IVeiculoService), typeof(VeiculoService) },
            };
    }
}
