using System.Collections.Generic;
using System.Threading.Tasks;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUserApplications
{
    public interface IIgniteUserApplicationRepository
    {
        void AddApplication(IgniteUserApplication entity);
        Task AddApplicationAsync(IgniteUserApplication entity);
        IgniteUserApplication FindApplication(int id);
        void UpdateApplication(int id);
        void DeleteApplication(IgniteUserApplication entity);
        IEnumerable<IgniteUserApplication> GetUserApplications();
    }
}