using Domain.Interfaces.Veiculo;
using Services.Interfaces;
using System;

namespace Services.Veiculo
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public bool Delete(int id, Guid tenantId)
        {
            return _veiculoRepository.Delete(id, tenantId);
        }

        public Domain.Models.Veiculo.Veiculo GetById(int id, Guid tenantId)
        {
            return _veiculoRepository.GetById(id, tenantId);
        }

        public Domain.Models.Veiculo.Veiculo Insert(Domain.Models.Veiculo.Veiculo model)
        {
            return _veiculoRepository.Insert(model);
        }

        public bool Update(Domain.Models.Veiculo.Veiculo model)
        {
            return _veiculoRepository.Update(model);
        }
    }
}
