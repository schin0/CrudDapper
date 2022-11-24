using Dapper;
using Domain.Filters.Veiculo;
using Domain.Interfaces.Dapper;
using Domain.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories.Dapper
{
    public class DapperRepository : IDapperRepository { }

    public class DapperRepository<T>: IDapperRepository
    {
        protected readonly IDbConnection _connection;

        public DapperRepository(IDbConnection connection)
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

        public int Update(string command, T model)
            => _connection.Execute(command, model, commandType: CommandType.Text);
        
    }
}
