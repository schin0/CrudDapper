using Data.Repositories;
using Data.Repositories.Dapper;
using Domain.Interfaces.Dapper;
using Domain.Interfaces.Veiculo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Veiculo;
using System;
using System.Collections.Generic;

namespace CrossCutting
{
    public static class Bootstraper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterTypes(GetRepositories());
            services.RegisterTypes(GetServices());
        }

        private static void RegisterTypes(this IServiceCollection container, Dictionary<Type, Type> types)
        {
            foreach (var item in types)
                container.AddScoped(item.Key, item.Value);
        }

        private static Dictionary<Type, Type> GetRepositories()
            => new Dictionary<Type, Type>
            {
                { typeof(IDapperRepository), typeof(DapperRepository) },
                { typeof(IVeiculoRepository), typeof(VeiculoRepository) }
            };

        private static Dictionary<Type, Type> GetServices()
            => new Dictionary<Type, Type>
            {
                { typeof(IVeiculoService), typeof(VeiculoService) },
            };
    }
}
