using Sample.Domain.Context;
using Sample.Domain.Core.Base;
using Sample.Domain.Entities;
using Sample.Domain.Entities.Interfaces;
using Sample.Domain.Services;

namespace Sample.Domain.Core.Services
{
    public class PersonService : Service<Person>, IPersonService
    {

        public PersonService(MySQLContext context, IPersonRepository repository) 
        : base(context, repository)
        {

        }
        
        public override Person Create(Person obj)
        {
            return _repository.Create(obj);
        }
    }
}