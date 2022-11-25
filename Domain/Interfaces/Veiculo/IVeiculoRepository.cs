using System.Collections.Generic;

namespace Domain.Interfaces.Veiculo
{
    public interface IVeiculoRepository : IRepositoryBase<Models.Veiculo.Veiculo>
    {
        List<Models.Veiculo.Veiculo> List(Filters.Veiculo.FiltroVeiculo filtro);
    }
}
