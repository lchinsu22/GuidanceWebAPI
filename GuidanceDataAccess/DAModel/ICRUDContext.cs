using System;
using System.Collections.Generic;

namespace GuidanceDataAccess.DAModel
{
    public interface ICRUDContext<T> : IDisposable
    {
        T UpdateContext(T prophylaxisType);
        T AddToContext(T entity);
        List<T> AddToContext(List<T> entities);
        T GetFromContext(int Id);
        List<T> GetAllFromContext();
        int RemoveFromContext(int Id);
    }
}