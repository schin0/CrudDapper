using Domain.Interfaces.Veiculo;
using Domain.Models.Veiculo;
using Microsoft.Extensions.Configuration;
using System;

namespace Data.Repositories
{
    //public class VeiculoRepository : RepositoryBase, IVeiculoRepository
    public class VeiculoRepository : IVeiculoRepository
    {

        public VeiculoRepository(IConfiguration configuracao)
        {
        }

        public int Delete(int id, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public int Edit(Veiculo model)
        {
            throw new NotImplementedException();
        }

        public Veiculo GetById(int id, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public int Insert(Veiculo model)
        {
            throw new NotImplementedException();
        }
    }
}
