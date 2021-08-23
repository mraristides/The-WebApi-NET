using System.Collections.Generic;
using Sample.Application.VO;
using Sample.Domain.Services;
using Sample.Hypermedia.Utils;

namespace Sample.Application.Services
{
    public interface IRoleAppService
    {
        IRoleService _service { get; set; }

        RoleVO Create(RoleVO obj);
        RoleVO FindByID(long id);
        List<RoleVO> FindAll();
        RoleVO Update(RoleVO obj);
        void Delete(long id);
        
    }
}