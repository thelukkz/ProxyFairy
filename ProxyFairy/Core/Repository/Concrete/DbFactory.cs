using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;
using System;

namespace ProxyFairy.Core.Repository.Concrete
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private AppIdentityDbContext _dataContext;

        public DbFactory(AppIdentityDbContext context)
        {
            _dataContext = context;
        }
        public AppIdentityDbContext GetDataContext
        {
            get
            {
                return _dataContext;
            }
        }

        #region Disposing

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                _dataContext.Dispose();
            }
            isDisposed = true;
        }

        #endregion
    }
}
