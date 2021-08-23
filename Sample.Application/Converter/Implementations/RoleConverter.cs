using System.Collections.Generic;
using System.Linq;
using Sample.Application.Converter.Contract;
using Sample.Application.VO;
using Sample.Domain.Entities;

namespace Sample.Application.Converter.Implementations
{
    public class RoleConverter : IParser<RoleVO, Role>, IParser<Role, RoleVO>
    {
        public Role Parse(RoleVO origin)
        {
            if (origin == null) return null;
            return new Role
            {
                Id = origin.Id,
                Item = origin.Role,
                Description = origin.Description,
                Enabled = origin.Enabled
            };
        }

        public List<Role> Parse(List<RoleVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public RoleVO Parse(Role origin)
        {
            if (origin == null) return null;
            return new RoleVO
            {
                Id = origin.Id,
                Role = origin.Item,
                Description = origin.Description,
                Enabled = origin.Enabled
            };
        }

        public List<RoleVO> Parse(List<Role> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}