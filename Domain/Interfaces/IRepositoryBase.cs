using Domain.Filters.Veiculo;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepositoryBase
    {
    }

    public interface IRepositoryBase<T>
    {
        T GetById(int id, Guid tenantId);
        T Insert(T model);
        bool Update(T model);
        bool Delete(int id, Guid tenantId);
    }

    public interface IRepositoryBase<T, TFilter> : IRepositoryBase<T> where TFilter : BasicFilter
    {
        List<T> List(TFilter filter);
    }

}
