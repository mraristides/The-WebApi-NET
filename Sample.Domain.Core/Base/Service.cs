using System.Collections.Generic;
using Sample.Domain.Base.Interfaces;
using Sample.Domain.Context;

namespace Sample.Domain.Core.Base
{
    public class Service<T> : IService<T> where T : class
    {
        protected MySQLContext _context { get; set; }
        protected IRepository<T> _repository { get; }
        
        public Service(MySQLContext context, IRepository<T> repository) {
            _context = context;
            _repository = repository;
        }

        public virtual T Create(T obj)
        {
            return _repository.Create(obj);
        }

        public virtual void Delete(long id)
        {
            _repository.Delete(id);
        }


        public virtual IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public virtual T FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public virtual T Update(T obj)
        {
            return _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();

        }
    }
}