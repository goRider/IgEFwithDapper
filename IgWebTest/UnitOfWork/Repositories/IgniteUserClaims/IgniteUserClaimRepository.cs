using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUserClaims
{
    internal class IgniteUserClaimRepository : BaseRepository, IIgniteUserClaimRepository
    {
        public IgniteUserClaimRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
