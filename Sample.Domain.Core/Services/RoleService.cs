using Sample.Domain.Context;
using Sample.Domain.Core.Base;
using Sample.Domain.Entities;
using Sample.Domain.Entities.Interfaces;
using Sample.Domain.Services;

namespace Sample.Domain.Core.Services
{
    public class RoleService : Service<Role>, IRoleService
    {

        public RoleService(MySQLContext context, IRoleRepository repository) 
        : base(context, repository)
        {

        }
        
        public override Role Create(Role obj)
        {
            return _repository.Create(obj);
        }
    }
}