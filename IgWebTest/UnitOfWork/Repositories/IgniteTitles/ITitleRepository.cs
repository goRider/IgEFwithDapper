using System.Collections.Generic;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteTitles
{
    public interface ITitleRepository
    {
        void Add(IgniteUserTitle entity);
        IEnumerable<IgniteUserTitle> GetList();
        void Delete(int id);
        void Delete(IgniteUserTitle entity);
        IgniteUserTitle Find(int id);
        IgniteUserTitle FindByName(string name);
        void Update(IgniteUserTitle entity);
    }
}