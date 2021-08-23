using System;
using System.Collections.Generic;
using System.Linq;
using Sample.Domain.Entities;
using Sample.Domain.Context;
using Sample.Domain.Entities.Interfaces;
using Sample.Repository.Base;
using Sample.Hypermedia.Utils;
using Microsoft.EntityFrameworkCore;

namespace Sample.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(MySQLContext context) : base (context) { }

    }
}