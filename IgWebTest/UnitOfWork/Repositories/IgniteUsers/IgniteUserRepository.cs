using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteUsers
{
    internal class IgniteUserRepository : BaseRepository, IIgniteUserRepository
    {
        public IgniteUserRepository(IDbTransaction transaction)
        : base(transaction)
        {

        }

        public void CreateUser(IgniteUser entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IgniteUser> GetUserList()
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(IgniteUser entity)
        {
            throw new NotImplementedException();
        }

        public IgniteUser FindUserById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds user by UserName 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public IgniteUser FindUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public IgniteUser FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This update is available for all user information excluding passwords
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateUserGeneralInfo(IgniteUser entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassword(IgniteUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
