using CRUDDapper.Data.Model;
using CRUDDapper.Repository;
using CRUDDapper.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDDapper.Service
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public Task<Veiculo> BuscarPorId(int veiculoId)
            => Task.FromResult(_veiculoRepository.BuscarPorId(veiculoId));

        public Task<List<Veiculo>> Listar(int veiculoId)
            => Task.FromResult(_veiculoRepository.Listar(veiculoId));

        public Task<int> Inserir(Veiculo veiculo)
            => Task.FromResult(_veiculoRepository.Inserir(veiculo));

        public Task<int> Atualizar(Veiculo veiculo)
            => Task.FromResult(_veiculoRepository.Atualizar(veiculo));

        public Task<int> Excluir(int veiculoId)
            => Task.FromResult(_veiculoRepository.Excluir(veiculoId));

    }
}
