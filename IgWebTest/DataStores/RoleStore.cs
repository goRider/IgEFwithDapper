using IgWebTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IgWebTest.DataStores
{
    public class RoleStore : IRoleStore<IgniteRole>
    {
        private readonly string _connectionString;

        public RoleStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(IgniteRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
            {
                await uow.IgniteRoleRepository.CreateRoleAsync(role);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(IgniteRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
            {
                await uow.IgniteRoleRepository.UpdateRoleAsync(role);
            }

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(IgniteRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(IgniteRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(IgniteRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(IgniteRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedRoleNameAsync(IgniteRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(IgniteRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.FromResult(0);
        }

        public async Task<IgniteRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            using (var uow = new UnitOfWork.UnitOfWork(_connectionString))
            {
                return await uow.IgniteRoleRepository.FindRoleByIdAsync(roleId);
            }
        }

        public Task<IgniteRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
