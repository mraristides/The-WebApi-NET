using Sample.Domain.Context;
using Sample.Domain.Core.Base;
using Sample.Domain.Entities;
using Sample.Domain.Entities.Interfaces;
using Sample.Domain.Services;

namespace Sample.Domain.Core.Services
{
    public class InstallationService : Service<Installation>, IInstallationService
    {

        public InstallationService(MySQLContext context, IInstallationRepository repository) 
        : base(context, repository)
        {

        }
        
        public override Installation Create(Installation obj)
        {
            return _repository.Create(obj);
        }
    }
}