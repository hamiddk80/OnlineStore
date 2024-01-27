using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql
{
    public class UnitOfWork(OnlineStoreDbContext db) : IUniOfWork
    {


        public Task<int> Commit()
        {
            throw new NotImplementedException();
        }
    }
}
