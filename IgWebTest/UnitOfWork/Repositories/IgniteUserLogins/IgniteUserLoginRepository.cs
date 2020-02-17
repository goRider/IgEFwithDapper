using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUserLogins
{
    internal class IgniteUserLoginRepository : BaseRepository, IIgniteUserLoginRepository
    {
        public IgniteUserLoginRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
