using System.Collections.Generic;
using Sample.Domain.Entities.Interfaces;
using Sample.Application.VO;
using Sample.Application.Converter.Implementations;
using Sample.Hypermedia.Utils;
using Sample.Domain.Services;
using System.Linq;
using Sample.Application.Base;

namespace Sample.Application.Core.Services
{
    public class PersonAppService : AppService,Application.Services.IPersonAppService
    {
        private readonly IPersonRepository _repository;
        private PersonConverter _converter;

        public PersonAppService(IPersonService service, IPersonRepository repository) : base ()
        {
            _service = service;
            _repository = repository;
            _converter = new PersonConverter();
        }
        public IPersonService _service { get; set; }


        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_service.FindByID(id));
        }
        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PagedSearchVO<PersonVO> FindWithPagegSearch(string name, string sortDirection, int pageSize, int page)
        {
            var personEntity = _repository.FindWithPagedSearch(name, sortDirection, pageSize, page);
            return new PagedSearchVO<PersonVO> {
                CurrentPage = personEntity.CurrentPage,
                List =  _converter.Parse(personEntity.List),
                PageSize = personEntity.PageSize,
                SortDirections = personEntity.SortDirections,
                TotalResults = personEntity.TotalResults
            };
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _service.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _service.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _service.Delete(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}