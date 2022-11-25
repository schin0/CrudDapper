using Domain.Filters.Veiculo;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    // TODO: avaliar uso de uma IService:
    //public interface IVeiculoService : IService<Domain.Models.Veiculo.Veiculo>
    // TODO: ver exemplo das services na api de notificações ou conector fiscal
    public interface IVeiculoService
    {
        Domain.Models.Veiculo.Veiculo GetById(int id, Guid tenantId);
        List<Domain.Models.Veiculo.Veiculo> List(FiltroVeiculo filtro);
        Domain.Models.Veiculo.Veiculo Insert(Domain.Models.Veiculo.Veiculo model);
        bool Update(Domain.Models.Veiculo.Veiculo model);
        bool Delete(int id, Guid tenantId);
    }
}
