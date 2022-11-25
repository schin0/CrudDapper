using Dapper;
using Domain.Filters.Veiculo;
using Domain.Interfaces;
using Domain.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class RepositoryBase : IRepositoryBase { }

    public class RepositoryBase<T> : IRepositoryBase
    {
        protected readonly IDbConnection _connection;

        public RepositoryBase(IDbConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(string command, int id, Guid tenantId)
        {
            return _connection.Execute(command, new
            {
                id,
                tenantId
            }, commandType: CommandType.Text) > 0;
        }

        public Veiculo GetById(string query, int id, Guid tenantId)
        {
            return _connection.QueryFirst<Veiculo>(query, new
            {
                id,
                tenantId
            }, commandType: CommandType.Text);
        }

        public T Insert(string command, T model)
            => _connection.QuerySingle<T>(command, model, commandType: CommandType.Text);

        public List<Veiculo> List(FiltroVeiculo filtro)
        {
            return _connection.Query<Veiculo>("SELECT * FROM [treinamentoVeiculo].[Veiculo] WHERE TenantId = @TenantId", new
            {
                filtro.TenantId
            }).ToList();
        }

        public bool Update(string command, T model)
            => _connection.Execute(command, model, commandType: CommandType.Text) > 0;

    }
}
