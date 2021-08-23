using System;
using System.Collections.Generic;
using Sample.Hypermedia.Utils;

namespace Sample.Domain.Base.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
        int GetCount(string query);
    }
}