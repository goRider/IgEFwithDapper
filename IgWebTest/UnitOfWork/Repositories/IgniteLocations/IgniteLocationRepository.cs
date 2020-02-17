using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.IgniteLocations
{
    internal class IgniteLocationRepository : BaseRepository,IIgniteLocationRepository
    {
        public IgniteLocationRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
