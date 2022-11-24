using Domain.Interfaces.Dapper;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Veiculo
{
    // TODO: Verificar para remover "Models.Veiculo."
    public interface IVeiculoRepository : IDapperRepository<Models.Veiculo.Veiculo>
    {
        List<Models.Veiculo.Veiculo> List(Filters.Veiculo.FiltroVeiculo filtro);
    }
}
