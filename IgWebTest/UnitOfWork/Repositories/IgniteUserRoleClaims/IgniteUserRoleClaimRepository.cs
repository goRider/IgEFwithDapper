using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUserRoleClaims
{
    internal class IgniteUserRoleClaimRepository : BaseRepository, IIgniteUserRoleClaimRepository
    {
        public IgniteUserRoleClaimRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
