using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUserApplications
{
    internal class IgniteUserApplicationRepository : BaseRepository, IIgniteUserApplicationRepository
    {
        public IgniteUserApplicationRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        //public void AddApplication(IgniteUserApplication entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task AddApplicationAsync(IgniteUserApplication entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public IgniteUserApplication FindApplication(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateApplication(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteApplication(IgniteUserApplication entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<IgniteUserApplication> GetUserApplications()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
