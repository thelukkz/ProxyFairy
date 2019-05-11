using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;

namespace ProxyFairy.Core.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory _dbFactory;
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void BeginTransaction()
        {
            _dbFactory.GetDataContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _dbFactory.GetDataContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            _dbFactory.GetDataContext.Database.CommitTransaction();
        }

        public void SaveChanges()
        {
            _dbFactory.GetDataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbFactory.GetDataContext.SaveChangesAsync();
        }
    }
}
