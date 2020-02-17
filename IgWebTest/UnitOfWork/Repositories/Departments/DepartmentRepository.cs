using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IgWebTest.UnitOfWork.Repositories.Departments
{
    internal class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
