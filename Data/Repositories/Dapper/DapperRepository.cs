using Dapper;
using Domain.Filters.Veiculo;
using Domain.Interfaces.Dapper;
using Domain.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Repositories.Dapper
{
    public class DapperRepository : IDapperRepository
    {
        private IDbConnection _connection;

        public DapperRepository()
        {
            _connection = new SqlConnection(@"oi");
        }

        public bool Delete(int id, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public Veiculo GetById(int id, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public Veiculo Insert(Veiculo model)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> List(FiltroVeiculo filtro)
        {
            return _connection.Query<Veiculo>("SELECT * FROM treinamentoVeiculo.Veiculo WHERE TenantId = @TenantId", new
                { 
                    filtro.TenantId
                }).ToList();
        }

        public bool Update(Veiculo model)
        {
            throw new NotImplementedException();
        }
    }
}
