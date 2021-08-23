using System;
using System.Collections.Generic;

namespace Sample.Domain.Base.Interfaces
{
    public interface IService<T> : IDisposable where T : class
    {
        T Create(T obj);
        T FindByID(long id);
        IEnumerable<T> FindAll();
        T Update(T obj);
        void Delete(long id);
    }
}