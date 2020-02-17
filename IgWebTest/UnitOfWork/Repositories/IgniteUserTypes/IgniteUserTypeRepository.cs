using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUserTypes
{
    internal class IgniteUserTypeRepository : BaseRepository, IIgniteUserTypeRepository
    {
        public IgniteUserTypeRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
