using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteRoles
{
    internal class IgniteRoleRepository : BaseRepository, IIgniteRoleRepository
    {
        public IgniteRoleRepository(IDbTransaction transaction) : base(transaction)
        {
        }


        public void AddRole(IgniteRole entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateRoleAsync(IgniteRole entity)
        {
            return await Connection.QuerySingleAsync<int>($@"INSERT INTO [ApplicationRole] ([Name], [NormalizedName])
                    VALUES (@{nameof(IgniteRole.Name)}, @{nameof(IgniteRole.NormalizedName)});
                    SELECT CAST(SCOPE_IDENTITY() as int)", entity);
        }


        public IEnumerable<IgniteRole> GetRoles()
        {
            throw new NotImplementedException();
        }

        public void DeleteRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(IgniteRole entity)
        {
            throw new NotImplementedException();
        }

        public IgniteRole FindRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IgniteRole> FindRoleByIdAsync(int roleId)
        {
            return await Connection.QuerySingleOrDefaultAsync<IgniteRole>($@"SELECT * FROM [IgniteRole]
                WHERE [Id] = @{nameof(roleId)}", new { roleId });
        }

        public IgniteRole FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateRole(IgniteRole entity)
        {
            throw new NotImplementedException();
        }

        public Task<IgniteRole> UpdateRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IgniteRole> UpdateRoleAsync(IgniteRole entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IgniteRole> FindRoleByIdAsync(string roleId)
        {
            return await Connection.QuerySingleOrDefaultAsync<IgniteRole>($@"SELECT * FROM [IgniteRole]
                WHERE [Id] = @{nameof(roleId)}", new { roleId });
        }

        public Task CreateRoleAsync(IgniteUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
