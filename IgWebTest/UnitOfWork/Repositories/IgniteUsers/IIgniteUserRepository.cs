using System.Collections.Generic;
using System.Threading.Tasks;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUsers
{
    public interface IIgniteUserRepository
    {
        void CreateUser(IgniteUser entity);
        Task CreateUserAsync(IgniteUser entity);
        IEnumerable<IgniteUser> GetUserList();
        void DeleteUserById(int id);
        void DeleteUser(IgniteUser entity);
        IgniteUser FindUserById(int id);
        IgniteUser FindUserByUserName(string userName);
        IgniteUser FindUserByEmail(string email);
        Task<IgniteUser> FindUserByEmailAsync(string normalizedEmail);
        void UpdateUserGeneralInfo(IgniteUser entity);
        void UpdateUserPassword(IgniteUser entity);
        Task<int> UpdateUserInfoAsync(IgniteUser entity);
    }
}