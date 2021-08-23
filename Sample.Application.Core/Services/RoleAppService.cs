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
    public class RoleAppService : AppService,Application.Services.IRoleAppService
    {
        private readonly IRoleRepository _repository;
        private RoleConverter _converter;

        public RoleAppService(IRoleService service, IRoleRepository repository) : base ()
        {
            _service = service;
            _repository = repository;
            _converter = new RoleConverter();
        }
        public IRoleService _service { get; set; }


        public List<RoleVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public RoleVO FindByID(long id)
        {
            return _converter.Parse(_service.FindByID(id));
        }

        public RoleVO Create(RoleVO Role)
        {
            var RoleEntity = _converter.Parse(Role);
            RoleEntity = _service.Create(RoleEntity);
            return _converter.Parse(RoleEntity);
        }

        public RoleVO Update(RoleVO Role)
        {
            var RoleEntity = _converter.Parse(Role);
            RoleEntity = _service.Update(RoleEntity);
            return _converter.Parse(RoleEntity);
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