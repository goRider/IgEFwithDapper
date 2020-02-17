using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
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

        public async Task CreateUserAsync(IgniteUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("No Entity");
            }

            await Connection.QueryAsync<int>($@"insert into ign.IgniteUser(UserName, NormalizedUserName, IgniteEmail, NormalizedIgniteEmail, " +
                                        $@"IgniteEmailConfirmed, PasswordHash, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled)  values ({nameof(entity.UserName)}, @{nameof(entity.NormalizedUserName)}), " + 
                                        $@"{nameof(entity.IgniteEmail)}, @{nameof(entity.NormalizedIgniteEmail)}, @{nameof(entity.IgniteEmailConfirmed)}" +
                                        $@"{nameof(entity.PasswordHash)}, @{nameof(entity.PhoneNumber)}, @{nameof(entity.PhoneNumberConfirmed)}, @{nameof(entity.TwoFactorEnabled)}", entity);
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

        public async Task<IgniteUser> FindUserByEmailAsync(string normalizedEmail)
        {
            return await Connection.QuerySingleOrDefaultAsync<IgniteUser>($@"select * from ign.IgniteUser where NormalizedIgniteEmail " +
                                                                   $@"= @{nameof(normalizedEmail)}", new { normalizedEmail });
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

        public async Task<int> UpdateUserInfoAsync(IgniteUser entity)
        {
            return await Connection.ExecuteAsync($@"UPDATE [IgniteUser] SET
                [UserName] = @{nameof(IgniteUser.UserName)},
                [NormalizedUserName] = @{nameof(IgniteUser.NormalizedUserName)},
                [IgniteEmail] = @{nameof(IgniteUser.IgniteEmail)},
                [NormalizedIgniteEmail] = @{nameof(IgniteUser.NormalizedIgniteEmail)},
                [IgniteEmailConfirmed] = @{nameof(IgniteUser.IgniteEmailConfirmed)},
                [PasswordHash] = @{nameof(IgniteUser.PasswordHash)},
                [PhoneNumber] = @{nameof(IgniteUser.PhoneNumber)},
                [PhoneNumberConfirmed] = @{nameof(IgniteUser.PhoneNumberConfirmed)},
                [TwoFactorEnabled] = @{nameof(IgniteUser.TwoFactorEnabled)}
                WHERE [Id] = @{nameof(IgniteUser.IgniteId)}", entity);
        }

        Task<int> IIgniteUserRepository.UpdateUserInfoAsync(IgniteUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUserAsync(IgniteUser entity, string password)
        {
            await Connection.QueryAsync<int>($@"insert into ign.IgniteUser(UserName, NormalizedUserName, IgniteEmail, NormalizedIgniteEmail, " +
                                             $@"IgniteEmailConfirmed, PasswordHash, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled)  values ({nameof(entity.UserName)}, @{nameof(entity.NormalizedUserName)}), " +
                                             $@"{nameof(entity.IgniteEmail)}, @{nameof(entity.NormalizedIgniteEmail)}, @{nameof(entity.IgniteEmailConfirmed)}" +
                                             $@"{nameof(entity.PasswordHash)}, @{nameof(entity.PhoneNumber)}, @{nameof(entity.PhoneNumberConfirmed)}, @{nameof(entity.TwoFactorEnabled)}", entity);
        }
    }
}
