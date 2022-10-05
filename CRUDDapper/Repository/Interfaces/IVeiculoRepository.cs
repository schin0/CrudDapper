using CRUDDapper.Data.Model;
using System.Collections.Generic;

namespace CRUDDapper.Repository
{
    public interface IVeiculoRepository
    {
        Veiculo BuscarPorId(int veiculoId);
        List<Veiculo> Listar(int veiculoId);
        int Inserir(Veiculo veiculo);
        int Atualizar(Veiculo veiculo);
        int Excluir(int veiculoId);
    }
}
