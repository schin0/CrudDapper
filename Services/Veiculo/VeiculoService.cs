using Domain.Filters.Veiculo;
using Domain.Interfaces.Dapper;
using Domain.Interfaces.Veiculo;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Veiculo
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IDapperRepository _dapper;

        public VeiculoService(IVeiculoRepository veiculoRepository, IDapperRepository dapper)
        {
            _veiculoRepository = veiculoRepository;
            _dapper = dapper;
        }

        public bool Delete(int id, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Veiculo.Veiculo GetById(int id, Guid tenantId)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Veiculo.Veiculo Insert(Domain.Models.Veiculo.Veiculo model)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Models.Veiculo.Veiculo> List(FiltroVeiculo filtro)
        {
            throw new NotImplementedException();
        }

        public bool Update(Domain.Models.Veiculo.Veiculo model)
        {
            throw new NotImplementedException();
        }
    }
}
