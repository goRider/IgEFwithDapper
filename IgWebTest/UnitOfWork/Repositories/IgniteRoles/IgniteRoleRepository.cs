using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteRoles
{
    internal class IgniteRoleRepository : BaseRepository, IIgniteRoleRepository
    {
        public IgniteRoleRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
