using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.BusinessUnits
{
    internal class BusinessUnitRepository : BaseRepository, IBusinessUnitRepository
    {
        public BusinessUnitRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
