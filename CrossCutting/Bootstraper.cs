using Data.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Veiculo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Veiculo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
