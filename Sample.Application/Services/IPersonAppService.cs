using System.Collections.Generic;
using Sample.Application.VO;
using Sample.Domain.Services;
using Sample.Hypermedia.Utils;

namespace Sample.Application.Services
{
    public interface IPersonAppService
    {
        IPersonService _service { get; set; }

        PersonVO Create(PersonVO obj);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO obj);
        void Delete(long id);
        
        List<PersonVO> FindByName(string firstName, string lastName);
        PagedSearchVO<PersonVO> FindWithPagegSearch
            (string name, string sortDirection, int pageSize, int page);
        PersonVO Disable(long id);
    }
}