using System;

namespace IgWebTest.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}