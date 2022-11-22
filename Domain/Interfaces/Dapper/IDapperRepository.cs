using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Dapper
{
    public interface IDapperRepository
    {
        //TODO: usar type T
        List<Models.Veiculo.Veiculo> List(Filters.Veiculo.FiltroVeiculo filtro);
        Models.Veiculo.Veiculo GetById(int id, Guid tenantId);
        Models.Veiculo.Veiculo Insert(Models.Veiculo.Veiculo model);
        bool Update(Models.Veiculo.Veiculo model);
        bool Delete(int id, Guid tenantId);
    }
}
