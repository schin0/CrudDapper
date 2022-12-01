using Domain.Filters.Veiculo;
using Domain.Interfaces.Veiculo;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.Veiculo
{
    public class VeiculoService : ServiceBase, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public bool Delete(int id, Guid tenantId)
            => _veiculoRepository.Delete(id, tenantId);

        public Domain.Models.Veiculo.Veiculo GetById(int id, Guid tenantId)
            => _veiculoRepository.GetById(id, tenantId);

        public Domain.Models.Veiculo.Veiculo Insert(Domain.Models.Veiculo.Veiculo model)
            => _veiculoRepository.Insert(model);

        public List<Domain.Models.Veiculo.Veiculo> List(FiltroVeiculo filtro)
            => _veiculoRepository.List(filtro);

        public bool Update(Domain.Models.Veiculo.Veiculo model)
            => _veiculoRepository.Update(model);
    }
}
