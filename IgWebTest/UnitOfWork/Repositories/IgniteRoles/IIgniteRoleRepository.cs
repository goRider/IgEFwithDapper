using System.Collections.Generic;
using System.Threading.Tasks;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteRoles
{
    public interface IIgniteRoleRepository
    {
        void AddRole(IgniteRole entity);
        Task<int> CreateRoleAsync(IgniteRole entity);
        IEnumerable<IgniteRole> GetRoles();
        void DeleteRoleById(int id);
        void DeleteRole(IgniteRole entity);
        IgniteRole FindRoleById(int id);
        Task<IgniteRole> FindRoleByIdAsync(int id);
        Task<IgniteRole> FindRoleByIdAsync(string id);
        IgniteRole FindByName(string name);
        void UpdateRole(IgniteRole entity);
        Task<IgniteRole> UpdateRoleAsync(int id);
        Task<IgniteRole> UpdateRoleAsync(IgniteRole entity);
        Task CreateRoleAsync(IgniteUser user, string password);
    }
}