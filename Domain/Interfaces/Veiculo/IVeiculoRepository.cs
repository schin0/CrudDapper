using System;

namespace Domain.Interfaces.Veiculo
{
    // TODO: Verificar para remover "Models.Veiculo."
    //public interface IVeiculoRepository : IRepositoryBase<Models.Veiculo.Veiculo>
    public interface IVeiculoRepository
    {
        int Insert(Models.Veiculo.Veiculo model);
        Models.Veiculo.Veiculo GetById(int id, Guid tenantId);
        int Edit(Models.Veiculo.Veiculo model);
        int Delete(int id, Guid tenantId);
    }
}
