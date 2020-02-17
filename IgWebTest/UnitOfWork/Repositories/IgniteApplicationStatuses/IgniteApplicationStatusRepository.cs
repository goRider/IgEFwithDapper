using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteApplicationStatuses
{
    internal class IgniteApplicationStatusRepository : BaseRepository, IIgniteApplicationStatusRepository
    {
        public IgniteApplicationStatusRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
