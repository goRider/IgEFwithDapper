using System;
using IgWebTest.UnitOfWork.Repositories.BusinessUnits;
using IgWebTest.UnitOfWork.Repositories.Departments;
using IgWebTest.UnitOfWork.Repositories.IgniteApplicationStatuses;
using IgWebTest.UnitOfWork.Repositories.IgniteLocations;
using IgWebTest.UnitOfWork.Repositories.IgniteRoles;
using IgWebTest.UnitOfWork.Repositories.IgniteTitles;
using IgWebTest.UnitOfWork.Repositories.IgniteUserApplications;
using IgWebTest.UnitOfWork.Repositories.IgniteUserClaims;
using IgWebTest.UnitOfWork.Repositories.IgniteUserLogins;
using IgWebTest.UnitOfWork.Repositories.IgniteUserRoleClaims;
using IgWebTest.UnitOfWork.Repositories.IgniteUserRoles;
using IgWebTest.UnitOfWork.Repositories.IgniteUsers;
using IgWebTest.UnitOfWork.Repositories.IgniteUserTypes;
using IgWebTest.UnitOfWork.Repositories.QuestionToAnswers;

namespace IgWebTest.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Add Repositories Here

        #region My Repositories
        
        IIgniteUserRepository IgniteUserRepository { get; }
        IIgniteLocationRepository IgniteLocationRepository { get; }
        IIgniteUserTypeRepository IgniteUserTypeRepository { get; }
        IIgniteUserApplicationRepository IgniteUserApplicationRepository { get; }
        IIgniteApplicationStatusRepository IgniteApplicationStatusRepository { get; }
        IBusinessUnitRepository BusinessUnitRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IQuestionToAnswerRepository QuestionToAnswerRepository { get; }
        ITitleRepository TitleRepository { get; }
        IIgniteUserRoleClaimRepository IgniteUserRoleClaimRepository { get; }
        IIgniteUserClaimRepository IgniteUserClaimRepository { get; }
        IIgniteUserLoginRepository IgniteUserLoginRepository { get; }
        IIgniteRoleRepository IgniteRoleRepository { get; }
        IIgniteUserRoleRepository IgniteUserRoleRepository { get; }

        //IIgniteUser
        #endregion
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}