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
    public class InstallationAppService : AppService,Application.Services.IInstallationAppService
    {
        private readonly IInstallationRepository _repository;
        private InstallationConverter _converter;

        public InstallationAppService(IInstallationService service, IInstallationRepository repository) : base ()
        {
            _service = service;
            _repository = repository;
            _converter = new InstallationConverter();
        }
        public IInstallationService _service { get; set; }


        public List<InstallationVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public InstallationVO FindByID(long id)
        {
            return _converter.Parse(_service.FindByID(id));
        }

        public InstallationVO Create(InstallationVO Installation)
        {
            var InstallationEntity = _converter.Parse(Installation);
            InstallationEntity = _service.Create(InstallationEntity);
            return _converter.Parse(InstallationEntity);
        }

        public InstallationVO Update(InstallationVO Installation)
        {
            var InstallationEntity = _converter.Parse(Installation);
            InstallationEntity = _service.Update(InstallationEntity);
            return _converter.Parse(InstallationEntity);
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