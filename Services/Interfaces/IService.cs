using Domain.Filters.Veiculo;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IService { }

    public interface IService<T>
    {
        bool Update(T model);
        T GetById(int id, Guid tenantId);
        bool Delete(int id, Guid tenantId);
        T Insert(T model);
    }

    public interface IService<T, TFilter> : IService<T> where TFilter : BasicFilter
    {
        List<T> List(TFilter filter);
    }

}
