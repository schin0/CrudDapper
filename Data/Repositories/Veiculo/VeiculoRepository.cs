using Data.Queries;
using Domain.Filters.Veiculo;
using Domain.Interfaces.Veiculo;
using Domain.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Repositories
{
    public class VeiculoRepository : RepositoryBase<Veiculo, FiltroVeiculo>, IVeiculoRepository
    {
        public VeiculoRepository(IDbConnection connection) : base(connection)
        {
        }

        public bool Delete(int id, Guid tenantId) => Delete(VeiculoQuery.Delete(), id, tenantId);

        public Veiculo GetById(int id, Guid tenantId) => GetById(VeiculoQuery.GetById(), id, tenantId);

        public Veiculo Insert(Veiculo model) => Insert(VeiculoQuery.Insert(), model);


        public bool Update(Veiculo model) => Update(VeiculoQuery.Update(), model);

        public List<Veiculo> List(FiltroVeiculo filter) => List(VeiculoQuery.List(), filter);

    }
}
