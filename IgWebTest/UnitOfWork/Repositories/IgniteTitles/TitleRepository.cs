using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IgWebTest.Models;

namespace IgWebTest.UnitOfWork.Repositories.IgniteTitles
{
    internal class TitleRepository : BaseRepository, ITitleRepository
    {
        public TitleRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Add(IgniteUserTitle entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IgniteUserTitle> GetList()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IgniteUserTitle entity)
        {
            throw new NotImplementedException();
        }

        public IgniteUserTitle Find(int id)
        {
            throw new NotImplementedException();
        }

        public IgniteUserTitle FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(IgniteUserTitle entity)
        {
            throw new NotImplementedException();
        }
    }
}
