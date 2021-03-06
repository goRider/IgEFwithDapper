﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
    public class UnitOfWork : IUnitOfWork
    {
        //
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IIgniteUserRepository _igniteUserRepository;
        private IIgniteLocationRepository _igniteLocationRepository;
        private IIgniteUserTypeRepository _igniteUserTypeRepository;
        private IIgniteUserApplicationRepository _igniteUserApplicationRepository;
        private IIgniteApplicationStatusRepository _igniteApplicationStatusRepository;
        private IBusinessUnitRepository _businessUnitRepository;
        private IDepartmentRepository _departmentRepository;
        private IQuestionToAnswerRepository _questionToAnswerRepository;
        private ITitleRepository _titleRepository;
        private IIgniteUserRoleClaimRepository _igniteUserRoleClaimRepository;
        private IIgniteUserClaimRepository _igniteUserClaimRepository;
        private IIgniteUserLoginRepository _igniteUserLoginRepository;
        private IIgniteRoleRepository _igniteRoleRepository;
        private IIgniteUserRoleRepository _igniteUserRoleRepository;
        private bool _disposed;

        /// <summary>
        /// This constructor accepts a connection string and opens a connection. After the end of the lifecycle of this constructor the connection will be closed and be disposed
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        
        #region Repository Getters
        public IIgniteUserRepository IgniteUserRepository
        {
            get
            {
                return _igniteUserRepository ?? (_igniteUserRepository = new IgniteUserRepository(_transaction));
            }
        }
        public IIgniteLocationRepository IgniteLocationRepository
        {
            get
            {
                return _igniteLocationRepository ??
                       (_igniteLocationRepository = new IgniteLocationRepository(_transaction));
            }
        }

        public IIgniteUserTypeRepository IgniteUserTypeRepository
        {
            get
            {
                return _igniteUserTypeRepository ??
                       (_igniteUserTypeRepository = new IgniteUserTypeRepository(_transaction));
            }
        }

        public IIgniteUserApplicationRepository IgniteUserApplicationRepository
        {
            get
            {
                return _igniteUserApplicationRepository ??
                       (_igniteUserApplicationRepository = new IgniteUserApplicationRepository(_transaction));
            }
        }

        public IIgniteApplicationStatusRepository IgniteApplicationStatusRepository
        {
            get
            {
                return _igniteApplicationStatusRepository ??
                       (_igniteApplicationStatusRepository = new IgniteApplicationStatusRepository(_transaction));
            }
        }


        public IBusinessUnitRepository BusinessUnitRepository
        {
            get
            {
                return _businessUnitRepository ??
                       (_businessUnitRepository = new BusinessUnitRepository(_transaction));
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository ??
                       (_departmentRepository = new DepartmentRepository(_transaction));
            }
        }

        public IQuestionToAnswerRepository QuestionToAnswerRepository
        {
            get
            {
                return _questionToAnswerRepository ??
                       (_questionToAnswerRepository = new QuestionToAnswerRepository(_transaction));
            }
        }

        public ITitleRepository TitleRepository
        {
            get
            {
                return _titleRepository ??
                       (_titleRepository = new TitleRepository(_transaction));
            }
        }

        public IIgniteUserRoleClaimRepository IgniteUserRoleClaimRepository
        {
            get
            {
                return _igniteUserRoleClaimRepository ??
                       (_igniteUserRoleClaimRepository = new IgniteUserRoleClaimRepository(_transaction));
            }
        }

        public IIgniteUserClaimRepository IgniteUserClaimRepository
        {
            get
            {
                return _igniteUserClaimRepository ??
                       (_igniteUserClaimRepository = new IgniteUserClaimRepository(_transaction));
            }
        }

        public IIgniteUserLoginRepository IgniteUserLoginRepository
        {
            get
            {
                return _igniteUserLoginRepository ??
                       (_igniteUserLoginRepository = new IgniteUserLoginRepository(_transaction));
            }
        }

        public IIgniteRoleRepository IgniteRoleRepository
        {
            get
            {
                return _igniteRoleRepository ??
                       (_igniteRoleRepository = new IgniteRoleRepository(_transaction));
            }
        }

        public IIgniteUserRoleRepository IgniteUserRoleRepository
        {
            get
            {
                return _igniteUserRoleRepository ??
                       (_igniteUserRoleRepository = new IgniteUserRoleRepository(_transaction));
            }
        }
        #endregion
        
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _igniteUserRepository = null;
            _igniteLocationRepository = null;
            _igniteUserTypeRepository = null;
            _igniteUserApplicationRepository = null;
            _igniteApplicationStatusRepository = null;
            _businessUnitRepository = null;
            _departmentRepository = null;
            _questionToAnswerRepository = null;
            _titleRepository = null;
            _igniteUserRoleClaimRepository = null;
            _igniteUserClaimRepository = null;
            _igniteUserLoginRepository = null;
            _igniteRoleRepository = null;
            _igniteUserRoleRepository = null;
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            NewDispose(true);
            GC.SuppressFinalize(this);
        }

        public void NewDispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            NewDispose(false);
        }
    }
}
