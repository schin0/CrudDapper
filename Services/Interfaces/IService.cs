using System;

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

    // TODO: Inserir listar com filtro 
    //public interface IService<T, TFilter> { }

}
