using Data.Repositories.Dapper;
using Domain.Interfaces.Veiculo;
using Domain.Models.Veiculo;
using System;
using System.Data;

namespace Data.Repositories
{
    public class VeiculoRepository : DapperRepository<Veiculo>, IVeiculoRepository
    {
        private readonly string tabela = "[treinamentoVeiculo].[Veiculo]";

        public VeiculoRepository(IDbConnection connection) : base(connection)
        {
        }

        public bool Delete(int id, Guid tenantId)
        {
            var command = $"DELETE FROM {tabela} WHERE Id = @Id AND TenantId = @TenantId";

            return Delete(command, id, tenantId);
        }


        public Veiculo GetById(int id, Guid tenantId)
        {
            var query = $"SELECT * FROM {tabela} WHERE Id = @Id AND TenantId = @TenantId";

            return GetById(query, id, tenantId);
        }

        public Veiculo Insert(Veiculo model)
        {
            string command = $"INSERT INTO {tabela}([TenantId], [DataCadastro], [Placa], [Cor], [Km], [ModeloId]) " +
                                       "VALUES (@TenantId, @DataCadastro, @Placa, @Cor, @Km, @ModeloId); SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return Insert(command, model);
        }

        public bool Update(Veiculo model)
        {
            string command = $"UPDATE {tabela}" +
                "SET DataCadastro = @DataCadastro, Placa = @Placa, Cor = @Cor, Km = @Km, ModeloId = @ModeloId WHERE Id = @Id AND TenantId = @TenantId";

            return Update(command, model) > 0;
        }

        //public List<Veiculo> List(FiltroVeiculo filtro)
        //{
        //    return List(command, filtro);
        //}

    }
}
