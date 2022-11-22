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
            return _connection.Execute("DELETE FROM [treinamentoVeiculo].[Veiculo] WHERE Id = @Id AND TenantId = @TenantId", new
            {
                id,
                tenantId
            }) > 0;
        }

        public Veiculo GetById(int id, Guid tenantId)
        {
            return _connection.QuerySingleOrDefault<Veiculo>("SELECT * FROM [treinamentoVeiculo].[Veiculo] WHERE Id = @Id AND TenantId = @TenantId", new
            {
                id,
                tenantId
            });
        }

        public Veiculo Insert(Veiculo model)
        {
            string sql = "INSERT INTO [treinamentoVeiculo].[Veiculo]([TenantId], [DataCadastro], [Placa], [Cor], [Km], [ModeloId]) " +
                                       "VALUES (@TenantId, @DataCadastro, @Placa, @Cor, @Km, @ModeloId); SELECT CAST(SCOPE_IDENTITY() AS INT);";

            model.Id = _connection.Query<int>(sql, model).Single();

            return model;
        }

        public List<Veiculo> List(FiltroVeiculo filtro)
        {
            return _connection.Query<Veiculo>("SELECT * FROM [treinamentoVeiculo].[Veiculo] WHERE TenantId = @TenantId", new
            {
                filtro.TenantId
            }).ToList();
        }

        public bool Update(Veiculo model)
        {
            string sql = "UPDATE [treinamentoVeiculo].[Veiculo] " +
                "SET DataCadastro = @DataCadastro, Placa = @Placa, Cor = @Cor, Km = @Km, ModeloId = @ModeloId WHERE Id = @Id AND TenantId = @TenantId";

            return _connection.Execute(sql, model) > 0;
        }
    }
}
