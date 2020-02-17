using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace IgWebTest.DataStores
{
    public class UserStore : IUserStore<Models.IgniteUser>, IUserEmailStore<Models.IgniteUser>, IUserPhoneNumberStore<Models.IgniteUser>, IUserTwoFactorStore<Models.IgniteUser>, IUserPasswordStore<Models.IgniteUser>
    {
        private readonly string _connectionString;

        public UserStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("IgniteTestDatabase");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Models.IgniteUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Models.IgniteUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
            {
                await uow.IgniteUserRepository.CreateUserAsync(user);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
            {
                await uow.IgniteUserRepository.UpdateUserInfoAsync(user);
            }

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Models.IgniteUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Models.IgniteUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SetEmailAsync(Models.IgniteUser user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(Models.IgniteUser user, bool confirmed, CancellationToken cancellationToken)
        {
            using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
            {
                user.IgniteEmailConfirmed = confirmed;
                return Task.FromResult(0);
            }
        }

        public async Task<Models.IgniteUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    await connection.OpenAsync(cancellationToken);
                    connection.Close();
                    using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
                    {
                        return await uow.IgniteUserRepository.FindUserByEmailAsync(normalizedEmail);
                    }
                }

                SqlConnection.ClearAllPools();
            }
            return null;
        }

        public Task<string> GetNormalizedEmailAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(Models.IgniteUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedIgniteEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(Models.IgniteUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(Models.IgniteUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.PhoneNumberConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(Models.IgniteUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetPasswordHashAsync(Models.IgniteUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(Models.IgniteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
}
