using System.Collections.Generic;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUsers
{
    internal interface IIgniteUserRepository
    {
        void CreateUser(IgniteUser entity);
        IEnumerable<IgniteUser> GetUserList();
        void DeleteUserById(int id);
        void DeleteUser(IgniteUser entity);
        IgniteUser FindUserById(int id);
        IgniteUser FindUserByUserName(string userName);
        IgniteUser FindUserByEmail(string email);
        void UpdateUserGeneralInfo(IgniteUser entity);
        void UpdateUserPassword(IgniteUser entity);
    }
}