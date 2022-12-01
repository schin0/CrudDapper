using Domain.Filters.Veiculo;

namespace Services.Interfaces
{
    public interface IVeiculoService : IService<Domain.Models.Veiculo.Veiculo, FiltroVeiculo>
    {
    }
}
