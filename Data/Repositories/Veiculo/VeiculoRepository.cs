using Domain.Interfaces.Veiculo;
using Domain.Models.Veiculo;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Data.Repositories
{
    public class VeiculoRepository : RepositoryBase, IVeiculoRepository
    {
        public VeiculoRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
        {
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

        public bool Update(Veiculo model)
        {
            throw new NotImplementedException();
        }
    }
}
