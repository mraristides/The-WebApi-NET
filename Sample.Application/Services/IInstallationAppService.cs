using System.Collections.Generic;
using Sample.Application.VO;
using Sample.Domain.Services;
using Sample.Hypermedia.Utils;

namespace Sample.Application.Services
{
    public interface IInstallationAppService
    {
        IInstallationService _service { get; set; }

        InstallationVO Create(InstallationVO obj);
        InstallationVO FindByID(long id);
        List<InstallationVO> FindAll();
        InstallationVO Update(InstallationVO obj);
        void Delete(long id);
        
    }
}