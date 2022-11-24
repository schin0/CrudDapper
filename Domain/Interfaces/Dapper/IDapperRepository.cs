using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Dapper
{
    public interface IDapperRepository
    {
    }

    public interface IDapperRepository<T>
    {
        T GetById(int id, Guid tenantId);
        T Insert(T model);
        bool Update(T model);
        bool Delete(int id, Guid tenantId);
    }

    public interface IDapperRepository<T, TFiltro> : IDapperRepository<T>
    {
        List<T> List(TFiltro filter);
    }
    
}
