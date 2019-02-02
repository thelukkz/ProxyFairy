namespace ProxyFairy.Core.Repository.Abstract
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();
    }
}
