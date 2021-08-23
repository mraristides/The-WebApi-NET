using System.Collections.Generic;
using Sample.Domain.Base.Interfaces;
using Sample.Hypermedia.Utils;

namespace Sample.Domain.Entities.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
        PagedSearch<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}