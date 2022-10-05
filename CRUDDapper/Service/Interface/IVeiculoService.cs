using CRUDDapper.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDDapper.Service.Interface
{
    public interface IVeiculoService
    {
        Task<Veiculo> BuscarPorId(int veiculoId);
        Task<List<Veiculo>> Listar(int veiculoId);
        Task<int> Inserir(Veiculo veiculo);
        Task<int> Atualizar(Veiculo veiculo);
        Task<int> Excluir(int veiculoId);

    }
}
