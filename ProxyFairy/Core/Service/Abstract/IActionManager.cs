using System.Collections.Generic;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;

namespace ProxyFairy.Core.Service.Abstract
{
    public interface IActionManager
    {
        void Create(BaseEntity entity);
        void Update(BaseEntity entity);
        void Delete(BaseEntity entity);
        IEnumerable<BaseEntity> GetAll();
        IUnitOfWork UnitOfWork { get; }
        void SaveChanges();
    }
}
